using System;
using Microsoft.AspNetCore.Http;
namespace Application.Services.Cloudinary;

public interface ICloudinaryService
{
    Task<string> UploadImageAsync(IFormFile file);
}
