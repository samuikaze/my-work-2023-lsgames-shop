namespace LSGames.Shop.Api.Models.ViewModels
{
    public class SaveCartRequestViewModel
    {
        /// <summary>
        /// 購物車內容
        /// </summary>
        public List<CartGoodViewModel> Cart {  get; set; }
    }
}
