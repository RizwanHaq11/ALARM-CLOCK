using System;
using System.Threading;
using System.Collections.Generic;

class Program
{
    static List<DateTime> alarmTimes = new List<DateTime>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Simple Alarm Clock");
            Console.WriteLine("1. Set an Alarm");
            Console.WriteLine("2. View All Alarms");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    SetAlarm();
                    break;
                case 2:
                    ViewAlarms();
                    break;
                case 3:
                    return;
            }
        }
    }

    static void SetAlarm()
    {
        Console.WriteLine("Enter the alarm time in HH:mm format (24-hour): ");
        string alarmTimeInput = Console.ReadLine();
        DateTime alarmTime;
        if (DateTime.TryParseExact(alarmTimeInput, "HH:mm", null, System.Globalization.DateTimeStyles.None, out alarmTime))
        {
            alarmTimes.Add(alarmTime);
            Console.WriteLine($"Alarm set for {alarmTime.ToString("HH:mm")}");
            MonitorAlarms();
        }
        else
        {
            Console.WriteLine("Invalid time format.");
        }
    }

    static void ViewAlarms()
    {
        if (alarmTimes.Count == 0)
        {
            Console.WriteLine("No alarms set.");
        }
        else
        {
            Console.WriteLine("Alarms:");
            foreach (var alarm in alarmTimes)
            {
                Console.WriteLine(alarm.ToString("HH:mm"));
            }
        }
        Console.WriteLine("Press any key to go back...");
        Console.ReadKey();
    }

    static void MonitorAlarms()
    {
        while (true)
        {
            DateTime currentTime = DateTime.Now;
            foreach (var alarmTime in alarmTimes)
            {
                if (currentTime.Hour == alarmTime.Hour && currentTime.Minute == alarmTime.Minute)
                {
                    Console.Clear();
                    Console.WriteLine("ALARM! Time to wake up!");
                    Console.Beep();
                    alarmTimes.Remove(alarmTime);
                    break;
                }
            }
            Thread.Sleep(1000);
        }
    }
}
