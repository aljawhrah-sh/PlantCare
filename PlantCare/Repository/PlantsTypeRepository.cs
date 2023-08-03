using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlantCare.Data;
using PlantCare.Interfaces;
using PlantCare.Models;

namespace PlantCare.Repository
{
    public class PlantsTypeRepository : IPlantsTypeRepository
    {
		private readonly ApplicationDbContext _context;
		public PlantsTypeRepository(ApplicationDbContext context)
		{
			_context = context;
		}


        public bool Add(PlantsType plantsType)
        {
            _context.Add(plantsType);
            return Save();
        }

        public bool Delete(PlantsType plantsType)
        {
            _context.Remove(plantsType);
            return Save();
        }



        public bool Edit(PlantsType plantsType)
        {
            _context.Update(plantsType);
            return Save();
        }

        public async Task<IEnumerable<PlantsType>> GetAll()
        {
            var result = await _context.PlantsTypes.ToListAsync();
            return result;
        }



        public async Task<PlantsType> GetPlantTypeById(int id)
        {
            //must use inclund to return the whole plantsType with it's plantslist
             return await _context.PlantsTypes.Include(x=>x.Plants).FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}

