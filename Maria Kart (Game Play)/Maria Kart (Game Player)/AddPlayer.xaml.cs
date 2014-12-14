using Maria_Kart__Game_Player_.Entities;
using Maria_Kart__Game_Player_.Records;
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
using Microsoft.Kinect;

namespace Maria_Kart__Game_Player_
{
    /// <summary>
    /// Interaction logic for AddPlayer.xaml
    /// </summary>
    public partial class AddPlayer : Window
    {
        public static KinectSensor Sensor { get; set; }

        private MariaKartEntities Entities { get; set; }

        private Double LeftUp { get; set; }

        private Double LeftDown { get; set; }

        private Double RightUp { get; set; }

        private Double RightDown { get; set; }

        public AddPlayer()
        {
            InitializeComponent();
            InitializeCustomComponent();
        }

        private void InitializeCustomComponent()
        {
            Entities = DataModelUtils.InstanceEntities();
            LeftUp = LeftDown = RightUp = RightDown = 0.0;

            if (Sensor != null)
            {
                Sensor.SkeletonFrameReady += SensorOnSkeletonFrameReady;
            }
        }

        private void SensorOnSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
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
                        UpdateReferrence(skeletons[i]);
                    }
                }
            }
        }

        public AddPlayer(PlayerRecord player)
        {
            InitializeComponent();
            InitializeCustomComponent();

            LoadPlayer(player);
        }

        private void LoadPlayer(PlayerRecord player)
        {
            TextBoxId.Text = player.Id + "";
            TextBoxName.Text = player.Name;
            TextBoxAge.Text = player.Age + "";
            TextBoxEmail.Text = player.Email;
            TextBoxLeftHandUp.Text = player.LeftHandUp + "";
            TextBoxLeftHandDown.Text = player.LeftHandDown + "";
            TextBoxRightHandUp.Text = player.RightHandUp + "";
            TextBoxRightHandDown.Text = player.RightHandDown + "";
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlayerEntity player;
                Int32 id, age;
                Double leftHandUp, leftHandDown, rightHandUp, rightHandDown;

                Double.TryParse(TextBoxLeftHandUp.Text, out leftHandUp);
                Double.TryParse(TextBoxLeftHandDown.Text, out leftHandDown);
                Double.TryParse(TextBoxRightHandUp.Text, out rightHandUp);
                Double.TryParse(TextBoxRightHandDown.Text, out rightHandDown);
                Int32.TryParse(TextBoxAge.Text, out age);

                if (Int32.TryParse(TextBoxId.Text, out id))
                {
                    player = Entities.PlayerEntities.First(p => p.id == id);

                    player.name = TextBoxName.Text;
                    player.age = age;
                    player.email = TextBoxEmail.Text;
                    player.leftHandUp = leftHandUp;
                    player.leftHandDown = leftHandDown;
                    player.rightHandUp = rightHandUp;
                    player.rightHandDown = rightHandDown;
                    //player.picture =
                }
                else
                {
                    player = new PlayerEntity();

                    player.name = TextBoxName.Text;
                    player.age = age;
                    player.email = TextBoxEmail.Text;
                    player.leftHandUp = leftHandUp;
                    player.leftHandDown = leftHandDown;
                    player.rightHandUp = rightHandUp;
                    player.rightHandDown = rightHandDown;
                    //player.picture =

                    Entities.AddToPlayerEntities(player);
                }

                Entities.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closed_1(object sender, EventArgs e)
        {
            if (Sensor != null)
            {
                Sensor.SkeletonFrameReady -= SensorOnSkeletonFrameReady;
            }
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

            TextBoxLeftHandUp.Text = LeftUp + "";
            TextBoxLeftHandDown.Text = LeftDown + "";
            TextBoxRightHandUp.Text = RightUp + "";
            TextBoxRightHandDown.Text = RightDown + "";
        }

        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            LeftUp = LeftDown = RightUp = RightDown = 0.0;
            TextBoxLeftHandUp.Text = LeftUp + "";
            TextBoxLeftHandDown.Text = LeftDown + "";
            TextBoxRightHandUp.Text = RightUp + "";
            TextBoxRightHandDown.Text = RightDown + "";
        }
    }
}
