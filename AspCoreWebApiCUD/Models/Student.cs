using System;
using System.Collections.Generic;

namespace AspCoreWebApiCUD.Models;

public partial class Student
{
    public int Id { get; set; }

    public string StudentName { get; set; } = null!;

    public string StudentGender { get; set; } = null!;

    public int Age { get; set; }

    public string Standerds { get; set; } = null!;

    public string FatherName { get; set; } = null!;
}
