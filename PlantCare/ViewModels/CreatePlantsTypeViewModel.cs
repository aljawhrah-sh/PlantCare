using System;
using PlantCare.Models;

namespace PlantCare.ViewModels
{
	public class CreatePlantsTypeViewModel
	{
        public int Id { get; set; }
        public string PlantTypeName { get; set; }
        public IFormFile? Image { get; set; }
        public IEnumerable<Plant>? Plants { get; set; }
    }
}

