using System;
using System.Collections.Generic;
using Microsoft.AppCenter.Crashes;

namespace TestUI
{
    public class CrashClass
    {
        public CrashClass()
        {
            try
            {
                int number1 = 3000;
                int number2 = 0;
                Console.WriteLine(number1 / number2);
            }
            catch (Exception exception)
            {
                var properties = new Dictionary<string, string> {
                    { "Class", "CrashClass" },
                    { "Wifi", "On" },
                    { "Time", DateTime.Now.ToString() }
                };
                Crashes.TrackError(exception, properties);
            }
        }
    }
}
