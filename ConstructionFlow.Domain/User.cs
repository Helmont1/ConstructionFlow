namespace ConstructionFlowAPI.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; } 
        public required Role RoleName { get; set; }
    }
}
