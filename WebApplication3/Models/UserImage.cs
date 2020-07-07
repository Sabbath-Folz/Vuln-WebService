using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class UserImage
    {
        public UserImage()
        {
                              
        }
        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string UId { get; set; }

        public string Path { get; set; }
    }
}
