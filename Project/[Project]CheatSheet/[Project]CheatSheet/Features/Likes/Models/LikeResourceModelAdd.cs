using System.ComponentModel.DataAnnotations;

namespace _Project_CheatSheet.Features.Likes.Models
{
    public class LikeResourceModelAdd
    {
        [Required] public string ResourceId { get; set; } = null!;
    }
}