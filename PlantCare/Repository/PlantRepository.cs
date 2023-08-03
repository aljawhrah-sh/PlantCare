using System;
using Microsoft.EntityFrameworkCore;
using PlantCare.Data;
using PlantCare.Interfaces;
using PlantCare.Models;

namespace PlantCare.Repository
{
	public class PlantRepository : IPlantRepository
	{
        private readonly ApplicationDbContext _context;
		public PlantRepository(ApplicationDbContext context)
		{
            _context = context;
		}

        public bool Add(Plant plant)
        {
            _context.Add(plant);
            return Save();
        }

        public bool Delete(Plant plant)
        {
            _context.Remove(plant);
            return Save();
        }

        public bool Edit(Plant plant)
        {
            _context.Update(plant);
            return Save();
        }

        public async Task<List<Plant>> GetAllPlantsByPlantTypeId(int id)
        {
            var result =  await _context.PlantsTypes.Include(x=>x.Plants).FirstOrDefaultAsync(x => x.Id == id);
           // var result = await _context.Plants.Where(x => x.pl == id).ToListAsync();

            
            return result.Plants;
        }

        public async Task<Plant> GetPlantById(int id)
        {
            return await _context.Plants.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}

