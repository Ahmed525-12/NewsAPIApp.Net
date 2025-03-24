using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAPI.Domain.DTOS.BannersDto
{
    public class BannersCreateDto
    {
        [Required]
        public String ImageUrl { get; set; }

        [Required]
        public String Name { get; set; }
    }
}