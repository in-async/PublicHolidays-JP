using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InAsync.PublicHolidays.JP.Tests {

    public static class ObjectExtensions {

        public static void Is(this object actual, object expected, string error = null) {
            Assert.AreEqual(expected, actual, $"{new { actual, expected }}\n{error}");
        }
    }
}