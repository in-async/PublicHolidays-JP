using System;

namespace InAsync.PublicHolidays.JP {

    public enum PublicHoliday {
        None = 0,
        元日,
        成人の日,
        建国記念の日,
        春分の日,
        昭和の日,
        憲法記念日,
        みどりの日,
        こどもの日,
        海の日,
        山の日,
        敬老の日,
        秋分の日,
        体育の日,
        文化の日,
        勤労感謝の日,
        天皇誕生日,

        Transfer = -1,
        Citizens = -2,
    }

    public static class PublicHolidayExtensions {

        /// <summary>
        /// 指定された <see cref="PublicHoliday"/> が祝日なら <c>true</c>、それ以外なら <c>false</c> を返します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsPublicHoliday(this PublicHoliday value) {
            switch (value) {
                case PublicHoliday.None:
                    return false;

                default:
                    return Enum.IsDefined(typeof(PublicHoliday), value);
            }
        }

        /// <summary>
        /// 指定された <see cref="PublicHoliday"/> が「国民の祝日」なら <c>true</c>、それ以外なら <c>false</c> を返します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNationalHoliday(this PublicHoliday value) {
            switch (value) {
                case PublicHoliday.None:
                case PublicHoliday.Transfer:
                case PublicHoliday.Citizens:
                    return false;

                default:
                    return Enum.IsDefined(typeof(PublicHoliday), value);
            }
        }

        /// <summary>
        /// 指定された <see cref="PublicHoliday"/> が「振替休日」なら <c>true</c>、それ以外なら <c>false</c> を返します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsTransferHoliday(this PublicHoliday value) => (value == PublicHoliday.Transfer);

        /// <summary>
        /// 指定された <see cref="PublicHoliday"/> が「国民の休日」なら <c>true</c>、それ以外なら <c>false</c> を返します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsCitizensHoliday(this PublicHoliday value) => (value == PublicHoliday.Citizens);
    }
}