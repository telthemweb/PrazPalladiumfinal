﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Sagehill_Pallaium_Intergration_module.ClassesPrazPalladiumDTO_v2
{
    public static class TaskSchedularPrazPalladiumDTO
    {
        public static void IntervalInSeconds(int hour, int sec, double interval, Action task)
        {
            interval = interval / 3600;
            SchedulerService.Instance.ScheduleTask(hour, sec, interval, task);
        }

        public static void IntervalInMinutes(int hour, int min, double interval, Action task)
        {
            interval = interval / 60;
            SchedulerService.Instance.ScheduleTask(hour, min, interval, task);
        }

        public static void IntervalInHours(int hour, int min, double interval, Action task)
        {
            SchedulerService.Instance.ScheduleTask(hour, min, interval, task);
        }

        public static void IntervalInDays(int hour, int min, double interval, Action task)
        {
            interval = interval * 24;
            SchedulerService.Instance.ScheduleTask(hour, min, interval, task);
        }
    }
}
