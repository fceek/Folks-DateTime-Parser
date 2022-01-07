namespace FolksDatetimeParser
{
    public static class Dict
    {

        public static char[] SKIP =
        {
            ' ',
            ',',
            '儿',
        };

        public static string[] SPECIAL_DATETIME =
        {
            // todo
        };

        public static string[] SEC =
        {

        };

        public static string[] MIN =
        {

        };

        public static string[] HOUR =
        {

        };

        public static string[] DAY =
        {

        };

        public static string[] WEEK =
        {

        };

        public static string[] MONTH =
        {

        };

        public static string[] YEAR =
        {

        };

        public static string[][] TOKENS =
        {
            YEAR,MONTH,WEEK,DAY,HOUR,MIN,SEC
        };

        public static string[] TIME_SUFFIX =
        {
            "后",
            "前",
            "之后",
            "以后",
            "之前",
            "以前"
        };
    }
}
