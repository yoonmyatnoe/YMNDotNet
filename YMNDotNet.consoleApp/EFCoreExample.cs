using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMNDotNet.consoleApp.Models;

namespace YMNDotNet.consoleApp
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            var blogs = db.Blogs.Where(x => x.DeletedFlag == false).ToList();
            foreach (var item in blogs)
            {
                Console.WriteLine(item.BlogID);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogConent);
                Console.WriteLine("-----------------");
            }

        }

        public void Create() {
            AppDbContext db = new AppDbContext();

            Console.WriteLine("Enter Blog Title");
            string title = Console.ReadLine();

            Console.WriteLine("Enter Blog Author");
            string author = Console.ReadLine();

            Console.WriteLine("Enter Blog Content");
            string content = Console.ReadLine();

            BlogDataModel blog = new BlogDataModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogConent = content,
                DeletedFlag = false
            };
            db.Blogs.Add(blog);
            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Insert Successfully!" : "Fail to Insert!");



        }


    }
}
