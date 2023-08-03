using System;
using PlantCare.Models;

namespace PlantCare.ViewModels
{
	public class HomeViewModel
	{
  
        public int Id { get; set; }
        public string PlantTypeName { get; set; }
        public string? Image { get; set; }
        public IEnumerable<Plant>? Plants { get; set; }
    }
}

