using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAPI.Domain.AppEntity
{
    public class News : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ImgUrl { get; set; }
        public string Desc { get; set; }

        public DateTime NewsDate { get; set; } = DateTime.Now;
    }
}