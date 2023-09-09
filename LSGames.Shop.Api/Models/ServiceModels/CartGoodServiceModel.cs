namespace LSGames.Shop.Api.Models.ServiceModels
{
    public class CartGoodServiceModel
    {
        /// <summary>
        /// 商品 PK
        /// </summary>
        public long GoodId { get; set; }
        /// <summary>
        /// 數量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 商品單價
        /// </summary>
        public decimal Price { get; set; }
    }
}
