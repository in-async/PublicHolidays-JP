# PublicHolidays-JP

`PublicHolidays-JP` は日本の祝日を判定する、.NET Standard ライブラリです。

## Description

## Requirement

.NET Standard 1.0+

## Install


## Usage

`DateTime` 型の拡張メソッドを使用した例。
```cs
using InAsync.PublicHolidays.JP;

class Program {
    static void Main(string[] args) {
        var date = DateTime.Now;

        // 1. 「国民の祝日」かどうか。
        if (date.IsNationalHoliday()) {
            Console.WriteLine(date.GetNationalHoliday());
        }

        // 2. 「振替休日」かどうか。
        if (date.IsTransferHoliday()) {
            Console.WriteLine("振替休日");
        }

        // 3. 「国民の休日」かどうか。
        if (date.IsCitizensHoliday()) {
            Console.WriteLine("国民の休日");
        }

        // 上記 1~3 のいずれかの祝日かどうか。
        if (date.IsPublicHoliday()) {
            Console.WriteLine("祝日");
        }
    }
}
```


`PublicHoliday` 列挙型を使用した例。
```cs
using InAsync.PublicHolidays.JP;

class Program {
    static void Main(string[] args) {
        var date = DateTime.Now;

        PublicHoliday holiday = date.GetPublicHoliday();

        // 1. 「国民の祝日」かどうか。
        if (holiday.IsNationalHoliday()) {
            Console.WriteLine(holiday);
        }

        // 2. 「振替休日」かどうか。
        if (holiday.IsTransferHoliday()) {
            Console.WriteLine("振替休日");
        }

        // 3. 「国民の休日」かどうか。
        if (holiday.IsCitizensHoliday()) {
            Console.WriteLine("国民の休日");
        }

        // 上記 1~3 のいずれかの祝日かどうか。
        if (holiday.IsPublicHoliday()) {
            Console.WriteLine("祝日");
        }
    }
}
```


## Licence

[MIT](https://github.com/in-async/InAsync.Diagnostics.ErrorEventLogTraceListener/blob/master/LICENSE)