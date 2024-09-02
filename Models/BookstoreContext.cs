using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models;

public partial class BookstoreContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public BookstoreContext(DbContextOptions<BookstoreContext> context)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(@"Host=localhost;Port=6000;Database=bookstore;Username=freezing;Password=freezing");

}
