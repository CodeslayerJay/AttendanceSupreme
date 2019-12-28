namespace AttendanceSupreme.Engine.Entities
{
    public class UserProfile : EntityBase
    {
        public int UserId { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string SecondaryPhone { get; set; }
        public virtual User User { get; set; }
    }
}