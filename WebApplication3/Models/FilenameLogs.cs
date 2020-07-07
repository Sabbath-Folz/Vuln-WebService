using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
	public class FilenameLogs
	{
		public FilenameLogs()
		{

		}

		[Key]
		public int Id { get; set; }
		public string filename { get; set; }
	}
}
