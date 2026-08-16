using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMNDotNet.consoleApp.Models
{
    public class BlogDapperDataModel
    {
        public int BlogID { get; set; }

        public string BlogTitle { get; set; }

        public string BlogAuthor { get; set; }

        public string BlogConent { get; set; }
    }

    [Table("Tbl_blog")]
    public class BlogDataModel
    {
        [Key]
        [Column("Blogid")]
        public int BlogID { get; set; }

        [Column("BlogTitle")]
        public string BlogTitle { get; set; }

        [Column("BlogAuthor")]
        public string BlogAuthor { get; set; }

        [Column("BlogConent")]
        public string BlogConent { get; set; }

        [Column("DeletedFlag")]
        public Boolean DeletedFlag { get; set; }
    }
}
