namespace CharityCommunityBE.Models
{
    public class Volunteer
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string? Project { get; set; }
        public string? Description { get; set; }
        public string? Other { get; set; }
    }
}
