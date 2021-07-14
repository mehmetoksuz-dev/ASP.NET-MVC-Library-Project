using LibraryProject.Tasks.Jobs;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryProject.Tasks.Triggers
{
    public class PunishmentUpDownTrigger
    {
        public static void Start()
        {
            IScheduler timer = StdSchedulerFactory.GetDefaultScheduler(); //zamanlayıcı oluşturduk

            if (!timer.IsStarted)
                timer.Start(); // başlat

            IJobDetail task = JobBuilder.Create<PunishmentUpDownJob>().Build(); //job klasöründen tetikleme classi cagir

            ICronTrigger trigger = (ICronTrigger)TriggerBuilder.Create() // tetikleyici olustur
                .WithIdentity("PunishmentUpDownJob", "null") // class içerisinde tetiklenecek görevi seç
                .WithCronSchedule("0 0 22 * * ? *") // ne zaman çalışacak?
                .Build();

            timer.ScheduleJob(task,trigger); //sonra timer'a task ve trigger'ını veriyoruz
        }
    }
}