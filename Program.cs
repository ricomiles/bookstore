using BookStore.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookstoreContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/books", async (BookstoreContext context) =>
{
    return await context.Books.ToListAsync();
})
.WithName("GetBooks")
.WithOpenApi();

app.MapPost("/books/create-book", async (BookstoreContext context, Book book) =>
{
    context.Books.Add(book);
    await context.SaveChangesAsync();
    return Results.Created($"/books/{book.Id}", book);
})
.WithName("CreateBook")
.WithOpenApi();

app.MapGet("books/{id:int}", async (BookstoreContext context, int id) =>
{
    return await context.Books.FindAsync(id);
})
.WithName("GetBookByID")
.WithOpenApi();

app.MapPut("books/{id:int}", async (BookstoreContext context, Book updatedBook, int id) =>
{
    var existingBook = await context.Books.FindAsync(id);

    if (existingBook == null)
    {
        return Results.NotFound();
    }

    var updatedExistingBook = existingBook with
    {
        Title = updatedBook.Title ?? existingBook.Title,
        Author = updatedBook.Author ?? existingBook.Author,
        Genre = updatedBook.Genre ?? existingBook.Genre,
        Price = updatedBook.Price != 0 ? updatedBook.Price : existingBook.Price
    };

    context.Entry(existingBook).CurrentValues.SetValues(updatedExistingBook);
    await context.SaveChangesAsync();

    return Results.Ok();

})
.WithName("UpdateBook")
.WithOpenApi();

app.MapDelete("books/{id:int}", async (BookstoreContext context, int id) =>
{
    var book = await context.Books.FindAsync(id);
    if (book == null)
    {
        return Results.NotFound();
    }

    context.Books.Remove(book);
    await context.SaveChangesAsync();

    return Results.Ok();
})
.WithName("DeleteBook")
.WithOpenApi();


app.Run();

