using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Description
    {
        public Description()
        {

        }

        [Key]
        public int id { get; set; }
        public string Path { get; set; }
        public string Text { get; set; }
    }
}
