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
        public string Id { get; set; } = string.Empty;

        [Column("user_id")]
        public string UserId { get; set; } = string.Empty;

        [Column("s0_correct")] public int S0Correct { get; set; }
        [Column("s0_prozent")] public double S0Prozent { get; set; }
        [Column("s1_correct")] public int S1Correct { get; set; }
        [Column("s1_prozent")] public double S1Prozent { get; set; }
        [Column("s2_correct")] public int S2Correct { get; set; }
        [Column("s2_prozent")] public double S2Prozent { get; set; }
        [Column("s3_correct")] public int S3Correct { get; set; }
        [Column("s3_prozent")] public double S3Prozent { get; set; }
        [Column("s4_correct")] public int S4Correct { get; set; }
        [Column("s4_prozent")] public double S4Prozent { get; set; }
        [Column("s5_correct")] public int S5Correct { get; set; }
        [Column("s5_prozent")] public double S5Prozent { get; set; }

        public SubjectProgress[] ToSubjectArray()
        {
            return new SubjectProgress[]
            {
            new ShopSaveData { Quizzes_correct = S0Correct, Quizzes_prozent = S0Prozent }, //Müssen 
            new SubjectProgress { Quizzes_correct = S1Correct, Quizzes_prozent = S1Prozent },
            new SubjectProgress { Quizzes_correct = S2Correct, Quizzes_prozent = S2Prozent },
            new SubjectProgress { Quizzes_correct = S3Correct, Quizzes_prozent = S3Prozent },
            new SubjectProgress { Quizzes_correct = S4Correct, Quizzes_prozent = S4Prozent },
            new SubjectProgress { Quizzes_correct = S5Correct, Quizzes_prozent = S5Prozent },
            };
        }

        public void FromSubjectArray(SubjectProgress[] subjects)
        {
            S0Correct = subjects[0].Quizzes_correct; S0Prozent = subjects[0].Quizzes_prozent;
            S1Correct = subjects[1].Quizzes_correct; S1Prozent = subjects[1].Quizzes_prozent;
            S2Correct = subjects[2].Quizzes_correct; S2Prozent = subjects[2].Quizzes_prozent;
            S3Correct = subjects[3].Quizzes_correct; S3Prozent = subjects[3].Quizzes_prozent;
            S4Correct = subjects[4].Quizzes_correct; S4Prozent = subjects[4].Quizzes_prozent;
            S5Correct = subjects[5].Quizzes_correct; S5Prozent = subjects[5].Quizzes_prozent;
        }
    }
}