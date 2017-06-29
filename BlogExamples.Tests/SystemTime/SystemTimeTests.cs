using System;
using Moq;
using BlogExamples.Core.DateTimeMocking;
using NUnit.Framework;

namespace BlogExamples.Tests
{
    [TestFixture]
    public class SystemTimeTests
    {
        [Test]
        public void Meters_Are_Checked_In_Desired_Time()
        {
            //Sets current time to 2016/05/05 21:34:00
            SystemTime.SetNow(new DateTime(2016,5,5,21,34,00)); 
            var meterLoader = new Mock<IAmActiveMetersLoader>();
            var sut = new SystemTimeDependendProductionCode(meterLoader.Object);
            
            sut.DoPeriodicCheckIfNeeded();

            //System check should occur after 22:00, so at 21:34 there should 
            //be no invocations of ReloadAllActiveMeters
            meterLoader.Verify(x => x.ReloadAllActiveMeters(), Times.Exactly(0));


            //We're moving time forward, to the threshold hour: 22:00
            SystemTime.SetNow(new DateTime(2016, 5, 5, 22, 00, 00));
            sut.DoPeriodicCheckIfNeeded();
            //Still, no invocation should occur
            meterLoader.Verify(x => x.ReloadAllActiveMeters(), Times.Exactly(0));

            //Minute after 22:00
            SystemTime.SetNow(new DateTime(2016, 5, 5, 22, 01, 00));
            sut.DoPeriodicCheckIfNeeded();
            //Method should be called
            meterLoader.Verify(x => x.ReloadAllActiveMeters(), Times.Exactly(1));

            //Clean up in order to conduct other tests
            SystemTime.ResetNow();
        }
    }
}
