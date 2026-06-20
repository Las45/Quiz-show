using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
namespace Quiz_show.src.Klassen
{
    // KI Anfang:
    // Model: Claude, Promt: Wie können wir den progress.json pro user auf superbase free server speichern (Es wurden ein paar files beigelegt)
    [Table("user_progress")]
    public class UserProgressModel : BaseModel
    {
        [PrimaryKey("user_id", false)]
        public string UserId { get; set; }

        [Column("progress_data")]
        public string ProgressData { get; set; }
    }
}