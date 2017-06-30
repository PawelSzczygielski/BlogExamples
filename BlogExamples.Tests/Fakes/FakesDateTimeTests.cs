using FakeItEasy;
using NUnit.Framework;
using System;

namespace BlogExamples.Tests.Fakes
{
    [TestFixture]
    public class FakesDateTimeTests
    {
        [Test]
        public void test()
        {
            var data = DateTime.Now;
            A.CallTo(() => DateTime.Now).Returns(new DateTime(2017, 5, 5, 22, 34, 12));
            var datas = DateTime.Now;
        }
    }
}
