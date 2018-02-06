using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InAsync.PublicHolidays.JP.Tests {

    [TestClass]
    public class PublicHolidayExtensionsTest {

        [TestMethod]
        public void IsPublicHoliday_Test() {
            var testDataSource = new[] {
                ((PublicHoliday)0           , false),
                ((PublicHoliday)int.MinValue, false),
                ((PublicHoliday)int.MaxValue, false),
                (PublicHoliday.None         , false),
                (PublicHoliday.元日         , true),
                (PublicHoliday.成人の日     , true),
                (PublicHoliday.建国記念の日 , true),
                (PublicHoliday.春分の日     , true),
                (PublicHoliday.昭和の日     , true),
                (PublicHoliday.憲法記念日   , true),
                (PublicHoliday.みどりの日   , true),
                (PublicHoliday.こどもの日   , true),
                (PublicHoliday.海の日       , true),
                (PublicHoliday.山の日       , true),
                (PublicHoliday.敬老の日     , true),
                (PublicHoliday.秋分の日     , true),
                (PublicHoliday.体育の日     , true),
                (PublicHoliday.文化の日     , true),
                (PublicHoliday.勤労感謝の日 , true),
                (PublicHoliday.天皇誕生日   , true),
                (PublicHoliday.Transfer     , true),
                (PublicHoliday.Citizens     , true),
            };

            foreach ((var holiday, var expected) in testDataSource) {
                PublicHolidayExtensions.IsPublicHoliday(holiday).Is(expected, $"{holiday}");
            }
        }

        [TestMethod]
        public void IsNationalHoliday_Test() {
            var testDataSource = new[] {
                ((PublicHoliday)0           , false),
                ((PublicHoliday)int.MinValue, false),
                ((PublicHoliday)int.MaxValue, false),
                (PublicHoliday.None         , false),
                (PublicHoliday.元日         , true),
                (PublicHoliday.成人の日     , true),
                (PublicHoliday.建国記念の日 , true),
                (PublicHoliday.春分の日     , true),
                (PublicHoliday.昭和の日     , true),
                (PublicHoliday.憲法記念日   , true),
                (PublicHoliday.みどりの日   , true),
                (PublicHoliday.こどもの日   , true),
                (PublicHoliday.海の日       , true),
                (PublicHoliday.山の日       , true),
                (PublicHoliday.敬老の日     , true),
                (PublicHoliday.秋分の日     , true),
                (PublicHoliday.体育の日     , true),
                (PublicHoliday.文化の日     , true),
                (PublicHoliday.勤労感謝の日 , true),
                (PublicHoliday.天皇誕生日   , true),
                (PublicHoliday.Transfer     , false),
                (PublicHoliday.Citizens     , false),
            };

            foreach ((var holiday, var expected) in testDataSource) {
                PublicHolidayExtensions.IsNationalHoliday(holiday).Is(expected, $"{holiday}");
            }
        }

        [TestMethod]
        public void IsTransferHoliday_Test() {
            var testDataSource = new[] {
                ((PublicHoliday)0           , false),
                ((PublicHoliday)int.MinValue, false),
                ((PublicHoliday)int.MaxValue, false),
                (PublicHoliday.None         , false),
                (PublicHoliday.元日         , false),
                (PublicHoliday.成人の日     , false),
                (PublicHoliday.建国記念の日 , false),
                (PublicHoliday.春分の日     , false),
                (PublicHoliday.昭和の日     , false),
                (PublicHoliday.憲法記念日   , false),
                (PublicHoliday.みどりの日   , false),
                (PublicHoliday.こどもの日   , false),
                (PublicHoliday.海の日       , false),
                (PublicHoliday.山の日       , false),
                (PublicHoliday.敬老の日     , false),
                (PublicHoliday.秋分の日     , false),
                (PublicHoliday.体育の日     , false),
                (PublicHoliday.文化の日     , false),
                (PublicHoliday.勤労感謝の日 , false),
                (PublicHoliday.天皇誕生日   , false),
                (PublicHoliday.Transfer     , true),
                (PublicHoliday.Citizens     , false),
            };

            foreach ((var holiday, var expected) in testDataSource) {
                PublicHolidayExtensions.IsTransferHoliday(holiday).Is(expected, $"{holiday}");
            }
        }

        [TestMethod]
        public void IsCitizensHoliday_Test() {
            var testDataSource = new[] {
                ((PublicHoliday)0           , false),
                ((PublicHoliday)int.MinValue, false),
                ((PublicHoliday)int.MaxValue, false),
                (PublicHoliday.None         , false),
                (PublicHoliday.元日         , false),
                (PublicHoliday.成人の日     , false),
                (PublicHoliday.建国記念の日 , false),
                (PublicHoliday.春分の日     , false),
                (PublicHoliday.昭和の日     , false),
                (PublicHoliday.憲法記念日   , false),
                (PublicHoliday.みどりの日   , false),
                (PublicHoliday.こどもの日   , false),
                (PublicHoliday.海の日       , false),
                (PublicHoliday.山の日       , false),
                (PublicHoliday.敬老の日     , false),
                (PublicHoliday.秋分の日     , false),
                (PublicHoliday.体育の日     , false),
                (PublicHoliday.文化の日     , false),
                (PublicHoliday.勤労感謝の日 , false),
                (PublicHoliday.天皇誕生日   , false),
                (PublicHoliday.Transfer     , false),
                (PublicHoliday.Citizens     , true),
            };

            foreach ((var holiday, var expected) in testDataSource) {
                PublicHolidayExtensions.IsCitizensHoliday(holiday).Is(expected, $"{holiday}");
            }
        }
    }
}