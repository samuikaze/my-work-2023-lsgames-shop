using LSGames.Shop.Api.Models.ViewModels;

namespace LSGames.Shop.Api.Models.ServiceModels
{
    public class SaveCartRequestServiceModel
    {
        /// <summary>
        /// 購物車內容
        /// </summary>
        public List<CartGoodServiceModel> Cart { get; set; }
    }
}
