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
    
    public partial class Character
    {
        public int id { get; set; }
        public string name { get; set; }
        public int speed { get; set; }
        public int breaking { get; set; }
        public int acceleration { get; set; }
        public byte[] picture { get; set; }
        public int tb_race_id { get; set; }
    
        public virtual Race tb_race { get; set; }
    }
}
