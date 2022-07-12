using System.ComponentModel.DataAnnotations;

namespace PAS.Application.Dto.Account
{
    public class EditAdminDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
