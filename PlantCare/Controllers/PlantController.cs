using Microsoft.AspNetCore.Mvc;
using PlantCare.Interfaces;
using PlantCare.ViewModels;
using PlantCare.Models;

namespace PlantCare.Controllers
{
    public class PlantController : Controller
    {
        private readonly IPlantRepository _plantRepository;
        private readonly IPlantsTypeRepository _plantsTypeRepository;
        private readonly IphotoServices _photoServices;

        public PlantController(IPlantRepository plantRepository, IphotoServices photoServices, IPlantsTypeRepository plantsTypeRepository)
        {
            _plantRepository = plantRepository;
            _photoServices = photoServices;
            _plantsTypeRepository = plantsTypeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {

            var plantsList = await _plantsTypeRepository.GetPlantTypeById(id);

            return View(plantsList);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //var plant = await _plantRepository.GetAll();
            //
            var createVM = new CreatePlantViewModel();
            return View(createVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePlantViewModel createVM)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "creation failed");
            }
            else
            {
                var ImageToUrl = await _photoServices.AddPhotoAsync(createVM.Image);
                var plant = new Plant
                {
                    Id = createVM.Id,
                    PlantName = createVM.PlantName,
                    About = createVM.About,
                    Care = createVM.Care,
                    Image = ImageToUrl.Url.ToString()
                };
                _plantRepository.Add(plant);
                return RedirectToAction("Index");
            }
            return View(createVM);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var plant = await _plantRepository.GetPlantById(id);
            if(plant == null)
            {
                return View("Error");
            }
            var editVM = new EditPlantViewModel
            {
                Id = plant.Id,
                PlantName = plant.PlantName,
                About = plant.About,
                Care = plant.Care,
                Image = plant.Image
            };
            return View(editVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditPlantViewModel editVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Could not edit plant");
                return View("Error");
            }
            var curPlant = await _plantRepository.GetPlantById(id);
            if(curPlant != null)
            {
                try
                {
                    await _photoServices.DeletePhotoAsync(curPlant.Image);
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "could not delete photo");
                    return View("Error");
                }
                var plant = new Plant
                {
                    Id = editVM.Id,
                    PlantName = editVM.PlantName,
                    About = editVM.About,
                    Care = editVM.Care,
                    Image = editVM.Image
                };
                _plantRepository.Edit(plant);
                return RedirectToAction("Index");
            }
            else
            {
                return View(editVM);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var curPlant = await _plantRepository.GetPlantById(id);
            if (curPlant == null)
            {
                return View("Error");
            }
            else
                return View(curPlant);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePlant(int id)
        {
            var curPlant = await _plantRepository.GetPlantById(id);
            if(curPlant == null)
            {
                return View("Error");
            }
            _plantRepository.Delete(curPlant);
            return RedirectToAction("Index");
        }
    }
}








