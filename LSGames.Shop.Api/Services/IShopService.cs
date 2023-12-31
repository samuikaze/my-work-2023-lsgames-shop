using LSGames.Shop.Api.Models.ServiceModels;
using LSGames.Shop.Repository.Models;

namespace LSGames.Shop.Api.Services
{
    public interface IShopService
    {
        /// <summary>
        /// 取得商品列表
        /// </summary>
        /// <returns></returns>
        public Task<List<GoodServiceModel>> GetGoodList();

        /// <summary>
        /// 取得商品資料
        /// </summary>
        /// <param name="goodId">商品 PK</param>
        /// <returns></returns>
        public Task<GoodServiceModel> GetGood(long goodId);

        /// <summary>
        /// 以 ID 取得商品詳細資料
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<List<GoodServiceModel>> GetCartGoods(GetCartGoodsRequestServiceModel request);

        /// <summary>
        /// 上架新商品
        /// </summary>
        /// <param name="user"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<GoodServiceModel> CreateGood(UserServiceModel user, GoodServiceModel request);

        /// <summary>
        /// 更新商品
        /// </summary>
        /// <param name="user"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public Task<GoodServiceModel> UpdateGood(UserServiceModel user, GoodServiceModel request);

        /// <summary>
        /// 下架 (刪除) 商品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public Task<int> DeleteGood(GoodServiceModel request);

        /// <summary>
        /// 儲存購物車內容
        /// </summary>
        /// <param name="request"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<bool> SaveCart(SaveCartRequestServiceModel request, UserServiceModel user);

        /// <summary>
        /// 清除購物車
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<int> ResetCart(UserServiceModel user);

        /// <summary>
        /// 以帳號 ID 取得已儲存購物車內容
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<List<CartServiceModel>> GetSavedCartByUser(UserServiceModel user);
    }
}
