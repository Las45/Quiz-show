using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Quiz_show.src.Klassen
{
    // Ki Anfang:
    // Model: Gemini; Promt: könnten wir bitte das gleiche wie beim progress mit dem Shop file machen
    [Table("user_shop")]
    public class ShopSaveDataModel : BaseModel
    {
        [PrimaryKey("user_id", false)]
        public string UserId { get; set; }

        [Column("shop_data")]
        public string ShopData { get; set; }
    }
}