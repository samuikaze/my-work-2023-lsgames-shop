namespace LSGames.Shop.Api.Models.ServiceModels
{
    public class GoodServiceModel
    {
        /// <summary>
        /// 商品 PK
        /// </summary>
        public long GoodId { get; set; }

        /// <summary>
        /// 商品名稱
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 商品預覽圖
        /// </summary>
        public string PreviewImagee { get; set; } = null!;

        /// <summary>
        /// 商品描述
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 商品單價
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 在庫數量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 商品狀態
        /// </summary>
        public sbyte Status { get; set; }

        /// <summary>
        /// 建立帳號 PK
        /// </summary>
        public long? CreatedUserId { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// 最後更新帳號 PK
        /// </summary>
        public long? UpdatedUserId { get; set; }

        /// <summary>
        /// 最後更新時間
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
