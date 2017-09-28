using Comic.Data.Models;
using ComicApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;

namespace ComicApp.Services
{
    public class ComicService : IComicService
    {
        private string _comicURL = "http://localhost:50963/api/";
        private string _marvelURL = "https://gateway.marvel.com:443/v1/public/";
        private string _marvelKey = "a8791b359b2770ecaa5abe736105aab0";
        private string _marvelPrivateKey = "dab315d9b33e47fe10658400043f4c14a643b6dc";
        public async Task<string> AddNewComic(ComicBook comic)
        {
            String json = JsonConvert.SerializeObject(comic);
            Uri addNewComic = new Uri(_comicURL + @"comicbook");
            HttpResponseMessage response;
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                /*client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _key);*/
                response = await client.PostAsync(addNewComic, content).ConfigureAwait(false);
            }
            if (response.StatusCode == HttpStatusCode.Created)
            {
                string[] location = response.Headers.Location.ToString().Split('/');
                return location[location.Length - 1];
            }
            else
            {
                return "ERROR";
            }
        }

        public virtual async Task<ComicBook> UpdateComic(ComicBook comic)
        {
            String json = JsonConvert.SerializeObject(comic);
            Uri updatecomic = new Uri(_comicURL + @"comicbook");
            HttpResponseMessage response;
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                /*client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _key);*/
                response = await client.PutAsync(updatecomic, content).ConfigureAwait(false);
            }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return comic;
            }
            else
            {
                return new ComicBook();
            }
        }

        public async Task<string> RemoveComic(ComicBook comic)
        {
            Uri removeComic = new Uri(_comicURL + @"comicbook/" + comic.Id);
            HttpResponseMessage response;

            using (HttpClient client = new HttpClient())
            {
                /*client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _key);*/
                response = await client.DeleteAsync(removeComic).ConfigureAwait(false);
            }
            return response.StatusCode.ToString();
        }

        public async Task<IEnumerable<ComicBook>> GetAllComicBooks()
        {
            Uri getComicBooks = new Uri(_comicURL + @"comicbook");
            String json = String.Empty;
            using (HttpClient client = new HttpClient())
            {
                /*client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _key);*/
                json = await client.GetStringAsync(getComicBooks).ConfigureAwait(false);
            }
            IEnumerable<ComicBook> comics = JsonConvert.DeserializeObject<IEnumerable<ComicBook>>(json);
            return comics;
        }

        public async Task<ComicBook> GetComicBookById(int id)
        {
            Uri getComicBook = new Uri(_comicURL + @"comicbook/" + id);
            String json = String.Empty;
            using (HttpClient client = new HttpClient())
            {
                /*client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _key);*/
                json = await client.GetStringAsync(getComicBook).ConfigureAwait(false);
            }
            ComicBook comic = JsonConvert.DeserializeObject<ComicBook>(json);
            return comic;
        }



        #region Marvel
        public async Task<IEnumerable<MarvelComic>> SearchMarvel(MarvelComicSearchParam marvelParams)
        {
            string ts = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            string queryParams = "ts="+ts+"&hash="+ CalculateMD5Hash(ts + _marvelPrivateKey + _marvelKey) + "&";
            queryParams += string.IsNullOrWhiteSpace(marvelParams.Format) ? "" : "format=" + marvelParams.Format + "&";
            queryParams += string.IsNullOrWhiteSpace(marvelParams.FormatType) ? "" : "formatType=" + marvelParams.FormatType + "&";
            queryParams += string.IsNullOrWhiteSpace(marvelParams.Title) ? "" : "title=" + marvelParams.Title + "&";
            queryParams += string.IsNullOrWhiteSpace(marvelParams.TitleStartsWith) ? "" : "titleStartsWith=" + marvelParams.TitleStartsWith + "&";
            queryParams += marvelParams.StartYear.ToString().Length == 4 ? "startYear=" + marvelParams.StartYear + "&" : "";
            queryParams += marvelParams.IssueNumber > 0 ? "issueNumber=" + marvelParams.IssueNumber + "&" : "";
            queryParams += "apikey=" + _marvelKey;
            Uri getMarvelComics = new Uri(_marvelURL + @"comics?"+queryParams);
            String json = String.Empty;
            using(HttpClient client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _marvelKey);
                json = await client.GetStringAsync(getMarvelComics).ConfigureAwait(false);
            }
            JObject marvelComics = JObject.Parse(json);
            IEnumerable<MarvelComic> comics = JsonConvert.DeserializeObject<IEnumerable<MarvelComic>>(marvelComics["data"]["results"].ToString());
            return comics;
        }

        public string CalculateMD5Hash(string input)
        {

            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();

        }
        #endregion
    }
}