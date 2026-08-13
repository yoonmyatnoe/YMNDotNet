using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
