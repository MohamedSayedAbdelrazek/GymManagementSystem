using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagementSystem.Entities
{
    public class Membership:BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        #region Relationships

        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;

        public int PlanId { get; set; }
        public Plan Plan { get; set; } = null!;

        [NotMapped]
        public string Status => StartDate > DateTime.Now ? "UpComing" :
                                EndDate > DateTime.Now ? "Active" :
                                "Expired";
        #endregion
    }
}
