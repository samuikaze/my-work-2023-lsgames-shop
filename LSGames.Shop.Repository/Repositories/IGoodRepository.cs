using LSGames.Shop.Repository.Models;
using LSGames.Shop.Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSGames.Shop.Repository.Repositories
{
    public interface IGoodRepository : IGenericRepository<Good>
    {
        /// <summary>
        /// 依據商品 PK 取得商品
        /// </summary>
        /// <param name="id">商品 PK</param>
        /// <returns></returns>
        public Task<Good?> GetGood(long id);

        /// <summary>
        /// 以多筆商品 PK 取得多筆商品資料
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<List<Good>> GetGoods(List<long> ids);
    }
}
