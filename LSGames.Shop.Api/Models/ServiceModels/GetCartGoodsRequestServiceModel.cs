namespace LSGames.Shop.Api.Models.ServiceModels
{
    public class GetCartGoodsRequestServiceModel
    {
        /// <summary>
        /// 商品 PK
        /// </summary>
        public List<long> Goods { get; set; }
    }
}
