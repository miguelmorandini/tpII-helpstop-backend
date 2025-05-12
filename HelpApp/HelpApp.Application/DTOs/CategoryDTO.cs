using System.ComponentModel.DataAnnotations;

namespace HelpApp.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(100)]
        [Required(ErrorMessage = "Invalid name, too short, minimum 3 characters.")]
        public string Name { get; set; }
        
    }
}
