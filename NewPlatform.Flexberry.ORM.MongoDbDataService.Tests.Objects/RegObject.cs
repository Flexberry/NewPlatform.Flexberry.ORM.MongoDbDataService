﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewPlatform.BigDataTest
{
    using System;
    using System.Xml;
    using ICSSoft.STORMNET;
    
    
    // *** Start programmer edit section *** (Using statements)

    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// RegObject.
    /// </summary>
    // *** Start programmer edit section *** (RegObject CustomAttributes)

    // *** End programmer edit section *** (RegObject CustomAttributes)
    [ClassStorage("objects")]
    [PrimaryKeyStorage("_id")]
    [AutoAltered()]
    [Caption("Рубеж контроля")]
    [AccessType(ICSSoft.STORMNET.AccessType.none)]
    public class RegObject : ICSSoft.STORMNET.DataObject
    {
        
        private int fObjectId;
        
        private string fTown;
        
        private string fObjectName;
        
        private string fAddress;
        
        private double fLatitude;
        
        private double fLongitude;
        
        private bool fActual;
        
        private System.DateTime fCreateTime;
        
        private System.DateTime fEditTime;
        
        private string fcameras;
        
        private NewPlatform.BigDataTest.DetailArrayOfCamera fCameras;
        
        // *** Start programmer edit section *** (RegObject CustomMembers)

        // *** End programmer edit section *** (RegObject CustomMembers)

        
        /// <summary>
        /// ObjectId.
        /// </summary>
        // *** Start programmer edit section *** (RegObject.ObjectId CustomAttributes)

        // *** End programmer edit section *** (RegObject.ObjectId CustomAttributes)
        public virtual int ObjectId
        {
            get
            {
                // *** Start programmer edit section *** (RegObject.ObjectId Get start)

                // *** End programmer edit section *** (RegObject.ObjectId Get start)
                int result = this.fObjectId;
                // *** Start programmer edit section *** (RegObject.ObjectId Get end)

                // *** End programmer edit section *** (RegObject.ObjectId Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (RegObject.ObjectId Set start)

                // *** End programmer edit section *** (RegObject.ObjectId Set start)
                this.fObjectId = value;
                // *** Start programmer edit section *** (RegObject.ObjectId Set end)

                // *** End programmer edit section *** (RegObject.ObjectId Set end)
            }
        }
        
        /// <summary>
        /// Town.
        /// </summary>
        // *** Start programmer edit section *** (RegObject.Town CustomAttributes)

        // *** End programmer edit section *** (RegObject.Town CustomAttributes)
        [StrLen(255)]
        public virtual string Town
        {
            get
            {
                // *** Start programmer edit section *** (RegObject.Town Get start)

                // *** End programmer edit section *** (RegObject.Town Get start)
                string result = this.fTown;
                // *** Start programmer edit section *** (RegObject.Town Get end)

                // *** End programmer edit section *** (RegObject.Town Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (RegObject.Town Set start)

                // *** End programmer edit section *** (RegObject.Town Set start)
                this.fTown = value;
                // *** Start programmer edit section *** (RegObject.Town Set end)

                // *** End programmer edit section *** (RegObject.Town Set end)
            }
        }
        
        /// <summary>
        /// ObjectName.
        /// </summary>
        // *** Start programmer edit section *** (RegObject.ObjectName CustomAttributes)

        // *** End programmer edit section *** (RegObject.ObjectName CustomAttributes)
        [StrLen(255)]
        public virtual string ObjectName
        {
            get
            {
                // *** Start programmer edit section *** (RegObject.ObjectName Get start)

                // *** End programmer edit section *** (RegObject.ObjectName Get start)
                string result = this.fObjectName;
                // *** Start programmer edit section *** (RegObject.ObjectName Get end)

                // *** End programmer edit section *** (RegObject.ObjectName Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (RegObject.ObjectName Set start)

                // *** End programmer edit section *** (RegObject.ObjectName Set start)
                this.fObjectName = value;
                // *** Start programmer edit section *** (RegObject.ObjectName Set end)

                // *** End programmer edit section *** (RegObject.ObjectName Set end)
            }
        }
        
        /// <summary>
        /// Address.
        /// </summary>
        // *** Start programmer edit section *** (RegObject.Address CustomAttributes)

        // *** End programmer edit section *** (RegObject.Address CustomAttributes)
        [StrLen(255)]
        public virtual string Address
        {
            get
            {
                // *** Start programmer edit section *** (RegObject.Address Get start)

                // *** End programmer edit section *** (RegObject.Address Get start)
                string result = this.fAddress;
                // *** Start programmer edit section *** (RegObject.Address Get end)

                // *** End programmer edit section *** (RegObject.Address Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (RegObject.Address Set start)

                // *** End programmer edit section *** (RegObject.Address Set start)
                this.fAddress = value;
                // *** Start programmer edit section *** (RegObject.Address Set end)

                // *** End programmer edit section *** (RegObject.Address Set end)
            }
        }
        
        /// <summary>
        /// Latitude.
        /// </summary>
        // *** Start programmer edit section *** (RegObject.Latitude CustomAttributes)

        // *** End programmer edit section *** (RegObject.Latitude CustomAttributes)
        public virtual double Latitude
        {
            get
            {
                // *** Start programmer edit section *** (RegObject.Latitude Get start)

                // *** End programmer edit section *** (RegObject.Latitude Get start)
                double result = this.fLatitude;
                // *** Start programmer edit section *** (RegObject.Latitude Get end)

                // *** End programmer edit section *** (RegObject.Latitude Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (RegObject.Latitude Set start)

                // *** End programmer edit section *** (RegObject.Latitude Set start)
                this.fLatitude = value;
                // *** Start programmer edit section *** (RegObject.Latitude Set end)

                // *** End programmer edit section *** (RegObject.Latitude Set end)
            }
        }
        
        /// <summary>
        /// Longitude.
        /// </summary>
        // *** Start programmer edit section *** (RegObject.Longitude CustomAttributes)

        // *** End programmer edit section *** (RegObject.Longitude CustomAttributes)
        public virtual double Longitude
        {
            get
            {
                // *** Start programmer edit section *** (RegObject.Longitude Get start)

                // *** End programmer edit section *** (RegObject.Longitude Get start)
                double result = this.fLongitude;
                // *** Start programmer edit section *** (RegObject.Longitude Get end)

                // *** End programmer edit section *** (RegObject.Longitude Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (RegObject.Longitude Set start)

                // *** End programmer edit section *** (RegObject.Longitude Set start)
                this.fLongitude = value;
                // *** Start programmer edit section *** (RegObject.Longitude Set end)

                // *** End programmer edit section *** (RegObject.Longitude Set end)
            }
        }
        
        /// <summary>
        /// Actual.
        /// </summary>
        // *** Start programmer edit section *** (RegObject.Actual CustomAttributes)

        // *** End programmer edit section *** (RegObject.Actual CustomAttributes)
        public virtual bool Actual
        {
            get
            {
                // *** Start programmer edit section *** (RegObject.Actual Get start)

                // *** End programmer edit section *** (RegObject.Actual Get start)
                bool result = this.fActual;
                // *** Start programmer edit section *** (RegObject.Actual Get end)

                // *** End programmer edit section *** (RegObject.Actual Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (RegObject.Actual Set start)

                // *** End programmer edit section *** (RegObject.Actual Set start)
                this.fActual = value;
                // *** Start programmer edit section *** (RegObject.Actual Set end)

                // *** End programmer edit section *** (RegObject.Actual Set end)
            }
        }
        
        /// <summary>
        /// CreateTime.
        /// </summary>
        // *** Start programmer edit section *** (RegObject.CreateTime CustomAttributes)

        // *** End programmer edit section *** (RegObject.CreateTime CustomAttributes)
        public virtual System.DateTime CreateTime
        {
            get
            {
                // *** Start programmer edit section *** (RegObject.CreateTime Get start)

                // *** End programmer edit section *** (RegObject.CreateTime Get start)
                System.DateTime result = this.fCreateTime;
                // *** Start programmer edit section *** (RegObject.CreateTime Get end)

                // *** End programmer edit section *** (RegObject.CreateTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (RegObject.CreateTime Set start)

                // *** End programmer edit section *** (RegObject.CreateTime Set start)
                this.fCreateTime = value;
                // *** Start programmer edit section *** (RegObject.CreateTime Set end)

                // *** End programmer edit section *** (RegObject.CreateTime Set end)
            }
        }
        
        /// <summary>
        /// EditTime.
        /// </summary>
        // *** Start programmer edit section *** (RegObject.EditTime CustomAttributes)

        // *** End programmer edit section *** (RegObject.EditTime CustomAttributes)
        public virtual System.DateTime EditTime
        {
            get
            {
                // *** Start programmer edit section *** (RegObject.EditTime Get start)

                // *** End programmer edit section *** (RegObject.EditTime Get start)
                System.DateTime result = this.fEditTime;
                // *** Start programmer edit section *** (RegObject.EditTime Get end)

                // *** End programmer edit section *** (RegObject.EditTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (RegObject.EditTime Set start)

                // *** End programmer edit section *** (RegObject.EditTime Set start)
                this.fEditTime = value;
                // *** Start programmer edit section *** (RegObject.EditTime Set end)

                // *** End programmer edit section *** (RegObject.EditTime Set end)
            }
        }
        
        /// <summary>
        /// cameras.
        /// </summary>
        // *** Start programmer edit section *** (RegObject.cameras CustomAttributes)

        // *** End programmer edit section *** (RegObject.cameras CustomAttributes)
        [StrLen(255)]
        public virtual string cameras
        {
            get
            {
                // *** Start programmer edit section *** (RegObject.cameras Get start)

                // *** End programmer edit section *** (RegObject.cameras Get start)
                string result = this.fcameras;
                // *** Start programmer edit section *** (RegObject.cameras Get end)

                // *** End programmer edit section *** (RegObject.cameras Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (RegObject.cameras Set start)

                // *** End programmer edit section *** (RegObject.cameras Set start)
                this.fcameras = value;
                // *** Start programmer edit section *** (RegObject.cameras Set end)

                // *** End programmer edit section *** (RegObject.cameras Set end)
            }
        }
        
        /// <summary>
        /// RegObject.
        /// </summary>
        // *** Start programmer edit section *** (RegObject.Cameras CustomAttributes)

        // *** End programmer edit section *** (RegObject.Cameras CustomAttributes)
        public virtual NewPlatform.BigDataTest.DetailArrayOfCamera Cameras
        {
            get
            {
                // *** Start programmer edit section *** (RegObject.Cameras Get start)

                // *** End programmer edit section *** (RegObject.Cameras Get start)
                if ((this.fCameras == null))
                {
                    this.fCameras = new NewPlatform.BigDataTest.DetailArrayOfCamera(this);
                }
                NewPlatform.BigDataTest.DetailArrayOfCamera result = this.fCameras;
                // *** Start programmer edit section *** (RegObject.Cameras Get end)

                // *** End programmer edit section *** (RegObject.Cameras Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (RegObject.Cameras Set start)

                // *** End programmer edit section *** (RegObject.Cameras Set start)
                this.fCameras = value;
                // *** Start programmer edit section *** (RegObject.Cameras Set end)

                // *** End programmer edit section *** (RegObject.Cameras Set end)
            }
        }
    }
}
