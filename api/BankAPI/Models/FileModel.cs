namespace BankAPI.Models
{
    public class FileModel
    {
        public IFormFile ImageFile { get; set; }
        public FileModel()
        {
        }
        public FileModel(IFormFile file)
        {
            ImageFile = file;
        }
    }
}
