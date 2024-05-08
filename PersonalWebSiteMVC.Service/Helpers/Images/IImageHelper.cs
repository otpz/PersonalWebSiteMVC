using Microsoft.AspNetCore.Http;
using PersonalWebSiteMVC.Entity.Enums;
using PersonalWebSiteMVC.Entity.ViewModels.Images;

namespace PersonalWebSiteMVC.Service.Helpers.Images
{
    public interface IImageHelper
    {
        Task<ImageUploadedViewModel> Upload(string name, IFormFile imageFile, ImageType imagetype, string folderName = null);
        void Delete(string imageName);
    }
}
