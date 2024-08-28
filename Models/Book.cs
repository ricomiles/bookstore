using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models;

/// <summary>
/// These are the books
/// </summary>
[Table("book")]
public partial class Book
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    [StringLength(20)]
    public string? Title { get; set; }

    [Column("author")]
    [StringLength(20)]
    public string? Author { get; set; }

    [Column("genre")]
    [StringLength(20)]
    public string? Genre { get; set; }

    [Column("price")]
    public double? Price { get; set; }
}
