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
        /// 上架新商品
        /// </summary>
        /// <param name="user"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GoodServiceModel> CreateGood(UserServiceModel user, GoodServiceModel request)
        {
            var good = _mapper.Map<Good>(request);
            good.CreatedUserId = user.Id;
            good.CreatedAt = DateTime.Now;
            good.UpdatedUserId = user.Id;
            good.UpdatedAt = DateTime.Now;

            await _goodRepository.CreateAsync(good);

            return _mapper.Map<GoodServiceModel>(good);
        }

        /// <summary>
        /// 更新商品
        /// </summary>
        /// <param name="user"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<GoodServiceModel> UpdateGood(UserServiceModel user, GoodServiceModel request)
        {
            var good = await _goodRepository.GetGood(request.GoodId);
            if (good == null)
            {
                throw new NullReferenceException("找不到該商品");
            }

            good.Name = request.Name;
            good.PreviewImagee = request.PreviewImagee;
            good.Description = request.Description;
            good.Price = request.Price;
            good.Quantity = request.Quantity;
            good.Status = request.Status;
            good.UpdatedUserId = user.Id;
            good.UpdatedAt = DateTime.Now;
            await _goodRepository.UpdateAsync(good);

            return _mapper.Map<GoodServiceModel>(good);
        }

        /// <summary>
        /// 下架 (刪除) 商品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<int> DeleteGood(GoodServiceModel request)
        {
            var good = await _goodRepository.GetGood(request.GoodId);
            if (good == null)
            {
                throw new NullReferenceException("找不到該商品");
            }

            return await _goodRepository.DeleteAsync(good);
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
