using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
namespace Quiz_show.src.Klassen
{
    // KI Anfang:
    // Model: Claude, Promt: Wie können wir den progress.json pro user auf superbase free server speichern (Es wurden ein paar files beigelegt)
    [Table("user_progress")]
    public class UserProgressModel : BaseModel
    {
        [PrimaryKey("id", false)]
        public string? Id { get; set; }

        [Column("user_id")]
        public string? UserId { get; set; }

        [Column("progress_data")]
        public string? ProgressData { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
    // Ki Ende
}