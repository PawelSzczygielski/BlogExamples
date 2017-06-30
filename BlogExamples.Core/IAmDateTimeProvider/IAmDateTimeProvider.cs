using System;

namespace BlogExamples.Core
{
    public interface IAmDateTimeProvider
    {
        DateTime Now { get; set; }
    }

    public class DateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }

    public class TestDateTimeProvider
    {
        public TestDateTimeProvider(DateTime desiredTime)
        {
            Now = desiredTime;
        }

        public DateTime Now { get; set; }
    }
}