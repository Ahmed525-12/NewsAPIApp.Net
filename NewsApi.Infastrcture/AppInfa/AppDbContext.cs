using Microsoft.EntityFrameworkCore;
using NewsAPI.Domain.AppEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Infastrcture.AppInfa
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Banners> Banners { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<News> News { get; set; }
    }
}