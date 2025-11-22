// Mraketplace.Presention/DTOs/RequestModels/EditRequestModel.cs
namespace Mraketplace.Presention.DTOs.RequestModels
{
    public class EditRequestModel
    {
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}