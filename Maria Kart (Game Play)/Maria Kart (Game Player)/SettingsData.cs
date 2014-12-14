using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace Maria_Kart__Game_Player_
{
    public class SettingsData
    {
        private static SettingsData SettingsInstance;

        public const String DataPath = @"\Data\DataConfig.xml";

        public Int32 Laps { get; set; }

        public String COM { get; set; }

        public Int32 PenalitiyMs { get; set; }

        public Int32 PenalitiySpeed { get; set; }

        public Int32 BonusMs { get; set; }

        public Int32 BonusSpeed { get; set; }

        public Int32 BaudRate { get; set; }

        public Int32 Power { get; set; }

        public Int32 TimerInterval { get; set; }

        private SettingsData() { }

        public static SettingsData Instance()
        {
            if (SettingsInstance == null)
            {
                SettingsInstance = new SettingsData();
                SettingsInstance.LoadData();
            }

            return SettingsInstance;
        }

        public void LoadData()
        {
            try
            {
                XElement xElement = XElement.Load(Environment.CurrentDirectory + DataPath);

                Laps = Int32.Parse(xElement.Element("laps").Value);
                COM = xElement.Element("com").Value;
                PenalitiyMs = Int32.Parse(xElement.Element("penalityMs").Value);
                PenalitiySpeed = Int32.Parse(xElement.Element("penalitySpeed").Value);
                BonusMs = Int32.Parse(xElement.Element("bonusMs").Value);
                BonusSpeed = Int32.Parse(xElement.Element("bonusSpeed").Value);
                BaudRate = Int32.Parse(xElement.Element("baudRate").Value);
                Power = Int32.Parse(xElement.Element("power").Value);
                TimerInterval = Int32.Parse(xElement.Element("timerInterval").Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SaveData(int laps, int penalityMs, int penalitySpeed, int bonusMs, int bonusSpeed, int power, string com, Int32 baudRate, Int32 timerInterval)
        {
            Laps = laps;
            PenalitiyMs = penalityMs;
            PenalitiySpeed = penalitySpeed;
            BonusMs = bonusMs;
            BonusSpeed = bonusSpeed;
            Power = power;
            COM = com;
            BaudRate = baudRate;
            TimerInterval = timerInterval;

            try
            {
                XElement xElement = XElement.Load(Environment.CurrentDirectory + DataPath);

                xElement.Element("laps").Value = Laps + "";
                xElement.Element("com").Value = COM;
                xElement.Element("penalityMs").Value = PenalitiyMs + "";
                xElement.Element("penalitySpeed").Value = PenalitiySpeed + "";
                xElement.Element("bonusMs").Value = PenalitiyMs + "";
                xElement.Element("bonusSpeed").Value = PenalitiySpeed + "";
                xElement.Element("baudRate").Value = BaudRate + "";
                xElement.Element("power").Value = Power + "";
                xElement.Element("timerInterval").Value = TimerInterval + "";

                xElement.Save(Environment.CurrentDirectory + DataPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
