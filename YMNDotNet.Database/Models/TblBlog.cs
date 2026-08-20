using System;
using System.Collections.Generic;

namespace YMNDotNet.Database.Models;

public partial class TblBlog
{
    public int BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;

    public string BlogAuthor { get; set; } = null!;

    public string BlogConent { get; set; } = null!;

    public bool? DeletedFlag { get; set; }
}
