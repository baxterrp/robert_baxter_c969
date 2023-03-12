namespace robert_baxter_c969
{
    public static class Constants
    {
        // login validation messages
        public static string InvalidPasswordSpanish = "El nombre de usuario y la contraseña no coincidían.";
        public static string InvalidPasswordEnglish = "The username and password did not match.";

        // culture info
        public static string EnglishCultureInfo = "en-US";
        public static string SpanishCultureInfo = "es-MX";

        // character masking
        public static char PasswordMaskCharacter = '*';

        // character validation
        public static int FortyCharacterTextLimit = 40;

        // system info
        public static string SystemName = "Client_Schedule_System";

        // queries
        public static string GetAllCustomers =
@"
    SELECT 
        c.customerId as Id,
        c.customerName as Name,
        a.address as AddressLine1,
        a.address2 as AddressLine2,
        a.phone as PhoneNumber,
        a.postalCode as ZipCode,
        ci.city as City,
        co.country as Country
    FROM customer c
        INNER JOIN address a
            on c.addressId = a.addressId
        INNER JOIN city ci
            on a.cityId = ci.cityId
        INNER JOIN country co
            on ci.countryId = co.countryId
";
    }
}
