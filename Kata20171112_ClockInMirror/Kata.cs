using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata20171112_ClockInMirror
{
    [TestClass]
    public class Kata
    {
        [TestMethod]
        public void Input12_22ShouldReturn11_38()
        {
            //arrange
            //act
            AssertShouldBe("11:38", "12:22");
        }

        [TestMethod]
        public void Input12_01ShouldReturn11_59()
        {
            AssertShouldBe("11:59", "12:01");
        }

        [TestMethod]
        public void Input5_25ShouldRetrun6_35s()
        {
            AssertShouldBe("06:35", "05:25");
        }

        private void AssertShouldBe(string expect, string input)
        {
            var clockInMirror = new ClockInMirror();
            var actual = clockInMirror.ConvertToRealTime(input);
            //assert
            Assert.AreEqual(expect, actual);
        }
    }

    public class ClockInMirror
    {
        private int totalHours = 12 * 60;

        private string[] hourMapping = new[]
            {"12", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"};

        public string ConvertToRealTime(string input)
        {
            var hourAndMin = input.Split(':');
            if (hourAndMin[0] == "12")
            {
                hourAndMin[0] = "0";
            }
            var mirrorHours = Convert.ToInt32(hourAndMin[0]) * 60 + Convert.ToInt32(hourAndMin[1]);
            var realHours = totalHours - mirrorHours;
            var realHourAndMin = new []{ $"{hourMapping[realHours/60]}", $"{(realHours%60):D2}" };
            return string.Join(":", realHourAndMin);
        }
    }
}
