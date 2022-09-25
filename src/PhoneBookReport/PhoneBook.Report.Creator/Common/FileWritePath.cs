namespace PhoneBook.Report.Creator.Common
{
    public static class FileWritePath
    {
        public static string Path => "C:";
        public static string MainFolder => "PhoneBookReports";
        public static string LocationReportFolder => "LocationReports";
        public static string GetFullPath(params string[] paths)
        {
            return System.IO.Path.Combine(paths);
        }
    }
}
