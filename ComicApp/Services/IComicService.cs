using Comic.Data.Models;
using System.Threading.Tasks;

namespace ComicApp.Services
{
    public interface IComicService
    {
        Task<string> AddNewComic(ComicBook comic);
    }
}