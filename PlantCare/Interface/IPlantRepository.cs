using System;
using PlantCare.Models;

namespace PlantCare.Interfaces
{
	public interface IPlantRepository
	{
        Task<List<Plant>> GetAllPlantsByPlantTypeId(int id);
        Task<Plant> GetPlantById(int id);
		bool Add(Plant plant);
		bool Edit(Plant plant);
		bool Delete(Plant plant);
		bool Save();
	}
}

