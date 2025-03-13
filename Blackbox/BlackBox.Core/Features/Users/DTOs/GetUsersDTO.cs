namespace BlackBox.Core.Features.Users.DTOs
{
    public class GetUsersDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}
