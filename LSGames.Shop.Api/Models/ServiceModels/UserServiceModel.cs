namespace LSGames.Shop.Api.Models.ServiceModels
{
    public class UserServiceModel
    {
        /// <summary>
        /// 使用者帳號 PK
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 使用者帳號
        /// </summary>
        public string? Account { get; set; }
        /// <summary>
        /// 暱稱
        /// </summary>
        public string? Username { get; set; }
        /// <summary>
        /// 電子郵件地址
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// 虛擬形象圖檔路徑
        /// </summary>
        public string? virtualAvator { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public List<RoleServiceModel>? Roles { get; set; }
        /// <summary>
        /// 權限
        /// </summary>
        public List<AbilityServiceModel>? Abilities { get; set; }
        /// <summary>
        /// 電子郵件地址驗證時間
        /// </summary>
        public DateTime? emailVerifiedAt { get; set; }
        /// <summary>
        /// 註冊時間
        /// </summary>
        public DateTime? RegisteredAt { get; set; }
        /// <summary>
        /// 最後更新時間
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
