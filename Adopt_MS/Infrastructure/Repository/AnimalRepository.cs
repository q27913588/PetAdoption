using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Adopt_MS.Infrastructure.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace Adopt_MS.Infrastructure.Repository
{
    /// <summary>
    /// class AnimalRepository
    /// </summary>
    public class AnimalRepository : IAnimalRepository
    {
        private Uri targetURI => new Uri("http://data.coa.gov.tw/Service/OpenData/TransService.aspx?UnitId=QcbUEzN6E6DL");
   




        public async Task<IEnumerable<OpenDataModels>> GetOPAnamilAsync()
        {

            var source =await RetriveData();
          
            if (source == null)
            {
                var model = new List<OpenDataModels>();
                return model;
            }
            else
            {

                return source;
            };


        }

 

        private async Task<IEnumerable<OpenDataModels>> RetriveData()
        {
            string cacheKey = "OpenData";

            MemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());

            var model = _memoryCache.Get<IEnumerable<OpenDataModels>>(cacheKey);

            if (model != null)
            {
                return model;
            }
            else
            {
                HttpClient client = new HttpClient();
                client.MaxResponseContentBufferSize = Int32.MaxValue;
                var response = await client.GetStringAsync(targetURI);
                var collection = JsonConvert.DeserializeObject<IEnumerable<OpenDataModels>>(response);

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(12));
                _memoryCache.Set(cacheKey, collection, cacheEntryOptions);
                return collection;
            }

         
        }
    }
}
