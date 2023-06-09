namespace Library.GlobalConstants
{
    public static class GlobalConstants
    {

        public class BookConstants
        {
            public const int BookTitleMinLength = 10;
            public const int BookTitleMaxLength = 50;

            public const int BookAuthorMinLength = 5;
            public const int BookAuthorMaxLength = 50;

            public const int BookDescriptionMinLength = 5;
            public const int BookDescriptionMaxLength = 5000;

            public const double BookRatingMin = 0.0;
            public const double BookRatingMax = 10.0;

        }

        public class CategoryConstants
        {
            public const int CategoryNameMinLength = 5;
            public const int CategoryNameMaxLength = 50;
        }



    }
}
