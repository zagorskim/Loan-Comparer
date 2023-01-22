using BankAPI.Models;

namespace BankAPI.FileManager
{
    public interface IFileManager
    {
        Task Upload(FileModel model);
        Task<byte[]> Get(string imageName);
        string GetUrl(string imageName);
        void UploadTextFile(Inquiry inquiry);
    }
}
