using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCoreWindowsForms.Models
{

	///Mi configuración de Entity Framework Core 3.1:

	public class ApplicationDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=DemoWinForms;Integrated Security=True")
				.EnableSensitiveDataLogging(true)
				.UseLoggerFactory(MyLoggerFactory);
		}

		public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
		{
			builder
			   .AddFilter((category, level) =>
				   category == DbLoggerCategory.Database.Command.Name
				   && level == LogLevel.Information)
			   .AddConsole();
		});

		/// <summary>
		/// Indicarle a EntityFrameworkCore que vamos a tener una tabla en SqlServer
		/// la cual nos va a comunicar a través de esta propiedad.
		/// Adenás estamos indicando que esa tabla toará su forma a partir del modelo estudiante.
		/// </summary>
		public DbSet<Student> Students { get; set; }


	}
}
