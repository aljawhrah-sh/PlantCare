using Microsoft.AspNetCore.Mvc;
using PlantCare.Interfaces;
using PlantCare.ViewModels;
using PlantCare.Models;


namespace PlantCare.Controllers
{
    public class PlantsTypeController : Controller
    {
        private readonly IPlantsTypeRepository _plantTypeRepository;
        private readonly IphotoServices _photoServices;

        public PlantsTypeController(IPlantsTypeRepository plantTypeRepository, IphotoServices photoServices)
        {
            _plantTypeRepository = plantTypeRepository;
            _photoServices = photoServices;
        }

        //show all plants in the plantType
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var PlantsTypes = await _plantTypeRepository.GetAll();
            return View(PlantsTypes);
        }

        //create a plantType / use createPlantsTypeViewModel
        [HttpGet]
        public async  Task<IActionResult> Create()
        {
            var PlantType = await _plantTypeRepository.GetAll();
            var createVM = new CreatePlantsTypeViewModel();
            return View(createVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePlantsTypeViewModel createVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Creation failed");
            }
            else
            {
                var ImageToUrl = await _photoServices.AddPhotoAsync(createVM.Image);
                var PlantsType = new PlantsType
                {
                    Id = createVM.Id,
                    PlantTypeName = createVM.PlantTypeName,
                    Image = ImageToUrl.Url.ToString()
                };
                _plantTypeRepository.Add(PlantsType);
                return RedirectToAction("Index");
            }
            return View(createVM);
        }
        //edit a planType / use editPlantsTypeViewModel
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var plantsType = await _plantTypeRepository.GetPlantTypeById(id);
            if(plantsType == null)
            {
                return View("Error");
            }
            
                var editVM = new EditPlantsTypeViewModel
                {
                    Id = plantsType.Id,
                    PlantTypeName = plantsType.PlantTypeName,
                    Image = plantsType.Image
                };

            return View(editVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditPlantsTypeViewModel editVM)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Could not edit plantType");
                return View("Error");
            }
            var curPlantType = await _plantTypeRepository.GetPlantTypeById(id);
            if(curPlantType != null)
            {
                try
                {
                    await _photoServices.DeletePhotoAsync(curPlantType.Image);
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "could not delete photo");
                    return View("Error");
                }
                var plantsType = new PlantsType
                {
                    Id = editVM.Id,
                    PlantTypeName = editVM.PlantTypeName,
                    Image = editVM.Image
                };
                _plantTypeRepository.Edit(plantsType);
                return RedirectToAction("Index");
            }
            else
            {
                return View(editVM);
            }
        }
        //delete plantType action method
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var curPlantsType = await _plantTypeRepository.GetPlantTypeById(id);
            if (curPlantsType == null)
            {
                return View("Error");
            }
            else
                return View(curPlantsType);
            //test
        }

        [HttpPost]
        public async Task<IActionResult> DeletePlantsType(int id)
        {
            var curPlantsType = await _plantTypeRepository.GetPlantTypeById(id);
            if (curPlantsType == null)
                return View("Error");
            _plantTypeRepository.Delete(curPlantsType);
            return RedirectToAction("Index");
        }
    }
}

