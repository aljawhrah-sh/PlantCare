using System;
using System.ComponentModel.DataAnnotations;

namespace PlantCare.Models
{
	public class Plant
	{
		[Key]
		public int Id { get; set; }
        public string PlantName { get; set; }
        public string About { get; set; }
        public string Care { get; set; }
        public string? Image { get; set; }
    }
}

