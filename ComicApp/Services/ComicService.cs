using Comic.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ComicApp.Services
{
    public class ComicService : IComicService
    {
        private string _comicURL = "http://localhost:50963/api/";
        private string _marvelURL = "https://gateway.marvel.com:443/v1/public/";
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
    }
}