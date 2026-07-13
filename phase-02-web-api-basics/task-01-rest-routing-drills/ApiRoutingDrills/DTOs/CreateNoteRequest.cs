using System.ComponentModel.DataAnnotations;

namespace ApiRoutingDrills.DTOs
{
    public class CreateNoteRequest
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title {get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;
    }
}
