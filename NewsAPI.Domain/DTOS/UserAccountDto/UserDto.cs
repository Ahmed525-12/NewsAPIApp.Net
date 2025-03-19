using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAPI.Domain.DTOS.UserAccountDto
{
    public class UserDto
    {
        public string Email { get; set; }

        public string UserName { get; set; }
    }
}