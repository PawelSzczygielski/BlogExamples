using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BlogExamples.Core.DateTimeMocking;
using System.Collections.Generic;

namespace BlogExamples.Tests
{
    [TestClass]
    public class DateTimeTests
    {
        [TestMethod]
        public void Meters_Are_Checked_In_Desired_Time()
        {
            var meterLoader = new Mock<IAmActiveMetersLoader>();
            meterLoader.Setup(x => x.ReloadAllActiveMeters()).Returns(() => new List<long> { 1, 2, 3 });
            var sut = PrepareSystemUnderTest(meterLoader);
            sut.DoPeriodicCheckIfNeeded();

            meterLoader.Verify(x => x.ReloadAllActiveMeters(), Times.Exactly(1));
        }

        private DateTimeDependendProductionCode PrepareSystemUnderTest(Mock<IAmActiveMetersLoader> meterLoader)
        {
            return new DateTimeDependendProductionCode(meterLoader.Object);
        }
    }
}
