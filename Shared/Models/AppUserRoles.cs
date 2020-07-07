namespace DeliveryService.Shared.Models
{
    public class AppUserRoles
    {
        public int AppRoleId { get; set; }
        public long AppUserId { get; set; }

        public AppUser AppUser { get; set; }
        public AppRoles AppRole { get; set; }
    }
}
