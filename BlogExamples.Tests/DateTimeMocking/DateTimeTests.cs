using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BlogExamples.Core.DateTimeMocking;

namespace BlogExamples.Tests
{
    [TestClass]
    public class DateTimeTests
    {
        [TestMethod]
        public void Meters_Are_Checked_In_Desired_Time()
        {
            var meterLoader = new Mock<IAmActiveMetersLoader>();
            var sut = new SystemTimeDependendProductionCode(meterLoader.Object);

            sut.DoPeriodicCheckIfNeeded();

            meterLoader.Verify(x => x.ReloadAllActiveMeters(), Times.Exactly(1));
        }
    }
}
