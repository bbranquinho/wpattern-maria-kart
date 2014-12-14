using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maria_Kart__Game_Player_.Tests
{
    [TestClass]
    class Stopwatch
    {
        private Int64 startProperties { get; set; } // ? private long start = 0;
        private Int64 stopProperties { get; set; }

        public Stopwatch()
        {
            this.startProperties = 0;
            this.stopProperties = 0;
        }

        [TestMethod]
        public void testMethod() // public static void main (String [] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.start();
            while (true)
            {
                String elapsedTime = sw.elapsedTime();
                System.Diagnostics.Debug.Write(elapsedTime);
            }
        }

        private Int64 currentTimeMillis() // Pega a data do sistema
        {
            TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            return (Int64)ts.TotalMilliseconds;
        }

        public void start()
        {
            this.startProperties = this.currentTimeMillis(); // valor corrente para variável de classe
        }

        public void stop()
        {
            this.stopProperties = this.currentTimeMillis();
        }

        public String elapsedTime()
        {
            Int64 difference;

            if (this.stopProperties == 0) 
            {
                Int64 now = this.currentTimeMillis();
                difference = (now - this.startProperties);
            }
            else
            {
                difference = (this.stopProperties - this.startProperties);
            }

            Int64 mils = difference % 1000;
            difference = (difference - mils) / 1000;

            Int64 secs = difference % 60;
            difference = (difference - secs) / 60;

            Int64 minutes = difference % 60;
            difference = (difference - minutes) / 60;

            String message;

            if (minutes > 0)
            {
                message = minutes + " minutes and " + secs + " seconds";
            }
            else if (secs > 0)
            {
                message = secs + " seconds and " + mils + " milliseconds";
            }
            else
            {
                message = mils + " milliseconds";
            }

            return message;
        }        
    }
}
