using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Maria_Kart__Game_Player_.Entities;
using Maria_Kart__Game_Player_.Records;
using Microsoft.Kinect;

namespace Maria_Kart__Game_Player_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly KinectSensorItemCollection SensorItems;

        private PlayerRecord Player;
        
        public MainWindow()
        {
            InitializeComponent();
            this.SensorItems = new KinectSensorItemCollection();
            Running = false;
        }

        private void ShowStatus(KinectSensor kinectSensor, KinectStatus kinectStatus)
        {
            kinectSensor.SkeletonFrameReady += KinectSensorOnSkeletonFrameReady;

            KinectSensorItem sensorItem;
            this.SensorItems.SensorLookup.TryGetValue(kinectSensor, out sensorItem);

            if (KinectStatus.Disconnected == kinectStatus)
            {
                if (sensorItem != null)
                {
                    this.SensorItems.Remove(sensorItem);
                    sensorItem.CloseWindow();
                }
            }
            else
            {
                if (sensorItem == null)
                {
                    sensorItem = new KinectSensorItem(kinectSensor, kinectSensor.DeviceConnectionId);
                    sensorItem.Status = kinectStatus;

                    this.SensorItems.Add(sensorItem);
                }
                else
                {
                    sensorItem.Status = kinectStatus;
                }

                if (KinectStatus.Connected == kinectStatus)
                {
                    // show a window
                    sensorItem.ShowWindow();
                }
                else
                {
                    sensorItem.CloseWindow();
                }
            }
        }

        private void KinectSensorOnSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            Skeleton[] skeletons = new Skeleton[0];

            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);
                }
            }

            if (skeletons.Length != 0)
            {
                for (int i = 0; i < skeletons.Length; i++)
                {
                    if (skeletons[i].TrackingState == SkeletonTrackingState.Tracked)
                    {
                        UpdateSpeed(skeletons[i]);
                        UpdateSpecial(skeletons[i]);
                    }
                }
            }
        }

        private void UpdateSpecial(Skeleton skeleton)
        {
            //var ankleRight = skeleton.Joints[JointType.AnkleRight];
            //var ankleLeft = skeleton.Joints[JointType.AnkleLeft];

            //if (ankleLeft.Position.X > ankleRight.Position.X)
            //{
            //    SendCommand("d");
            //}
        }

        private void KinectsStatusChanged(object sender, StatusChangedEventArgs e)
        {
            this.ShowStatus(e.Sensor, e.Status);
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItemSettings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Owner = this;
            settingsWindow.Show();
        }

        private void MenuItemNewGame_Click(object sender, RoutedEventArgs e)
        {
            PlayerWindow playerWindow = new PlayerWindow();
            playerWindow.Owner = this;
            playerWindow.Show();

            if (playerWindow.PlayerSelected != null)
            {
                Player = playerWindow.PlayerSelected;
                StartGame();
            }
        }

        private void MenuItemRestartGame_Click(object sender, RoutedEventArgs e)
        {
            StopGame();
            StartGame();
        }

        private void MenuItemStopGame_Click(object sender, RoutedEventArgs e)
        {
            StopGame();
        }

        private void MenuItemKinectViwer_Click(object sender, RoutedEventArgs e)
        {
            // listen to any status change for Kinects.
            KinectSensor.KinectSensors.StatusChanged += this.KinectsStatusChanged;

            // show status for each sensor that is found now.
            foreach (KinectSensor kinect in KinectSensor.KinectSensors)
            {
                this.ShowStatus(kinect, kinect.Status);
            }
        }

        #region Game
        private SerialPort Serial { get; set; }

        private int LeftSpeed { get; set; }

        private int RightSpeed { get; set; }

        private bool Running { get; set; }

        private DispatcherTimer Dispatch { get; set; }

        private DateTime StartDate { get; set; }

        private Int32 CurrentLap { get; set; }

        private void StartGame()
        {
            if (!OpenBluetoothConnection())
            {
                MessageBox.Show("Impossible connect with the car.");
                return;
            }

            Running = true;

            if (Player == null)
            {
                MessageBox.Show("Select a player to play.");
                return;
            }

            SettingsData settingsData = SettingsData.Instance();
            TextBoxPlayerName.Text = Player.Name;
            Dispatch = new DispatcherTimer();
            Dispatch.Tick += DispatcherOnTick;
            Dispatch.Interval = new TimeSpan(0, 0, 0, 0, settingsData.TimerInterval);
            StartDate = DateTime.Now;
            CurrentLap = 1;
            UpdateLaps();
            Dispatch.Start();
        }
        
        private void DispatcherOnTick(object sender, EventArgs eventArgs)
        {
            TextBoxTotalTime.Text = TimeSpan.FromSeconds((DateTime.Now - StartDate).TotalSeconds).ToString(@"mm\:ss\:fff");
            TextBoxCurrentTime.Text = TimeSpan.FromSeconds((DateTime.Now - StartDate).TotalSeconds).ToString(@"mm\:ss\:fff");

            if ((LeftSpeed > 40) || (RightSpeed > 40))
            {
                String left = "000" + LeftSpeed;
                String right = "000" + RightSpeed;
                SendCommand(String.Format("b{0}{1}", left.Substring(left.Length - 3), right.Substring(right.Length - 3)));
            }
        }

        public void StopGame()
        {
            CloseBluetoothConnection();
            Dispatch.Stop();
            Running = false;
            TextBoxCurrentTime.Text = "";
            TextBoxTotalTime.Text = "";
            TextBoxLaps.Text = "";
            GaugeLeft.Value = 0;
            GaugeRight.Value = 0;
        }

        private void UpdateSpeed(Skeleton skeleton)
        {
            if (!Running)
            {
                return;
            }

            var handLeft = skeleton.Joints[JointType.HandLeft];
            var handRight = skeleton.Joints[JointType.HandRight];
            var shoulderLeft = skeleton.Joints[JointType.ShoulderLeft];
            var shoulderRight = skeleton.Joints[JointType.ShoulderRight];

            double leftPosition = handLeft.Position.Y - shoulderLeft.Position.Y;
            double rightPosition = handRight.Position.Y - shoulderRight.Position.Y;

            leftPosition = (leftPosition < 0.0) ? Math.Abs(Player.LeftHandDown + leftPosition) : leftPosition + Player.LeftHandDown;
            rightPosition = (rightPosition < 0.0) ? Math.Abs(Player.RightHandDown + rightPosition) : rightPosition + Player.RightHandDown;

            if ((Player.LeftHandDown + Player.LeftHandUp) != 0.0)
            {
                LeftSpeed = (int)((leftPosition / (Player.LeftHandDown + Player.LeftHandUp)) * 255.0);
            }

            if ((Player.RightHandDown + Player.RightHandUp) != 0.0)
            {
                RightSpeed = (int)((rightPosition / (Player.RightHandDown + Player.RightHandUp)) * 255.0);
            }

            GaugeLeft.Value = (int) ((LeftSpeed / 255.0) * 100.0);
            GaugeRight.Value = (int) ((RightSpeed / 255.0) * 100.0);
        }

        private void CloseBluetoothConnection()
        {
            if ((Serial != null) && (Serial.IsOpen))
            {
                SendCommand("h");
                Serial.Close();
            }

            Serial = null;
        }

        private bool OpenBluetoothConnection()
        {
            try
            {
                if (Serial == null)
                {
                    SettingsData settingsData = SettingsData.Instance();
                    Serial = new SerialPort(settingsData.COM, settingsData.BaudRate);
                }

                if (!Serial.IsOpen)
                {
                    Serial.Open();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void UpdateLaps()
        {
            SettingsData settingsData = SettingsData.Instance();

            TextBoxLaps.Text = String.Format("{0} ({1})", CurrentLap, settingsData.Laps);
        }

        private void SendCommand(String command)
        {
            if ((Serial != null) && (Serial.IsOpen))
            {
                command += ":";

                System.Diagnostics.Debug.WriteLine(command);
                Serial.Write(command);
            }
        }
        #endregion
    }
}
