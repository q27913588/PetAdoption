using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adopt_MS.Infrastructure;
using Adopt_MS.Infrastructure.Models;
using Adopt_MS.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Adopt_MS.Controllers
{
    /// <summary>
    /// 政府公開寵物認養API
    /// </summary>
    [Route("api/[Controller]")]
    [ApiController]
    public class OpenGovAnimalController : ControllerBase
    {
        private IAnimalRepository _animalRepository;
      
        public OpenGovAnimalController(IAnimalRepository Repository)
        {
            _animalRepository = Repository;

        }

        /// <summary>
        /// 政府公開寵物認養API
        /// </summary>
        /// <param name="City">縣市</param>
        /// <param name="Sex">性別</param>
        /// <param name="Type">種類</param>
        /// <param name="OrderBy">要排序的對象 City,Type,Sex</param>
        /// <param name="filter">如OrderBy選了City則filter需填入城市代碼</param>
        /// <param name="pageSize">預設20筆</param>
        /// <param name="PageNumber">頁碼</param>
        /// <returns></returns>
 
        [HttpGet]
        public async Task<IActionResult> GetOPAnimal(int? City, string Sex, string Type, string OrderBy, int? filter, int pageSize = 20, int PageNumber = 1)
        {

            var source = await _animalRepository.GetOPAnamilAsync();

            //城市
            if (City != null)
            {
                source = source.Where(x => x.animal_area_pkid == City);
            }
            //性別
            if (!string.IsNullOrEmpty(Sex))
            {
                source = source.Where(x => Sex.Contains(x.animal_sex));

            }
            //類型
            if (!string.IsNullOrEmpty(Type))
            {
                source = source.Where(x => Type.Contains(x.animal_kind));
            }
            //排序

            switch (OrderBy)
            {
                case "City":
                    source = source.OrderBy(x => x.animal_area_pkid == filter);

                    break;
                case "Type":
                    source = source.OrderBy(x => x.animal_kind);
                    break;
                case "Sex":
                    source = source.OrderBy(x => x.animal_sex);
                    break;


                default:
                    source = source.OrderBy(x => x.animal_opendate);
                    break;
            }


            int totalCount = source.Count();

            //頁碼
            var pageIndex = GetPageRange(totalCount, pageSize, PageNumber);

            //分頁
            source = source.Skip(pageIndex.StartIndex).Take(pageIndex.ResponseCount);

            var result = new PageModel
            {
                Result = source,
                PageNumber = PageNumber,
                TotalItems = totalCount,
                PageSize = pageSize,
            };




            return Ok(result);


        }
        protected class PageIndex
        {
            public int StartIndex { get; set; }
            public int ResponseCount { get; set; }
        }
        protected PageIndex GetPageRange(int TotalCount = 0, int PageSize = 10, int PageNumber = 1)
        {
            var StartIndex = PageSize * (PageNumber - 1);
            var ResponseCount = PageSize;

            if (StartIndex >= TotalCount)
            {
                StartIndex = 0;
                ResponseCount = 0;
            }
            else if (StartIndex + ResponseCount > TotalCount)
            {
                ResponseCount = TotalCount - StartIndex;
            }


            return new PageIndex()
            {
                StartIndex = StartIndex,
                ResponseCount = ResponseCount
            };
        }



    }
}