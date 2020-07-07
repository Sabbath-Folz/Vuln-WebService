using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Data
{
	public class FilenameLogsDbContext : DbContext
	{
		public DbSet<FilenameLogs> filenameLogs { get; set; }

		public FilenameLogsDbContext(DbContextOptions<FilenameLogsDbContext> options)
		: base(options)
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			optionsBuilder.UseSqlite("Data Source=./../database_05.db");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

		}
	}

}
