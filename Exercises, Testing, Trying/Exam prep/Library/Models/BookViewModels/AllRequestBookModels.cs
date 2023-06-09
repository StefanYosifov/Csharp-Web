namespace Library.Models.BookViewModels
{
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.GlobalConstants.BookConstants;

    public class AllRequestBookModels
    {
        public int Id { get; set; }

        [Required]
        [StringLength(BookTitleMaxLength,MinimumLength = BookTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(BookAuthorMaxLength,MinimumLength = BookAuthorMinLength)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(BookDescriptionMaxLength,MinimumLength = BookDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(BookRatingMin,BookRatingMax)]
        public decimal Rating { get; set; }

        [Required] 
        [Url]
        public string ImageUrl { get; set; } = null!;

        [Required] public string Category { get; set; } = null!;
    }
}