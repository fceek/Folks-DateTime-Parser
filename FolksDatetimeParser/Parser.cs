namespace FolksDatetimeParser
{
    public static class Parser
    {
        public static bool TryParse(string raw, out DateTime dateTime)
        {
            string rawBak = raw;
            raw.Sieve();
            SyntacticRaw pass1 = raw.Extract();

            // Don't mind me
            dateTime = DateTime.Now;
            return true;
        }

        private static void Sieve(this string raw)
        {
            foreach (char skiped in Dict.SKIP)
            {
                raw.Replace(skiped, '\0');
            }
        }

        private static SyntacticRaw Extract(this string raw)
        {
            SyntacticRaw pass1 = new SyntacticRaw();
            bool canExtract = true;
            while (canExtract)
            {
                canExtract = raw.ExtractFirstTimeSpan(out TimeSpans type);
                // inject syntacticRaw with this type.
            }

            return pass1;
        }

        private static bool ExtractFirstTimeSpan(this string raw, out TimeSpans type)
        {
            string currentSpan = string.Empty;
            for (int i = 0; i < raw.Length; i++)
            {
                for (int j = 0; j < Dict.TOKENS.Length; j++)
                {
                    if (Dict.TOKENS[j].Contains(raw[i].ToString()))
                    {
                        currentSpan = raw.Substring(0, i + 1);
                        raw = raw.Substring(i + 1);
                        foreach (string s in Dict.TIME_SUFFIX)
                        {
                            if (raw.StartsWith(s, StringComparison.Ordinal))
                            {
                                raw = raw.Substring(s.Length);
                                currentSpan += s;
                            }
                        }
                        type = (TimeSpans)j;
                        return true;
                    }
                }
            }

            type = TimeSpans.Unknown;
            return false;
        }

        private struct SyntacticRaw
        {
            private string? rawYear;
            private string? rawMonth;
            private string? rawWeek;
            private string? rawDay;
            private string? rawHour;
            private string? rawMinute;
            private string? rawSecond;
        }

        private enum TimeSpans
        {
            Year,
            Month,
            Week,
            Day,
            Hour,
            Minute,
            Second,
            Unknown = -1
        }
    }
}