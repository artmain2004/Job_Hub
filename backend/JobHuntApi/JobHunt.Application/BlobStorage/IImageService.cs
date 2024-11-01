﻿

using Microsoft.AspNetCore.Http;

namespace JobHunt.Application.BlobStorage;

public interface IImageService
{
   Task UploadImageAsync(IFormFile file,  string imageName, string fileName );
   Task DeleteImageAsync(string fileName,string imageName);
   
}