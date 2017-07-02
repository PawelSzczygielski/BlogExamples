using NUnit.Framework;
using Smocks;
using System;
using System.Threading;

namespace BlogExamples.Tests.Fakes
{
    [TestFixture]
    public class FakesDateTimeTests
    {
        [Test]
        public void test()
        {
            Smock.Run(context =>
            {
                context.Setup(() => DateTime.Now).Returns(new DateTime(2000, 1, 1));

                var dateNow = DateTime.Now;
                Assert.That(dateNow, Is.EqualTo(new DateTime(3000, 1, 1)));
                Console.WriteLine("ttu");
                Thread.Sleep(2220);
            });
        }
    }
}
