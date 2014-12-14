using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maria_Kart__Game_Player_.Entities
{
    public class DataModelUtils
    {
        private static MariaKartEntities Entities { get; set; }

        public static MariaKartEntities InstanceEntities()
        {
            if (Entities == null)
            {
                Entities = new MariaKartEntities();
            }

            return Entities;
        }
    }
}
