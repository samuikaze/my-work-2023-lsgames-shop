using AutoMapper;
using LSGames.Shop.Api.Filters;
using LSGames.Shop.Api.Models.ServiceModels;
using LSGames.Shop.Api.Models.ViewModels;
using LSGames.Shop.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LSGames.Shop.Api.Controllers
{
    [ApiController]
    [Route("shop")]
    [SwaggerTag("商店")]
    public class ShopController : ControllerBase
    {
        private readonly ILogger<ShopController> _logger;
        private readonly IMapper _mapper;
        private IShopService _shopService;

        public ShopController(
            ILogger<ShopController> logger,
            IMapper mapper,
            IShopService shopService)
        {
            _logger = logger;
            _mapper = mapper;
            _shopService = shopService;
        }

        /// <summary>
        /// 取得商品列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("goods")]
        public async Task<List<GoodViewModel>> GetGoodList()
        {
            return _mapper.Map<List<GoodViewModel>>(
                await _shopService.GetGoodList());
        }

        /// <summary>
        /// 取得商品資料
        /// </summary>
        /// <param name="goodId">商品 PK</param>
        /// <returns></returns>
        [HttpGet("goods/{goodId}")]
        public async Task<ActionResult<GoodViewModel>> GetGood(long goodId)
        {
            var good = _mapper.Map<GoodViewModel>(
                await _shopService.GetGood(goodId));

            if (good == null)
            {
                return NoContent();
            }

            return Ok(good);
        }

        /// <summary>
        /// 以 ID 取得商品詳細資料
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("goods")]
        public async Task<List<GoodViewModel>> GetCartGoods([FromBody] GetCartGoodsRequestViewModel request)
        {
            return _mapper.Map<List<GoodViewModel>>(
                await _shopService.GetCartGoods(
                    _mapper.Map<GetCartGoodsRequestServiceModel>(request)));
        }

        /// <summary>
        /// 上架新商品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("good")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<GoodViewModel> CreateGood([FromBody] GoodViewModel request)
        {
            UserServiceModel user = (UserServiceModel)HttpContext.Items["User"]!;

            return _mapper.Map<GoodViewModel>(
                await _shopService.CreateGood(
                    user,
                    _mapper.Map<GoodServiceModel>(request)));
        }

        /// <summary>
        /// 更新商品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch("good")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<ActionResult<GoodViewModel>> UpdateGood([FromBody] GoodViewModel request)
        {
            UserServiceModel user = (UserServiceModel)HttpContext.Items["User"]!;
            try
            {
                return _mapper.Map<GoodViewModel>(
                    await _shopService.UpdateGood(
                        user,
                        _mapper.Map<GoodServiceModel>(request)));
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 下架 (刪除) 商品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("good")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<ActionResult<int>> DeleteGood([FromBody] GoodViewModel request)
        {
            try
            {
                return await _shopService.DeleteGood(
                    _mapper.Map<GoodServiceModel>(request));
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 儲存購物車內容
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("cart")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<bool> SaveCart([FromBody] SaveCartRequestViewModel request)
        {
            UserServiceModel user = (UserServiceModel)HttpContext.Items["User"]!;

            return await _shopService.SaveCart(
                _mapper.Map<SaveCartRequestServiceModel>(request), user);
        }

        /// <summary>
        /// 清除購物車
        /// </summary>
        /// <returns></returns>
        [HttpDelete("cart")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<int> ResetCart()
        {
            UserServiceModel user = (UserServiceModel)HttpContext.Items["User"]!;

            return await _shopService.ResetCart(user);
        }

        /// <summary>
        /// 以帳號 ID 取得已儲存購物車內容
        /// </summary>
        /// <returns></returns>
        [HttpGet("cart")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<List<CartViewModel>> GetSavedCartByUser()
        {
            UserServiceModel user = (UserServiceModel)HttpContext.Items["User"]!;

            return _mapper.Map<List<CartViewModel>>(
                await _shopService.GetSavedCartByUser(user));
        }
    }
}
