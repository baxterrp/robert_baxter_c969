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
        c.customerId AS Id,
        c.customerName AS Name,
        a.address AS AddressLine1,
        a.address2 AS AddressLine2,
        a.phone AS PhoneNumber,
        a.postalCode AS ZipCode,
        ci.city AS City,
        co.country AS Country
    FROM customer c
        INNER JOIN address a
            on c.addressId = a.addressId
        INNER JOIN city ci
            on a.cityId = ci.cityId
        INNER JOIN country co
            on ci.countryId = co.countryId
";
        public static string GetAppointmentsByUserId =
@"
    SELECT 
        a.appointmentId AS Id,
        a.title AS Title,
        a.description AS Description,
        a.location AS Location,
        a.contact AS Contact,
        a.type AS Type,
        a.start AS StartTime,
        a.end AS EndTime,
        c.customerName AS Customer
    FROM appointment a
        INNER JOIN customer c
            ON a.customerId = c.customerId
    WHERE a.userId = @UserId
";
        public static string CheckUpcomingAppointments =
            "SELECT IF((SELECT Count(*) FROM appointment WHERE start > DATE_SUB(NOW(), INTERVAL 15 MINUTE)), 1, 0)";
    }
}
