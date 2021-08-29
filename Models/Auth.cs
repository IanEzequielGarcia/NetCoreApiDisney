using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIDisney.Models
{
    public class Auth
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public int Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
