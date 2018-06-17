using Adopt_MS.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adopt_MS.Infrastructure.Repository
{
    public interface IAnimalRepository
    {

        /// <summary>
        /// 取得寵物認養資料
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<OpenDataModels>>GetOPAnamilAsync();
    }
}
