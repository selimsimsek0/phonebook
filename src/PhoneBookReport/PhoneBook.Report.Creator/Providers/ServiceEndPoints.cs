namespace PhoneBook.Report.Creator.Providers
{
    public static class ServiceEndPoints
    {
        public static class PhoneBookService
        {
            public static string Url => "http://localhost:5001/api/";
            public static string GetAllPerson => $"{Url}person";
            public static string GetAllPersonWithContacts => $"{Url}person/withcontactinfos";
        }
    }
}
