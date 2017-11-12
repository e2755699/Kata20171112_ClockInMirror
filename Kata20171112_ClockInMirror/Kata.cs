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
            var input = "12:22";
            var expect = "11:38";
            //act
            AssertShouldBe(expect, input);
        }

        private void AssertShouldBe(string expect, string input)
        {
            var clockInMirror = new ClockInMirror();
            var actual = clockInMirror.ConvertToRealTime(input);
            //assert
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Input12_01ShouldReturn11_59()
        {
            AssertShouldBe("11:59", "12:01");
        }

        [TestMethod]
        public void Input5_25ShouldRetrun6_35s()
        {
            AssertShouldBe("6:35", "5:25");
        }
    }

    public class ClockInMirror
    {
        public String ConvertToRealTime(string input)
        {
            var totalHours = 12 * 60;
            var hourAndMin = input.Split(':');
            if (hourAndMin[0] == "12")
            {
                hourAndMin[0] = "0";
            }
            var mirrorHours = Convert.ToInt32(hourAndMin[0]) * 60 + Convert.ToInt32(hourAndMin[1]);
            var realHours = totalHours - mirrorHours;
            var realHourAndMin = new string[]{ $"{realHours/60}", $"{realHours%60}" };
            if (realHourAndMin[0] == "12")
            {
                return $"00:{realHourAndMin[1]}";
            }
            return string.Join( ":", realHourAndMin);
        }
    }
}
