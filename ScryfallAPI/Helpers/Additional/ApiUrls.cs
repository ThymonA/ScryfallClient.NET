namespace ScryfallAPI
{
    using System;

    public static class ApiUrls
    {
        public static Uri Set(long id)
        {
            return "sets/{0}".FormatUri(id);
        }

        public static Uri Set(string code)
        {
            return "sets/{0}".FormatUri(code);
        }

        public static Uri Sets()
        {
            return "sets/".FormatUri();
        }
    }
}
