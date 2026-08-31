using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Quiz_show.src.Klassen
{
    [Table("user_progress")]
    public class UserProgressModel : BaseModel
    {
        [PrimaryKey("id", false)]
        public long Id { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }

        [Column("subject_index")]
        public int SubjectIndex { get; set; }

        [Column("progress_data")]
        public string ProgressData { get; set; }

        [Column("time_stamp")]
        public DateTime TimeStamp { get; set; }
    }
}