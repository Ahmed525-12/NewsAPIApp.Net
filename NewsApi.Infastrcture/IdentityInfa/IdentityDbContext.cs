using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsAPI.Domain.IdentityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Infastrcture.IdentityInfa
{
    public class IdentityDbContext : IdentityDbContext<Account>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
        }

        private DbSet<Account> Account
        {
            get; set;
        }
    }
}