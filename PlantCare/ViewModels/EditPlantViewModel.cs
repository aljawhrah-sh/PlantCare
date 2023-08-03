using System;
namespace PlantCare.ViewModels
{
	public class EditPlantViewModel
	{
        public int Id { get; set; }
        public string PlantName { get; set; }
        public string About { get; set; }
        public string Care { get; set; }
        public string? Image { get; set; }
    }
}

