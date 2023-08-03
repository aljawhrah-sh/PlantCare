using System;
using PlantCare.Models;

namespace PlantCare.Interfaces
{
	public interface IPlantsTypeRepository
	{

		Task<IEnumerable<PlantsType>> GetAll();
		Task<PlantsType> GetPlantTypeById(int id);
		bool Add(PlantsType plantsType);
		bool Edit(PlantsType plantsType);
		bool Delete(PlantsType plantsType);
		bool Save();
	}
}

