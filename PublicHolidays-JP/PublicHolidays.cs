using System;

namespace InAsync.PublicHolidays.JP {

    /// <summary>
    /// [国民の祝日について - 内閣府](http://www8.cao.go.jp/chosei/shukujitsu/gaiyou.html)
    /// 2007年よりサポート。
    /// </summary>
    public static class PublicHolidays {

        public static NationalHoliday GetNationalHoliday(this DateTime date) {
            if (date.Year <= 2006) throw new ArgumentOutOfRangeException(nameof(date), "Not supported before 2006");

            switch (date.Month) {
                case 1:
                    // 元日	1月1日	年のはじめを祝う。
                    if (date.Day == 1) {
                        return NationalHoliday.元日;
                    }

                    // 成人の日	1月の第2月曜日	おとなになったことを自覚し、みずから生き抜こうとする青年を祝いはげます。
                    if (date.DayOfWeek == DayOfWeek.Monday && date.WeekOfMonth() == 2) {
                        return NationalHoliday.成人の日;
                    }
                    break;

                case 2:
                    // 建国記念の日	2月11日	建国をしのび、国を愛する心を養う。
                    if (date.Day == 11) {
                        return NationalHoliday.建国記念の日;
                    }
                    break;

                case 3:
                    // 春分の日	春分日	自然をたたえ、生物をいつくしむ。
                    if (date.Day == EquinoxCalculator.GetVernalEquinox(date.Year)) {
                        return NationalHoliday.春分の日;
                    }
                    break;

                case 4:
                    // 昭和の日	4月29日	激動の日々を経て、復興を遂げた昭和の時代を顧み、国の将来に思いをいたす。
                    if (date.Day == 29) {
                        return NationalHoliday.昭和の日;
                    }

                    break;

                case 5:
                    // 憲法記念日	5月3日	日本国憲法の施行を記念し、国の成長を期する。
                    if (date.Day == 3) {
                        return NationalHoliday.憲法記念日;
                    }

                    // みどりの日	5月4日	自然に親しむとともにその恩恵に感謝し、豊かな心をはぐくむ。
                    if (date.Day == 4) {
                        return NationalHoliday.みどりの日;
                    }

                    // こどもの日	5月5日	こどもの人格を重んじ、こどもの幸福をはかるとともに、母に感謝する。
                    if (date.Day == 5) {
                        return NationalHoliday.こどもの日;
                    }
                    break;

                case 6:
                    break;

                case 7:
                    // 海の日	7月の第3月曜日	海の恩恵に感謝するとともに、海洋国日本の繁栄を願う。
                    if (date.DayOfWeek == DayOfWeek.Monday && date.WeekOfMonth() == 3) {
                        return NationalHoliday.海の日;
                    }
                    break;

                case 8:
                    // 山の日	8月11日	山に親しむ機会を得て、山の恩恵に感謝する。
                    if (date.Day == 11 && date.Year >= 2016) {
                        return NationalHoliday.山の日;
                    }
                    break;

                case 9:
                    // 敬老の日	9月の第3月曜日	多年にわたり社会につくしてきた老人を敬愛し、長寿を祝う。
                    if (date.DayOfWeek == DayOfWeek.Monday && date.WeekOfMonth() == 3) {
                        return NationalHoliday.敬老の日;
                    }

                    // 秋分の日	秋分日	祖先をうやまい、なくなった人々をしのぶ。
                    if (date.Day == EquinoxCalculator.GetAutumnalEquinox(date.Year)) {
                        return NationalHoliday.秋分の日;
                    }
                    break;

                case 10:
                    // 体育の日	10月の第2月曜日	スポーツにしたしみ、健康な心身をつちかう。
                    if (date.DayOfWeek == DayOfWeek.Monday && date.WeekOfMonth() == 2) {
                        return NationalHoliday.体育の日;
                    }
                    break;

                case 11:
                    // 文化の日	11月3日	自由と平和を愛し、文化をすすめる。
                    if (date.Day == 3) {
                        return NationalHoliday.文化の日;
                    }

                    // 勤労感謝の日	11月23日	勤労をたっとび、生産を祝い、国民たがいに感謝しあう。
                    if (date.Day == 23) {
                        return NationalHoliday.勤労感謝の日;
                    }
                    break;

                case 12:
                    // 天皇誕生日	12月23日	天皇の誕生日を祝う。
                    if (date.Day == 23) {
                        return NationalHoliday.天皇誕生日;
                    }
                    break;

                default:
                    throw new InvalidOperationException(new { date.Month }.ToString());
            }

            return NationalHoliday.None;
        }

        /// <summary>
        /// 指定された日付が祝日なら <c>true</c>、それ以外なら <c>false</c> を返します。
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsHoliday(this DateTime date) {
            return date.IsNationalHoliday()
                || date.IsTransferHoliday()
                || date.IsCitizensHoliday();
        }

        /// <summary>
        /// 指定された日付が「国民の祝日」なら <c>true</c>、それ以外なら <c>false</c> を返します。
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsNationalHoliday(this DateTime date) {
            return date.GetNationalHoliday() != NationalHoliday.None;
        }

        /// <summary>
        /// 指定された日付が「振替休日」なら <c>true</c>、それ以外なら <c>false</c> を返します。
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsTransferHoliday(this DateTime date) {
            // 2.「国民の祝日」が日曜日に当たるときは、その日後においてその日に最も近い「国民の祝日」でない日を休日とする。

            // 指定日が祝日なら false
            if (date.IsNationalHoliday()) {
                return false;
            }

            // 直近の日曜日が祝日でなければ false
            var sunday = date.AddDays(-(int)date.DayOfWeek);
            if (sunday.IsNationalHoliday() == false) {
                return false;
            }

            // 直近の日曜日から指定日までの間に「祝日でない日」があれば false
            for (var i = 1; i < (int)date.DayOfWeek; i++) {
                if (sunday.AddDays(i).IsNationalHoliday() == false) {
                    return false;
                }
            }

            // 指定日が振替休日
            return true;
        }

        /// <summary>
        /// 指定された日付が「国民の休日」なら <c>true</c>、それ以外なら <c>false</c> を返します。
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsCitizensHoliday(this DateTime date) {
            // 3.その前日及び翌日が「国民の祝日」である日（「国民の祝日」でない日に限る。）は、休日とする。
            return date.IsNationalHoliday() == false
                && date.AddDays(-1).IsNationalHoliday()
                && date.AddDays(1).IsNationalHoliday();
        }
    }
}