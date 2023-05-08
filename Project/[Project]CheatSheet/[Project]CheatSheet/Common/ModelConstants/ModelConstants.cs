namespace _Project_CheatSheet.Common.ModelConstants
{
    public static class ModelConstants
    {
        public const string dateFormatter = "dd/MM/yyyy HH:mm";

        //Users

        public const int UserNameMinLength = 4;
        public const int UserNameMaxLength = 20;

        public const int UserEmailMinLength = 8;
        public const int UserEmailMaxLength = 45;

        public const int UserPasswordMinLength = 8;
        public const int UserPasswordMaxLength = 25;


        public const int UserDescriptionMinLength = 3;
        public const int UserDescriptionMaxLength = 500;

        public const int UserBackGroundImageMinLength = 10;
        public const int UserBackGroundImageMaxLength = 100;

        public const int UserEducationMinLength = 2;
        public const int UserEducationMaxLength = 50;

        public const int UserJobMinLength = 2;
        public const int UserJobMaxLength = 50;

        //Resources
        public const int ResourceTitleMinLength = 5;
        public const int ResourceTitleMaxLength = 60;

        public const int ResourceImageUrlMinLength = 20;
        public const int ResourceImageUrlMaxLength = 300;

        public const int ResourceContentMinLength = 25;
        public const int ResourceContentMaxLength = 5000;


        //Comments
        public const int CommentsMinLength = 10;
        public const int CommentsMaxLength = 500;

        //Categories
        public const int CategoryNameMinCategory = 5;
        public const int CategoryNameMaxCategory = 50;



    }
}
