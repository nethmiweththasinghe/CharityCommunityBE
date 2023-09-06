namespace CharityCommunityBE.Models
{
    public class AdminDetails
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? NIC { get; set; }
        public string? ContactNo { get; set; }
        public string? Token { get; set; }
        public string? Role { get; set; }
    }
}
