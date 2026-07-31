using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;

namespace Quiz_show.src.Klassen
{
    [Table("user_shop_items")]
    public class UserShopItemModel : BaseModel
    {
        [PrimaryKey("id", false)]
        public long Id { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }

        [Column("item_id")]
        public int ItemId { get; set; }

        [Column("unlocked_at")]
        public DateTime UnlockedAt { get; set; }
    }
}