using System;
using System.Collections.Generic;

namespace ModDatabaseFirstApproach.Models;

public partial class Book
{
    public int BookId { get; set; }

    public int GenreId { get; set; }

    public string Name { get; set; } = null!;

    public string? Author { get; set; }

    public DateOnly? PublicationDate { get; set; }

    public virtual Genre Genre { get; set; } = null!;
}
