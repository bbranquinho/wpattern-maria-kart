using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Maria_Kart__Game_Player_
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private SettingsData settingsData = SettingsData.Instance();

        public SettingsWindow()
        {
            InitializeComponent();
            InitializeCustomComponent();
        }

        private void InitializeCustomComponent()
        {
            ComboBoxBaudRate.Items.Add(1200);
            ComboBoxBaudRate.Items.Add(2400);
            ComboBoxBaudRate.Items.Add(4800);
            ComboBoxBaudRate.Items.Add(9600);
            ComboBoxBaudRate.Items.Add(19200);
            ComboBoxBaudRate.Items.Add(38400);
            ComboBoxBaudRate.Items.Add(57600);
            ComboBoxBaudRate.Items.Add(115200);
            ComboBoxBaudRate.Items.Add(230400);
            ComboBoxBaudRate.SelectedIndex = 3;

            settingsData.LoadData();

            TextBoxLaps.Text = settingsData.Laps + "";
            TextBoxPenalityMs.Text = settingsData.PenalitiyMs + "";
            TextBoxPenalitySpeed.Text = settingsData.PenalitiySpeed + "";
            TextBoxBonusMs.Text = settingsData.BonusMs + "";
            TextBoxBonusSpeed.Text = settingsData.BonusSpeed + "";
            TextBoxCOM.Text = settingsData.COM;
            TextBoxPower.Text = settingsData.Power + "";
            ComboBoxBaudRate.SelectedIndex = settingsData.BaudRate;
            TextBoxTimerInterval.Text = settingsData.TimerInterval + "";
        }

        public new void Show()
        {
            base.ShowDialog();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Int32 laps = Int32.Parse(TextBoxLaps.Text);
            Int32 penalityMs = Int32.Parse(TextBoxPenalityMs.Text);
            Int32 penalitySpeed = Int32.Parse(TextBoxPenalitySpeed.Text);
            Int32 bonusMs = Int32.Parse(TextBoxBonusMs.Text);
            Int32 bonusSpeed = Int32.Parse(TextBoxBonusSpeed.Text);
            Int32 power = Int32.Parse(TextBoxPower.Text);
            String com = TextBoxCOM.Text;
            Int32 baudRate = ComboBoxBaudRate.SelectedIndex;
            Int32 timerInterval = Int32.Parse(TextBoxTimerInterval.Text);

            settingsData.SaveData(laps, penalityMs, penalitySpeed, bonusMs, bonusSpeed, power, com, baudRate, timerInterval);

            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
