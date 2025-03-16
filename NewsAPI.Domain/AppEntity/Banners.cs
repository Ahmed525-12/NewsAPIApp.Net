using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAPI.Domain.AppEntity
{
    public class Banners : BaseEntity
    {
        public String ImageUrl { get; set; }
        public String Name { get; set; }
    }
}