using Comic.Data.Models;
using ComicApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComicApp.Services
{
    public interface IComicService
    {
        Task<string> AddNewComic(ComicBook comic);
        Task<ComicBook> UpdateComic(ComicBook comic);
        Task<string> RemoveComic(ComicBook comic);
        Task<IEnumerable<ComicBook>> GetAllComicBooks();
        Task<IEnumerable<MarvelComic>> SearchMarvel(MarvelComicSearchParam marvelParams);
        Task<ComicBook> GetComicBookById(int id);
    }
}