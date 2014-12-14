using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace Maria_Kart__Game_Player_
{
    /// <summary>
    /// A data class that describes a Kinect Sensor status at a point in time.
    /// </summary>
    public class KinectStatusItem
    {
        public string Id { get; set; }

        public KinectStatus Status { get; set; }

        public DateTime DateTime { get; set; }
    }
}
