﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign
{
    public class DatePickerLocale
    {
        public DateLocale Lang { get; set; }

        public TimePickerLocale TimePickerLocale { get; set; }
    }

    public class DateLocale
    {
        public string Placeholder { get; set; }
        public string YearPlaceholder { get; set; }
        public string QuarterPlaceholder { get; set; }
        public string MonthPlaceholder { get; set; }
        public string WeekPlaceholder { get; set; }
        public string[] RangePlaceholder { get; set; }
        public string[] RangeYearPlaceholder { get; set; }
        public string[] RangeMonthPlaceholder { get; set; }
        public string[] RangeWeekPlaceholder { get; set; }
        public string Locale { get; set; }
        public string Today { get; set; }
        public string Now { get; set; }
        public string BackToToday { get; set; }
        public string Ok { get; set; }
        public string Clear { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string TimeSelect { get; set; }
        public string DateSelect { get; set; }
        public string WeekSelect { get; set; }
        public string MonthSelect { get; set; }
        public string YearSelect { get; set; }
        public string DecadeSelect { get; set; }
        public string YearFormat { get; set; }
        public string DateFormat { get; set; }
        public string DayFormat { get; set; }
        public string DateTimeFormat { get; set; }
        public bool MonthBeforeYear { get; set; }
        public string PreviousMonth { get; set; }
        public string NextMonth { get; set; }
        public string PreviousYear { get; set; }
        public string NextYear { get; set; }
        public string PreviousDecade { get; set; }
        public string NextDecade { get; set; }
        public string PreviousCentury { get; set; }
        public string NextCentury { get; set; }
    }
}
