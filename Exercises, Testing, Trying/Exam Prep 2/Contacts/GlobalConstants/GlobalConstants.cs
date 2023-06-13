namespace Contacts.GlobalConstants
{
    public static class GlobalConstants
    {

        public class ApplicationUserConstants
        {
            public const int UserNameMinLength=5;
            public const int UserNameMaxLength=20;

            public const int EmailMinLength=10;
            public const int EmailMaxLength=60;

            public const int PasswordMinLength=5;
            public const int PasswordMaxLength=20;
        }

        public class ContactConstants
        {
            public const int FirstNameMinLength=2;
            public const int FirstNameMaxLength=50;

            public const int LastNameMinLength=1;
            public const int LastNameMaxLength=20;

            public const int EmailMinLegnth=10;
            public const int EmailMaxLegnth=60;

            public const int PhoneMaxLength=14;
            public const string RegexPhoneValidator=@"^(?:\+359|0)(?:(?:\s?\d{3}|\-\d{3}|\d{3})(?:\s|\-)?\d{2}(?:\s|\-)?\d{2}(?:\s|\-)?\d{2})$";

            public const string RegexWebsiteValidator=@"^www\.[a-zA-Z0-9\-]+\.bg$";

        }



    }
}
