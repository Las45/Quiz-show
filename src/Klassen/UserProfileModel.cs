using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;

namespace Quiz_show.src.Klassen
{
    [Table("user_profiles")]
    public class UserProfileModel : BaseModel
    {
        [PrimaryKey("user_id", false)]
        public string UserId { get; set; }

        [Column("money")]
        public double Money { get; set; }

        [Column("aktiver_button")]
        public int AktiverButton { get; set; }

        [Column("aktiver_background")]
        public int AktiverBackground { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}