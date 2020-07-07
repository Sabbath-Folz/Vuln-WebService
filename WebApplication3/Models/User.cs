using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class User
    {
        public User(string Username, string pw)
        {
            this.Username = Username;
            this.pw = pw;
            
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Username { get; set; }

        [Required]
        [MaxLength(2048)]
        public string pw { get; set; }
    }
}
