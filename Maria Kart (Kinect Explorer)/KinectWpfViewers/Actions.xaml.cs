using System;
using System.IO.Ports;
using System.Windows;
using System.Windows.Media;
using Microsoft.Kinect;

namespace Microsoft.Samples.Kinect.WpfViewers
{
    /// <summary>
    /// Interaction logic for Actions.xaml
    /// </summary>
    public partial class Actions : Window
    {
        private const double MovimentDistance = 0.3;

        private const Int32 Interval = 50;

        private SerialPort Port { get; set; }

        private Double LeftUp { get; set; }

        private Double LeftDown { get; set; }

        private int LeftSpeed { get; set; }

        private Double RightUp { get; set; }

        private Double RightDown { get; set; }

        private int RightSpeed { get; set; }

        private DateTime LastSendTime { get; set; }

        public Actions()
        {
            InitializeComponent();
            InitializeCustomComponent();
        }

        public void CapturePosition(Skeleton skeleton)
        {
            if (!(comboBoxBody.SelectedItem is JointType))
            {
                textBoxX.Text = textBoxY.Text = textBoxZ.Text = "";
                return;
            }

            JointType jointType = (JointType)Enum.Parse(typeof(JointType), comboBoxBody.SelectedItem.ToString());
            Joint joint = skeleton.Joints[jointType];

            textBoxX.Text = joint.Position.X.ToString();
            textBoxY.Text = joint.Position.Y.ToString();
            textBoxZ.Text = joint.Position.Z.ToString();
        }

        public void ProcessActions(Skeleton skeleton)
        {
            var handLeft = skeleton.Joints[JointType.HandLeft];
            var handRight = skeleton.Joints[JointType.HandRight];
            var ankleRight = skeleton.Joints[JointType.AnkleRight];
            var ankleLeft = skeleton.Joints[JointType.AnkleLeft];
            var spine = skeleton.Joints[JointType.Spine];
            var shoulder = skeleton.Joints[JointType.ShoulderCenter];

            // Fire
            rectangleFire.Fill = ((handLeft.Position.Y > shoulder.Position.Y) &&
                (handRight.Position.Y > shoulder.Position.Y)) ?
                Brushes.Red : Brushes.White;

            // Special
            rectangleSpecial.Fill = ankleLeft.Position.X > ankleRight.Position.X ?
                Brushes.Navy : Brushes.White;

            // Left
            rectangleLeft.Fill = ((spine.Position.X - ankleLeft.Position.X) > MovimentDistance) ?
                Brushes.Yellow : Brushes.White;

            // Right
            rectangleRight.Fill = ((ankleRight.Position.X - spine.Position.X) > MovimentDistance) ?
                Brushes.Yellow : Brushes.White;

            // Up
            rectangleUp.Fill = ((spine.Position.Z - ankleLeft.Position.Z) > MovimentDistance) ?
                Brushes.Yellow : Brushes.White;

            // Down
            rectangleDown.Fill = ((ankleRight.Position.Z - spine.Position.Z) > MovimentDistance) ?
                Brushes.Yellow : Brushes.White;

            UpdateReferrence(skeleton);
            UpdateSpeed(skeleton);
            SendSpeed();
        }

        private void UpdateReferrence(Skeleton skeleton)
        {
            var handLeft = skeleton.Joints[JointType.HandLeft];
            var handRight = skeleton.Joints[JointType.HandRight];
            var shoulderLeft = skeleton.Joints[JointType.ShoulderLeft];
            var shoulderRight = skeleton.Joints[JointType.ShoulderRight];

            double leftPosition = handLeft.Position.Y - shoulderLeft.Position.Y;
            double rightPosition = handRight.Position.Y - shoulderRight.Position.Y;

            if ((leftPosition > 0.0) && (leftPosition > LeftUp))
            {
                LeftUp = leftPosition;
            }

            if ((leftPosition < 0.0) && (-leftPosition > LeftDown))
            {
                LeftDown = -leftPosition;
            }


            if ((rightPosition > 0.0) && (rightPosition > RightUp))
            {
                RightUp = rightPosition;
            }

            if ((rightPosition < 0.0) && (-rightPosition > RightDown))
            {
                RightDown = -rightPosition;
            }

            if (LeftDown > RightDown)
            {
                RightDown = LeftDown;
            }
            else
            {
                LeftDown = RightDown;
            }

            if (LeftUp > RightUp)
            {
                RightUp = LeftUp;
            }
            else
            {
                LeftUp = RightUp;
            }

            textBoxLeftMaxWheel.Text = LeftUp.ToString();
            textBoxLeftShoulder.Text = shoulderLeft.Position.Y.ToString();
            textBoxLeftMinWheel.Text = LeftDown.ToString();

            textBoxRightMaxWheel.Text = RightUp.ToString();
            textBoxRightShoulder.Text = shoulderRight.Position.Y.ToString();
            textBoxRightMinWheel.Text = RightDown.ToString();
        }

        private void UpdateSpeed(Skeleton skeleton)
        {
            var handLeft = skeleton.Joints[JointType.HandLeft];
            var handRight = skeleton.Joints[JointType.HandRight];
            var shoulderLeft = skeleton.Joints[JointType.ShoulderLeft];
            var shoulderRight = skeleton.Joints[JointType.ShoulderRight];

            double leftPosition = handLeft.Position.Y - shoulderLeft.Position.Y;
            double rightPosition = handRight.Position.Y - shoulderRight.Position.Y;

            leftPosition = (leftPosition < 0.0) ?  Math.Abs(LeftDown + leftPosition) : leftPosition + LeftDown;
            rightPosition = (rightPosition < 0.0) ? Math.Abs(RightDown + rightPosition) : rightPosition + RightDown;

            if ((LeftDown + LeftUp) != 0.0)
            {
                LeftSpeed = (int) ((leftPosition/(LeftDown + LeftUp))*255.0);
            }

            if ((RightDown + RightUp) != 0.0)
            {
                RightSpeed = (int)((rightPosition / (RightDown + RightUp)) * 255.0);   
            }

            textBoxLeftSpeed.Text = LeftSpeed.ToString();
            textBoxRightSpeed.Text = RightSpeed.ToString();
        }

        private void SendSpeed()
        {
            if ((Port != null) && Port.IsOpen)
            {
                DateTime currentTime = DateTime.Now;

                if ((Int32)currentTime.Subtract(LastSendTime).TotalMilliseconds > Interval)
                {
                    LastSendTime = currentTime;
                    Port.WriteLine(String.Format("b:{0}:{1}", LeftSpeed, RightSpeed));
                }
            }
        }

        private void InitializeCustomComponent()
        {
            comboBoxBaudRate.Items.Add(1200);
            comboBoxBaudRate.Items.Add(2400);
            comboBoxBaudRate.Items.Add(4800);
            comboBoxBaudRate.Items.Add(9600);
            comboBoxBaudRate.Items.Add(19200);
            comboBoxBaudRate.Items.Add(38400);
            comboBoxBaudRate.Items.Add(57600);
            comboBoxBaudRate.Items.Add(115200);
            comboBoxBaudRate.Items.Add(230400);
            comboBoxBaudRate.SelectedIndex = 3;

            comboBoxBody.Items.Add("");

            foreach (var value in Enum.GetValues(typeof(JointType)))
            {
                comboBoxBody.Items.Add(value);
            }

            LeftSpeed = 0;
            LastSendTime = DateTime.Now;
            LeftUp = LeftDown = RightUp = RightDown = 0.0;
        }

        private void buttonOpenComConnection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Port == null)
                {
                    Port = new SerialPort(textBoxComConnection.Text, (int)comboBoxBaudRate.SelectedItem);
                    Port.Open();
                    buttonOpenComConnection.Content = "Close";
                }
                else
                {
                    if (Port.IsOpen)
                    {
                        Port.WriteLine("h"); // halt
                        Port.Close();
                    }

                    Port = null;
                    buttonOpenComConnection.Content = "Open";
                    LeftUp = LeftDown = RightUp = RightDown = 0.0;
                }
            }
            catch (Exception ex)
            {
                Port = null;
                buttonOpenComConnection.Content = "Open";
                LeftUp = LeftDown = RightUp = RightDown = 0.0;
                Console.WriteLine(ex.Message);
            }
        }
    }
}
