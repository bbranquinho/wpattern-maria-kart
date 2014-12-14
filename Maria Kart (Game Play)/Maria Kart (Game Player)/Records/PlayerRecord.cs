using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maria_Kart__Game_Player_.Entities;

namespace Maria_Kart__Game_Player_.Records
{
    public class PlayerRecord
    {
        public Int32 Id { get; set; }

        public String Name { get; set; }

        public Int32 Age { get; set; }

        public String Email { get; set; }

        public Double LeftHandUp { get; set; }

        public Double LeftHandDown { get; set; }

        public Double RightHandUp { get; set; }

        public Double RightHandDown { get; set; }

        public PlayerRecord(PlayerEntity player)
        {
            Id = player.id;
            Name = player.name;
            Age = player.age ?? 0;
            Email = player.email;
            LeftHandUp = player.leftHandUp ?? 0.0;
            LeftHandDown = player.leftHandDown ?? 0.0;
            RightHandUp = player.rightHandUp ?? 0.0;
            RightHandDown = player.rightHandDown ?? 0.0;
        }
    }
}
