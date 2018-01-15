namespace InAsync.PublicHolidays.JP {

    /// <summary>
    /// [春分の計算・秋分の計算 - Other - hesperus.net](http://www.hesperus.net/other/equinox.aspx)
    /// </summary>
    internal static class EquinoxCalculator {

        // 春分の計算; xは西暦年, 有効範囲は 1796～2351
        public static int GetVernalEquinox(int x) {
            return GetEquinox(0.242387295944576, 20.9115797338431, x);
        }

        // 秋分の計算; xは西暦年, 有効範囲は 1856～2230
        public static int GetAutumnalEquinox(int x) {
            return GetEquinox(0.242022156035078, 24.0491154953035, x);
        }

        private static int GetEquinox(double a, double b, int x) {
            return (int)((a * x) - ((x / 4) - (x / 100) + (x / 400)) + b);
        }
    }
}