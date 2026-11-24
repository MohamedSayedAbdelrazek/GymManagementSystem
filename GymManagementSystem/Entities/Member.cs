namespace GymManagementSystem.Entities
{
    public class Member:GymUser
    {
        public string Photo { get; set; } = null!;

        #region Relationships

        public ICollection<Membership> MemberSubscriptions { get; set; } = new HashSet<Membership>();

        #endregion
    }
}
