namespace demo_crud3tables.Helper
{
    public class FileUpload
    {
        static readonly string baseFolder = "Uploads/"; //5025
        static readonly string rootUrl = "http://localhost:5025/";

        public static string SaveImages(string folder, IFormFile image)
        {
            string imageName = Guid.NewGuid().ToString() + "_" + image.FileName;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"{baseFolder}\\{folder}");
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            var exactPath = Path.Combine(Directory.GetCurrentDirectory(), $"{baseFolder}\\{folder}", imageName);
            using (var fileSystem = new FileStream(exactPath, FileMode.Create))
            {
                image.CopyTo(fileSystem);
            }
            return rootUrl + baseFolder + folder + "/" + imageName;
        }

        public static void DeleteImage(string imageName)
        {
            string pathImage = imageName.Substring(rootUrl.Length);
            //var filePath = Path.Combine(pathImage);
            var filePath = Path.Combine(pathImage);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
