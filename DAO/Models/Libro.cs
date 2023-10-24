using System;
using System.Collections.Generic;

namespace DAO.Models;

public partial class Libro
{
    public long Id { get; set; }

    public string? Titulo { get; set; }

    public string? Autor { get; set; }

    public string? Isbn { get; set; }
}
