using System;

namespace BlogExamples.Core.DateTimeMocking
{
    public static class SystemTime
    {
        public static DateTime Now = DateTime.Now;

        public static void SetNow(DateTime today)
        {
            Now = today;
        }

        public static void ResetNow()
        {
            Now = DateTime.Now;
        }
    }
}
