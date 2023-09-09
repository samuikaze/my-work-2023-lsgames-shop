using LSGames.Shop.Repository.DBContexts;
using LSGames.Shop.Repository.Models;
using LSGames.Shop.Repository.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace LSGames.Shop.Repository.Repositories
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        private LsgamesShopContext _context;

        public CartRepository(LsgamesShopContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// 以使用者帳號刪除購物車資料
        /// </summary>
        /// <param name="userId">使用者帳號 PK</param>
        /// <returns></returns>
        public async Task<int> DeleteCartItemsByUserId(long userId)
        {
            return await _context.Carts
                .Where(cart => cart.UserId == userId)
                .ExecuteDeleteAsync();
        }

        /// <summary>
        /// 以使用者帳號 PK 取得儲存的購物車內容
        /// </summary>
        /// <param name="userId">使用者帳號 PK</param>
        /// <returns></returns>
        public async Task<List<Cart>> GetCartByUserId(long userId)
        {
            return await _context.Carts
                .Where(cart => cart.UserId == userId)
                .ToListAsync();
        }
    }
}
