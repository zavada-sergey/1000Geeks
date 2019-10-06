using Microsoft.AspNetCore.Http;
using System.IO;

namespace Api.Extensions
{
    public static class FormFileExtensions
    {
        public static byte[] AsByteArray(this IFormFile file)
        {
            byte[] imageData;
            using (var binaryReader = new BinaryReader(file.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)file.Length);
            }

            return imageData;
        }
    }
}