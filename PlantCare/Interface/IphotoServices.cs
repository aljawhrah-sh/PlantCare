using System;
using CloudinaryDotNet.Actions;

namespace PlantCare.Interfaces
{
	public interface IphotoServices
	{

        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(String publicId);
    }
}

