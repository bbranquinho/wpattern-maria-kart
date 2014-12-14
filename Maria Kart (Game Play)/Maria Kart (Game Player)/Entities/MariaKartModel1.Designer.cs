﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("MariaKartModel", "fk_tb_character_tb_race1", "tb_race", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Maria_Kart__Game_Player_.Entities.RaceEntity), "tb_character", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Maria_Kart__Game_Player_.Entities.CharacterEntity), true)]
[assembly: EdmRelationshipAttribute("MariaKartModel", "fk_tb_race_tb_player", "tb_player", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Maria_Kart__Game_Player_.Entities.PlayerEntity), "tb_race", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Maria_Kart__Game_Player_.Entities.RaceEntity), true)]

#endregion

namespace Maria_Kart__Game_Player_.Entities
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class MariaKartEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new MariaKartEntities object using the connection string found in the 'MariaKartEntities' section of the application configuration file.
        /// </summary>
        public MariaKartEntities() : base("name=MariaKartEntities", "MariaKartEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new MariaKartEntities object.
        /// </summary>
        public MariaKartEntities(string connectionString) : base(connectionString, "MariaKartEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new MariaKartEntities object.
        /// </summary>
        public MariaKartEntities(EntityConnection connection) : base(connection, "MariaKartEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<CharacterEntity> CharacterEntities
        {
            get
            {
                if ((_CharacterEntities == null))
                {
                    _CharacterEntities = base.CreateObjectSet<CharacterEntity>("CharacterEntities");
                }
                return _CharacterEntities;
            }
        }
        private ObjectSet<CharacterEntity> _CharacterEntities;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<PlayerEntity> PlayerEntities
        {
            get
            {
                if ((_PlayerEntities == null))
                {
                    _PlayerEntities = base.CreateObjectSet<PlayerEntity>("PlayerEntities");
                }
                return _PlayerEntities;
            }
        }
        private ObjectSet<PlayerEntity> _PlayerEntities;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<RaceEntity> RaceEntities
        {
            get
            {
                if ((_RaceEntities == null))
                {
                    _RaceEntities = base.CreateObjectSet<RaceEntity>("RaceEntities");
                }
                return _RaceEntities;
            }
        }
        private ObjectSet<RaceEntity> _RaceEntities;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the CharacterEntities EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToCharacterEntities(CharacterEntity characterEntity)
        {
            base.AddObject("CharacterEntities", characterEntity);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the PlayerEntities EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToPlayerEntities(PlayerEntity playerEntity)
        {
            base.AddObject("PlayerEntities", playerEntity);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the RaceEntities EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToRaceEntities(RaceEntity raceEntity)
        {
            base.AddObject("RaceEntities", raceEntity);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="MariaKartModel", Name="CharacterEntity")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class CharacterEntity : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new CharacterEntity object.
        /// </summary>
        /// <param name="id">Initial value of the id property.</param>
        /// <param name="name">Initial value of the name property.</param>
        /// <param name="speed">Initial value of the speed property.</param>
        /// <param name="breaking">Initial value of the breaking property.</param>
        /// <param name="acceleration">Initial value of the acceleration property.</param>
        /// <param name="tb_race_id">Initial value of the tb_race_id property.</param>
        public static CharacterEntity CreateCharacterEntity(global::System.Int32 id, global::System.String name, global::System.Int32 speed, global::System.Int32 breaking, global::System.Int32 acceleration, global::System.Int32 tb_race_id)
        {
            CharacterEntity characterEntity = new CharacterEntity();
            characterEntity.id = id;
            characterEntity.name = name;
            characterEntity.speed = speed;
            characterEntity.breaking = breaking;
            characterEntity.acceleration = acceleration;
            characterEntity.tb_race_id = tb_race_id;
            return characterEntity;
        }

        #endregion

        #region Simple Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    OnidChanging(value);
                    ReportPropertyChanging("id");
                    _id = StructuralObject.SetValidValue(value, "id");
                    ReportPropertyChanged("id");
                    OnidChanged();
                }
            }
        }
        private global::System.Int32 _id;
        partial void OnidChanging(global::System.Int32 value);
        partial void OnidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String name
        {
            get
            {
                return _name;
            }
            set
            {
                OnnameChanging(value);
                ReportPropertyChanging("name");
                _name = StructuralObject.SetValidValue(value, false, "name");
                ReportPropertyChanged("name");
                OnnameChanged();
            }
        }
        private global::System.String _name;
        partial void OnnameChanging(global::System.String value);
        partial void OnnameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 speed
        {
            get
            {
                return _speed;
            }
            set
            {
                OnspeedChanging(value);
                ReportPropertyChanging("speed");
                _speed = StructuralObject.SetValidValue(value, "speed");
                ReportPropertyChanged("speed");
                OnspeedChanged();
            }
        }
        private global::System.Int32 _speed;
        partial void OnspeedChanging(global::System.Int32 value);
        partial void OnspeedChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 breaking
        {
            get
            {
                return _breaking;
            }
            set
            {
                OnbreakingChanging(value);
                ReportPropertyChanging("breaking");
                _breaking = StructuralObject.SetValidValue(value, "breaking");
                ReportPropertyChanged("breaking");
                OnbreakingChanged();
            }
        }
        private global::System.Int32 _breaking;
        partial void OnbreakingChanging(global::System.Int32 value);
        partial void OnbreakingChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 acceleration
        {
            get
            {
                return _acceleration;
            }
            set
            {
                OnaccelerationChanging(value);
                ReportPropertyChanging("acceleration");
                _acceleration = StructuralObject.SetValidValue(value, "acceleration");
                ReportPropertyChanged("acceleration");
                OnaccelerationChanged();
            }
        }
        private global::System.Int32 _acceleration;
        partial void OnaccelerationChanging(global::System.Int32 value);
        partial void OnaccelerationChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.Byte[] picture
        {
            get
            {
                return StructuralObject.GetValidValue(_picture);
            }
            set
            {
                OnpictureChanging(value);
                ReportPropertyChanging("picture");
                _picture = StructuralObject.SetValidValue(value, true, "picture");
                ReportPropertyChanged("picture");
                OnpictureChanged();
            }
        }
        private global::System.Byte[] _picture;
        partial void OnpictureChanging(global::System.Byte[] value);
        partial void OnpictureChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 tb_race_id
        {
            get
            {
                return _tb_race_id;
            }
            set
            {
                Ontb_race_idChanging(value);
                ReportPropertyChanging("tb_race_id");
                _tb_race_id = StructuralObject.SetValidValue(value, "tb_race_id");
                ReportPropertyChanged("tb_race_id");
                Ontb_race_idChanged();
            }
        }
        private global::System.Int32 _tb_race_id;
        partial void Ontb_race_idChanging(global::System.Int32 value);
        partial void Ontb_race_idChanged();

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("MariaKartModel", "fk_tb_character_tb_race1", "tb_race")]
        public RaceEntity Races
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<RaceEntity>("MariaKartModel.fk_tb_character_tb_race1", "tb_race").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<RaceEntity>("MariaKartModel.fk_tb_character_tb_race1", "tb_race").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<RaceEntity> RacesReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<RaceEntity>("MariaKartModel.fk_tb_character_tb_race1", "tb_race");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<RaceEntity>("MariaKartModel.fk_tb_character_tb_race1", "tb_race", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="MariaKartModel", Name="PlayerEntity")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class PlayerEntity : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new PlayerEntity object.
        /// </summary>
        /// <param name="id">Initial value of the id property.</param>
        /// <param name="name">Initial value of the name property.</param>
        public static PlayerEntity CreatePlayerEntity(global::System.Int32 id, global::System.String name)
        {
            PlayerEntity playerEntity = new PlayerEntity();
            playerEntity.id = id;
            playerEntity.name = name;
            return playerEntity;
        }

        #endregion

        #region Simple Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    OnidChanging(value);
                    ReportPropertyChanging("id");
                    _id = StructuralObject.SetValidValue(value, "id");
                    ReportPropertyChanged("id");
                    OnidChanged();
                }
            }
        }
        private global::System.Int32 _id;
        partial void OnidChanging(global::System.Int32 value);
        partial void OnidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String name
        {
            get
            {
                return _name;
            }
            set
            {
                OnnameChanging(value);
                ReportPropertyChanging("name");
                _name = StructuralObject.SetValidValue(value, false, "name");
                ReportPropertyChanged("name");
                OnnameChanged();
            }
        }
        private global::System.String _name;
        partial void OnnameChanging(global::System.String value);
        partial void OnnameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String email
        {
            get
            {
                return _email;
            }
            set
            {
                OnemailChanging(value);
                ReportPropertyChanging("email");
                _email = StructuralObject.SetValidValue(value, true, "email");
                ReportPropertyChanged("email");
                OnemailChanged();
            }
        }
        private global::System.String _email;
        partial void OnemailChanging(global::System.String value);
        partial void OnemailChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.Byte[] picture
        {
            get
            {
                return StructuralObject.GetValidValue(_picture);
            }
            set
            {
                OnpictureChanging(value);
                ReportPropertyChanging("picture");
                _picture = StructuralObject.SetValidValue(value, true, "picture");
                ReportPropertyChanged("picture");
                OnpictureChanged();
            }
        }
        private global::System.Byte[] _picture;
        partial void OnpictureChanging(global::System.Byte[] value);
        partial void OnpictureChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Double> leftHandUp
        {
            get
            {
                return _leftHandUp;
            }
            set
            {
                OnleftHandUpChanging(value);
                ReportPropertyChanging("leftHandUp");
                _leftHandUp = StructuralObject.SetValidValue(value, "leftHandUp");
                ReportPropertyChanged("leftHandUp");
                OnleftHandUpChanged();
            }
        }
        private Nullable<global::System.Double> _leftHandUp;
        partial void OnleftHandUpChanging(Nullable<global::System.Double> value);
        partial void OnleftHandUpChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Double> leftHandDown
        {
            get
            {
                return _leftHandDown;
            }
            set
            {
                OnleftHandDownChanging(value);
                ReportPropertyChanging("leftHandDown");
                _leftHandDown = StructuralObject.SetValidValue(value, "leftHandDown");
                ReportPropertyChanged("leftHandDown");
                OnleftHandDownChanged();
            }
        }
        private Nullable<global::System.Double> _leftHandDown;
        partial void OnleftHandDownChanging(Nullable<global::System.Double> value);
        partial void OnleftHandDownChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Double> rightHandUp
        {
            get
            {
                return _rightHandUp;
            }
            set
            {
                OnrightHandUpChanging(value);
                ReportPropertyChanging("rightHandUp");
                _rightHandUp = StructuralObject.SetValidValue(value, "rightHandUp");
                ReportPropertyChanged("rightHandUp");
                OnrightHandUpChanged();
            }
        }
        private Nullable<global::System.Double> _rightHandUp;
        partial void OnrightHandUpChanging(Nullable<global::System.Double> value);
        partial void OnrightHandUpChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Double> rightHandDown
        {
            get
            {
                return _rightHandDown;
            }
            set
            {
                OnrightHandDownChanging(value);
                ReportPropertyChanging("rightHandDown");
                _rightHandDown = StructuralObject.SetValidValue(value, "rightHandDown");
                ReportPropertyChanged("rightHandDown");
                OnrightHandDownChanged();
            }
        }
        private Nullable<global::System.Double> _rightHandDown;
        partial void OnrightHandDownChanging(Nullable<global::System.Double> value);
        partial void OnrightHandDownChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> age
        {
            get
            {
                return _age;
            }
            set
            {
                OnageChanging(value);
                ReportPropertyChanging("age");
                _age = StructuralObject.SetValidValue(value, "age");
                ReportPropertyChanged("age");
                OnageChanged();
            }
        }
        private Nullable<global::System.Int32> _age;
        partial void OnageChanging(Nullable<global::System.Int32> value);
        partial void OnageChanged();

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("MariaKartModel", "fk_tb_race_tb_player", "tb_race")]
        public EntityCollection<RaceEntity> Races
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<RaceEntity>("MariaKartModel.fk_tb_race_tb_player", "tb_race");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<RaceEntity>("MariaKartModel.fk_tb_race_tb_player", "tb_race", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="MariaKartModel", Name="RaceEntity")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class RaceEntity : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new RaceEntity object.
        /// </summary>
        /// <param name="id">Initial value of the id property.</param>
        /// <param name="idPlayer">Initial value of the idPlayer property.</param>
        /// <param name="date">Initial value of the date property.</param>
        /// <param name="totalTime">Initial value of the totalTime property.</param>
        /// <param name="bestLapsTime">Initial value of the bestLapsTime property.</param>
        /// <param name="totalLaps">Initial value of the totalLaps property.</param>
        public static RaceEntity CreateRaceEntity(global::System.Int32 id, global::System.Int32 idPlayer, global::System.DateTime date, global::System.TimeSpan totalTime, global::System.TimeSpan bestLapsTime, global::System.Int32 totalLaps)
        {
            RaceEntity raceEntity = new RaceEntity();
            raceEntity.id = id;
            raceEntity.idPlayer = idPlayer;
            raceEntity.date = date;
            raceEntity.totalTime = totalTime;
            raceEntity.bestLapsTime = bestLapsTime;
            raceEntity.totalLaps = totalLaps;
            return raceEntity;
        }

        #endregion

        #region Simple Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    OnidChanging(value);
                    ReportPropertyChanging("id");
                    _id = StructuralObject.SetValidValue(value, "id");
                    ReportPropertyChanged("id");
                    OnidChanged();
                }
            }
        }
        private global::System.Int32 _id;
        partial void OnidChanging(global::System.Int32 value);
        partial void OnidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 idPlayer
        {
            get
            {
                return _idPlayer;
            }
            set
            {
                OnidPlayerChanging(value);
                ReportPropertyChanging("idPlayer");
                _idPlayer = StructuralObject.SetValidValue(value, "idPlayer");
                ReportPropertyChanged("idPlayer");
                OnidPlayerChanged();
            }
        }
        private global::System.Int32 _idPlayer;
        partial void OnidPlayerChanging(global::System.Int32 value);
        partial void OnidPlayerChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime date
        {
            get
            {
                return _date;
            }
            set
            {
                OndateChanging(value);
                ReportPropertyChanging("date");
                _date = StructuralObject.SetValidValue(value, "date");
                ReportPropertyChanged("date");
                OndateChanged();
            }
        }
        private global::System.DateTime _date;
        partial void OndateChanging(global::System.DateTime value);
        partial void OndateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.TimeSpan totalTime
        {
            get
            {
                return _totalTime;
            }
            set
            {
                OntotalTimeChanging(value);
                ReportPropertyChanging("totalTime");
                _totalTime = StructuralObject.SetValidValue(value, "totalTime");
                ReportPropertyChanged("totalTime");
                OntotalTimeChanged();
            }
        }
        private global::System.TimeSpan _totalTime;
        partial void OntotalTimeChanging(global::System.TimeSpan value);
        partial void OntotalTimeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.TimeSpan bestLapsTime
        {
            get
            {
                return _bestLapsTime;
            }
            set
            {
                OnbestLapsTimeChanging(value);
                ReportPropertyChanging("bestLapsTime");
                _bestLapsTime = StructuralObject.SetValidValue(value, "bestLapsTime");
                ReportPropertyChanged("bestLapsTime");
                OnbestLapsTimeChanged();
            }
        }
        private global::System.TimeSpan _bestLapsTime;
        partial void OnbestLapsTimeChanging(global::System.TimeSpan value);
        partial void OnbestLapsTimeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 totalLaps
        {
            get
            {
                return _totalLaps;
            }
            set
            {
                OntotalLapsChanging(value);
                ReportPropertyChanging("totalLaps");
                _totalLaps = StructuralObject.SetValidValue(value, "totalLaps");
                ReportPropertyChanged("totalLaps");
                OntotalLapsChanged();
            }
        }
        private global::System.Int32 _totalLaps;
        partial void OntotalLapsChanging(global::System.Int32 value);
        partial void OntotalLapsChanged();

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("MariaKartModel", "fk_tb_character_tb_race1", "tb_character")]
        public EntityCollection<CharacterEntity> Character
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<CharacterEntity>("MariaKartModel.fk_tb_character_tb_race1", "tb_character");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<CharacterEntity>("MariaKartModel.fk_tb_character_tb_race1", "tb_character", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("MariaKartModel", "fk_tb_race_tb_player", "tb_player")]
        public PlayerEntity Player
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<PlayerEntity>("MariaKartModel.fk_tb_race_tb_player", "tb_player").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<PlayerEntity>("MariaKartModel.fk_tb_race_tb_player", "tb_player").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<PlayerEntity> PlayerReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<PlayerEntity>("MariaKartModel.fk_tb_race_tb_player", "tb_player");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<PlayerEntity>("MariaKartModel.fk_tb_race_tb_player", "tb_player", value);
                }
            }
        }

        #endregion

    }

    #endregion

}