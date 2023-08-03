using System;
using System.ComponentModel.DataAnnotations;

namespace PlantCare.Models
{
	public class PlantsType
	{
		[Key]
		public int Id { get; set; }
        public string PlantTypeName { get; set; }
        public string? Image { get; set; }
		//association
        public List<Plant>? Plants { get; set; }
	}
}

  