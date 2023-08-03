using System;
namespace PlantCare.ViewModels
{
	public class CreatePlantViewModel
	{
        public int Id { get; set; }
        public string PlantName { get; set; }
        public string About { get; set; }
        public string Care { get; set; }
        public IFormFile Image { get; set; }
    }
}

