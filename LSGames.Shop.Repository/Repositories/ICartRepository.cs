using LSGames.Shop.Repository.Models;
using LSGames.Shop.Repository.Repositories.Abstracts;

namespace LSGames.Shop.Repository.Repositories
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        /// <summary>
        /// 以使用者帳號刪除購物車資料
        /// </summary>
        /// <param name="userId">使用者帳號 PK</param>
        /// <returns></returns>
        public Task<int> DeleteCartItemsByUserId(long userId);

        /// <summary>
        /// 以使用者帳號 PK 取得儲存的購物車內容
        /// </summary>
        /// <param name="userId">使用者帳號 PK</param>
        /// <returns></returns>
        public Task<List<Cart>> GetCartByUserId(long userId);
    }
}
