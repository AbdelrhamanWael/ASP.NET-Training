using System.ComponentModel.DataAnnotations;

namespace ApiRoutingDrills.DTOs
{
    public class UpdateNoteRequest
    {
        // Requirement: Validate title and content are required
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; } = string.Empty;
    }
}
