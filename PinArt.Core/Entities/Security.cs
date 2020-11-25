using PinArt.Core.Enumerations;

namespace PinArt.Core.Entities
{
    public class Security
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public RoleType Role { get; set; }
    }
}
