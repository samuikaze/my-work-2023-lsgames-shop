using LSGames.Shop.Repository.DBContexts;
using LSGames.Shop.Repository.Models;
using LSGames.Shop.Repository.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSGames.Shop.Repository.Repositories
{
    public class GoodRepository : GenericRepository<Good>, IGoodRepository
    {
        private LsgamesShopContext _context;

        public GoodRepository(LsgamesShopContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// 依據商品 PK 取得商品
        /// </summary>
        /// <param name="id">商品 PK</param>
        /// <returns></returns>
        public async Task<Good?> GetGood(long id)
        {
            return await _context.Goods
                .Where(good => good.GoodId == id)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// 以多筆商品 PK 取得多筆商品資料
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<List<Good>> GetGoods(List<long> ids)
        {
            return await _context.Goods
                .Where(good => ids.Contains(good.GoodId))
                .ToListAsync();
        }
    }
}
