//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Maria_Kart__Game_Player_.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Race
    {
        public Race()
        {
            this.tb_character = new HashSet<Character>();
        }
    
        public int id { get; set; }
        public int idPlayer { get; set; }
        public System.DateTime date { get; set; }
        public System.TimeSpan totalTime { get; set; }
        public System.TimeSpan bestLapsTime { get; set; }
        public int totalLaps { get; set; }
    
        public virtual ICollection<Character> tb_character { get; set; }
        public virtual Player tb_player { get; set; }
    }
}