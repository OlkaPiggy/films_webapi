using System;
using System.Collections.Generic;

namespace Sopotnytska_Olha.Models;

public partial class Member
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Director { get; set; }

    public string? Duration { get; set; }

    public string? Genre { get; set; }

    public string? Recommend { get; set; }

    public string? Comment { get; set; }
}
