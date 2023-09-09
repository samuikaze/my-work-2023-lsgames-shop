namespace LSGames.Shop.Api.Models.ViewModels
{
    public class CartViewModel
    {
        /// <summary>
        /// 購物車 PK
        /// </summary>
        public long CartId { get; set; }

        /// <summary>
        /// 帳號 PK
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 商品 PK
        /// </summary>
        public long GoodId { get; set; }

        /// <summary>
        /// 商品數量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 商品單價
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// 最後更新時間
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
