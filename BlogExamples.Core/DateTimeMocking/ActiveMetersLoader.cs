using System.Collections.Generic;

namespace BlogExamples.Core.DateTimeMocking
{
    public interface IAmActiveMetersLoader
    {
        List<long> ReloadAllActiveMeters();
    }
}
