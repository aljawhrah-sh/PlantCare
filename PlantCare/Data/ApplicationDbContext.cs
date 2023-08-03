using System;
using Microsoft.EntityFrameworkCore;
using PlantCare.Models;

namespace PlantCare.Data
{
	public class ApplicationDbContext :DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
		{
		}
		public DbSet<PlantsType> PlantsTypes { get; set; }
		public DbSet<Plant> Plants { get; set; }
	}
}

