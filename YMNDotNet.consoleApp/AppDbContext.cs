using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMNDotNet.consoleApp.Models;

namespace YMNDotNet.consoleApp
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Data Source=.;Initial Catalog=YMNDotnet;User ID=sa;Password=9@1@84;TrustServerCertificate=True;";
                optionsBuilder.UseSqlServer(connectionString);

            }

        }

        public DbSet<BlogDataModel> Blogs { get; set; }

    }
}
