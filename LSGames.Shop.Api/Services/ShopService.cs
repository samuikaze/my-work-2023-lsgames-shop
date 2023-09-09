using AutoMapper;
using LSGames.Shop.Api.Models.ServiceModels;
using LSGames.Shop.Repository.Models;
using LSGames.Shop.Repository.Repositories;

namespace LSGames.Shop.Api.Services
{
    public class ShopService : IShopService
    {
        private readonly IMapper _mapper;
        private IGoodRepository _goodRepository;
        private ICartRepository _cartRepository;

        public ShopService(
            IMapper mapper,
            IGoodRepository goodRepository,
            ICartRepository cartRepository)
        {
            _mapper = mapper;
            _goodRepository = goodRepository;
            _cartRepository = cartRepository;
        }

        /// <summary>
        /// 取得商品列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<GoodServiceModel>> GetGoodList()
        {
            return _mapper.Map<List<GoodServiceModel>>(
                await _goodRepository.GetAsync());
        }

        /// <summary>
        /// 取得商品資料
        /// </summary>
        /// <param name="goodId">商品 PK</param>
        /// <returns></returns>
        public async Task<GoodServiceModel> GetGood(long goodId)
        {
            return _mapper.Map<GoodServiceModel>(
                await _goodRepository.GetGood(goodId));
        }

        /// <summary>
        /// 以 ID 取得商品詳細資料
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<List<GoodServiceModel>> GetCartGoods(GetCartGoodsRequestServiceModel request)
        {
            return _mapper.Map<List<GoodServiceModel>>(
                await _goodRepository.GetGoods(request.Goods));
        }

        /// <summary>
        /// 儲存購物車內容
        /// </summary>
        /// <param name="request"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> SaveCart(SaveCartRequestServiceModel request, UserServiceModel user)
        {
            var carts = _mapper.Map<List<Cart>>(request.Cart);

            carts.ForEach(cart =>
            {
                cart.UserId = user.Id;
                cart.CreatedAt = DateTime.Now;
                cart.UpdatedAt = DateTime.Now;
            });

            await _cartRepository.CreateAsync(carts);

            return true;
        }

        /// <summary>
        /// 清除購物車
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<int> ResetCart(UserServiceModel user)
        {
            return await _cartRepository.DeleteCartItemsByUserId(user.Id);
        }

        /// <summary>
        /// 以帳號 ID 取得已儲存購物車內容
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<List<CartServiceModel>> GetSavedCartByUser(UserServiceModel user)
        {
            return _mapper.Map<List<CartServiceModel>>(
                await _cartRepository.GetCartByUserId(user.Id));
        }
    }
}
