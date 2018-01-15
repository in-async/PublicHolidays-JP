using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InAsync.PublicHolidays.JP.Tests {

    [TestClass]
    public class PublicHolidaysTest {

        [TestMethod]
        public void GetNationalHoliday_Test() {
            foreach ((var date, var name) in TestDataSource) {
                if (Enum.TryParse<NationalHoliday>(name, out var expected) == false) {
                    expected = NationalHoliday.None;
                }

                PublicHolidays.GetNationalHoliday(date).Is(expected, $"{date:yyyy/MM/dd}");
            }
        }

        [TestMethod]
        public void IsHoliday_Test() {
            foreach ((var date, var name) in TestDataSource) {
                var expected = name != "";

                PublicHolidays.IsHoliday(date).Is(expected, $"{date:yyyy/MM/dd}");
            }
        }

        [TestMethod]
        public void IsNationalHoliday_Test() {
            foreach ((var date, var name) in TestDataSource) {
                var expected = Enum.TryParse<NationalHoliday>(name, out _);

                PublicHolidays.IsNationalHoliday(date).Is(expected, $"{date:yyyy/MM/dd}");
            }
        }

        [TestMethod]
        public void IsTransferHoliday_Test() {
            foreach ((var date, var name) in TestDataSource) {
                var expected = name == "振替休日";
                PublicHolidays.IsTransferHoliday(date).Is(expected, $"{date:yyyy/MM/dd}");
            }
        }

        [TestMethod]
        public void IsCitizensHoliday_Test() {
            foreach ((var date, var name) in TestDataSource) {
                var expected = name == "国民の休日";
                PublicHolidays.IsCitizensHoliday(date).Is(expected, $"{date:yyyy/MM/dd}");
            }
        }

        private static IEnumerable<string[]> ParseTestDataSource(string source) {
            return source
                .Trim()
                .Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(l => l.Trim().Split(','));
        }

        private static readonly IReadOnlyList<(DateTime Date, string Name)> TestDataSource = ParseTestDataSource(@"
2015/01/01,元日
2015/01/12,成人の日
2015/02/11,建国記念の日
2015/03/21,春分の日
2015/04/29,昭和の日
2015/05/03,憲法記念日
2015/05/04,みどりの日
2015/05/05,こどもの日
2015/05/06,振替休日
2015/07/20,海の日
2015/09/21,敬老の日
2015/09/22,国民の休日
2015/09/23,秋分の日
2015/10/12,体育の日
2015/11/03,文化の日
2015/11/23,勤労感謝の日
2015/12/23,天皇誕生日
2016/01/01,元日
2016/01/11,成人の日
2016/02/11,建国記念の日
2016/03/20,春分の日
2016/03/21,振替休日
2016/04/29,昭和の日
2016/05/03,憲法記念日
2016/05/04,みどりの日
2016/05/05,こどもの日
2016/07/18,海の日
2016/08/11,山の日
2016/09/19,敬老の日
2016/09/22,秋分の日
2016/10/10,体育の日
2016/11/03,文化の日
2016/11/23,勤労感謝の日
2016/12/23,天皇誕生日
2017/01/01,元日
2017/01/02,振替休日
2017/01/09,成人の日
2017/02/11,建国記念の日
2017/03/20,春分の日
2017/04/29,昭和の日
2017/05/03,憲法記念日
2017/05/04,みどりの日
2017/05/05,こどもの日
2017/07/17,海の日
2017/08/11,山の日
2017/09/18,敬老の日
2017/09/23,秋分の日
2017/10/09,体育の日
2017/11/03,文化の日
2017/11/23,勤労感謝の日
2017/12/23,天皇誕生日
2018/01/01,元日
2018/01/08,成人の日
2018/02/11,建国記念の日
2018/02/12,振替休日
2018/03/21,春分の日
2018/04/29,昭和の日
2018/04/30,振替休日
2018/05/03,憲法記念日
2018/05/04,みどりの日
2018/05/05,こどもの日
2018/07/16,海の日
2018/08/11,山の日
2018/09/17,敬老の日
2018/09/23,秋分の日
2018/09/24,振替休日
2018/10/08,体育の日
2018/11/03,文化の日
2018/11/23,勤労感謝の日
2018/12/23,天皇誕生日
2018/12/24,振替休日
2019/01/01,元日
2019/01/14,成人の日
2019/02/11,建国記念の日
2019/03/21,春分の日
2019/04/29,昭和の日
2019/05/03,憲法記念日
2019/05/04,みどりの日
2019/05/05,こどもの日
2019/05/06,振替休日
2019/07/15,海の日
2019/08/11,山の日
2019/08/12,振替休日
2019/09/16,敬老の日
2019/09/23,秋分の日
2019/10/14,体育の日
2019/11/03,文化の日
2019/11/04,振替休日
2019/11/23,勤労感謝の日
2019/12/23,天皇誕生日
2020/01/01,元日
2020/01/13,成人の日
2020/02/11,建国記念の日
2020/03/20,春分の日
2020/04/29,昭和の日
2020/05/03,憲法記念日
2020/05/04,みどりの日
2020/05/05,こどもの日
2020/05/06,振替休日
2020/07/20,海の日
2020/08/11,山の日
2020/09/21,敬老の日
2020/09/22,秋分の日
2020/10/12,体育の日
2020/11/03,文化の日
2020/11/23,勤労感謝の日
2020/12/23,天皇誕生日

2018/01/16,
").Select(p => (DateTime.Parse(p[0]), p[1])).ToArray();
    }
}