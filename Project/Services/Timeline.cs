﻿

using DataLayer.Entities;

namespace Project.Service
{
    public class Timeline
    {

        public static int SlotDurationMinutes = 60;

        public static int MorningShiftStarts = 9;
        public static int MorningShiftEnds = 13;

        public static int AfternoonShiftStarts = 14;
        public static int AfternoonShiftEnds = 18;


        public static List<AppointmentSlot> GenerateSlots(DateTime start, DateTime end, bool weekends)
        {
            var result = new List<AppointmentSlot>();
            var timeline = GenerateTimeline(start, end, weekends);

            foreach (var cell in timeline)
            {
                if (start <= cell.Start && cell.End <= end)
                {
                    for (var slotStart = cell.Start; slotStart < cell.End; slotStart = slotStart.AddMinutes(SlotDurationMinutes))
                    {
                        var slotEnd = slotStart.AddMinutes(SlotDurationMinutes);

                        var slot = new AppointmentSlot();
                        slot.Start = slotStart;
                        slot.End = slotEnd;
                        slot.Status = "free";

                        result.Add(slot);

                    }
                }
            }
                
            return result;
        }


        private static List<TimeCell> GenerateTimeline(DateTime start, DateTime end, bool weekends)
        {
            var result = new List<TimeCell>();


            var incrementMorning = 1;
            var incrementAfternoon = 1;

            var days = (end.Date - start.Date).TotalDays;

            if (end > end.Date)
            {
                days += 1;
            }

            for (var i = 0; i < days; i++)
            {
                var day = start.Date.AddDays(i);
                if (!weekends)
                {
                    if (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
                    {
                        continue;
                    }
                }
                for (var x = MorningShiftStarts; x < MorningShiftEnds; x += incrementMorning)
                {
                    var cell = new TimeCell();
                    cell.Start = day.AddHours(x);
                    cell.End = day.AddHours(x + incrementMorning);

                    result.Add(cell);
                }
                for (var x = AfternoonShiftStarts; x < AfternoonShiftEnds; x += incrementAfternoon)
                {
                    var cell = new TimeCell();
                    cell.Start = day.AddHours(x);
                    cell.End = day.AddHours(x + incrementAfternoon);

                    result.Add(cell);
                }
            }


            return result;
        }

      
    }

    public class TimeCell
    {
        public DateTime Start;
        public DateTime End;
    }

}
