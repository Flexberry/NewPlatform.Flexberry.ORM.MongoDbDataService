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
    /// Event.
    /// </summary>
    // *** Start programmer edit section *** (Event CustomAttributes)

    // *** End programmer edit section *** (Event CustomAttributes)
    [ClassStorage("test_eventsIndexed")]
    [PrimaryKeyStorage("uid")]
    [AutoAltered()]
    [Caption("События")]
    [AccessType(ICSSoft.STORMNET.AccessType.none)]
    public class Event : ICSSoft.STORMNET.DataObject
    {
        
        private string ftypeid;
        
        private string fphoto_id;
        
        private long ftimestamp;
        
        private System.DateTime  fdatetime;
        
        private int fobject_id;
        
        private int fcamera_direction_id;
        
        private int fcamera_id;
        
        private string fgrz;
        
        private int fspeed;
        
        private int fyear;
        
        private int fmonth;
        
        private int fday;
        
        private int fhour;
        
        private int fmin;
        
        private int fsec;
        
        // *** Start programmer edit section *** (Event CustomMembers)

        // *** End programmer edit section *** (Event CustomMembers)

        
        /// <summary>
        /// typeid.
        /// </summary>
        // *** Start programmer edit section *** (Event.typeid CustomAttributes)

        // *** End programmer edit section *** (Event.typeid CustomAttributes)
        [StrLen(255)]
        public virtual string typeid
        {
            get
            {
                // *** Start programmer edit section *** (Event.typeid Get start)

                // *** End programmer edit section *** (Event.typeid Get start)
                string result = this.ftypeid;
                // *** Start programmer edit section *** (Event.typeid Get end)

                // *** End programmer edit section *** (Event.typeid Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Event.typeid Set start)

                // *** End programmer edit section *** (Event.typeid Set start)
                this.ftypeid = value;
                // *** Start programmer edit section *** (Event.typeid Set end)

                // *** End programmer edit section *** (Event.typeid Set end)
            }
        }
        
        /// <summary>
        /// photo_id.
        /// </summary>
        // *** Start programmer edit section *** (Event.photo_id CustomAttributes)

        // *** End programmer edit section *** (Event.photo_id CustomAttributes)
        [StrLen(255)]
        public virtual string photo_id
        {
            get
            {
                // *** Start programmer edit section *** (Event.photo_id Get start)

                // *** End programmer edit section *** (Event.photo_id Get start)
                string result = this.fphoto_id;
                // *** Start programmer edit section *** (Event.photo_id Get end)

                // *** End programmer edit section *** (Event.photo_id Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Event.photo_id Set start)

                // *** End programmer edit section *** (Event.photo_id Set start)
                this.fphoto_id = value;
                // *** Start programmer edit section *** (Event.photo_id Set end)

                // *** End programmer edit section *** (Event.photo_id Set end)
            }
        }
        
        /// <summary>
        /// timestamp.
        /// </summary>
        // *** Start programmer edit section *** (Event.timestamp CustomAttributes)

        // *** End programmer edit section *** (Event.timestamp CustomAttributes)
        public virtual long timestamp
        {
            get
            {
                // *** Start programmer edit section *** (Event.timestamp Get start)

                // *** End programmer edit section *** (Event.timestamp Get start)
                long result = this.ftimestamp;
                // *** Start programmer edit section *** (Event.timestamp Get end)

                // *** End programmer edit section *** (Event.timestamp Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Event.timestamp Set start)

                // *** End programmer edit section *** (Event.timestamp Set start)
                this.ftimestamp = value;
                // *** Start programmer edit section *** (Event.timestamp Set end)

                // *** End programmer edit section *** (Event.timestamp Set end)
            }
        }
        
        /// <summary>
        /// datetime.
        /// </summary>
        // *** Start programmer edit section *** (Event.datetime CustomAttributes)

        // *** End programmer edit section *** (Event.datetime CustomAttributes)
        public virtual System.DateTime datetime
        {
            get
            {
                // *** Start programmer edit section *** (Event.datetime Get start)

                // *** End programmer edit section *** (Event.datetime Get start)
                var result = this.fdatetime;
                // *** Start programmer edit section *** (Event.datetime Get end)

                // *** End programmer edit section *** (Event.datetime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Event.datetime Set start)

                // *** End programmer edit section *** (Event.datetime Set start)
                this.fdatetime = value;
                // *** Start programmer edit section *** (Event.datetime Set end)

                // *** End programmer edit section *** (Event.datetime Set end)
            }
        }
        
        /// <summary>
        /// object_id.
        /// </summary>
        // *** Start programmer edit section *** (Event.object_id CustomAttributes)

        // *** End programmer edit section *** (Event.object_id CustomAttributes)
        public virtual int object_id
        {
            get
            {
                // *** Start programmer edit section *** (Event.object_id Get start)

                // *** End programmer edit section *** (Event.object_id Get start)
                int result = this.fobject_id;
                // *** Start programmer edit section *** (Event.object_id Get end)

                // *** End programmer edit section *** (Event.object_id Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Event.object_id Set start)

                // *** End programmer edit section *** (Event.object_id Set start)
                this.fobject_id = value;
                // *** Start programmer edit section *** (Event.object_id Set end)

                // *** End programmer edit section *** (Event.object_id Set end)
            }
        }
        
        /// <summary>
        /// camera_direction_id.
        /// </summary>
        // *** Start programmer edit section *** (Event.camera_direction_id CustomAttributes)

        // *** End programmer edit section *** (Event.camera_direction_id CustomAttributes)
        public virtual int camera_direction_id
        {
            get
            {
                // *** Start programmer edit section *** (Event.camera_direction_id Get start)

                // *** End programmer edit section *** (Event.camera_direction_id Get start)
                int result = this.fcamera_direction_id;
                // *** Start programmer edit section *** (Event.camera_direction_id Get end)

                // *** End programmer edit section *** (Event.camera_direction_id Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Event.camera_direction_id Set start)

                // *** End programmer edit section *** (Event.camera_direction_id Set start)
                this.fcamera_direction_id = value;
                // *** Start programmer edit section *** (Event.camera_direction_id Set end)

                // *** End programmer edit section *** (Event.camera_direction_id Set end)
            }
        }
        
        /// <summary>
        /// camera_id.
        /// </summary>
        // *** Start programmer edit section *** (Event.camera_id CustomAttributes)

        // *** End programmer edit section *** (Event.camera_id CustomAttributes)
        public virtual int camera_id
        {
            get
            {
                // *** Start programmer edit section *** (Event.camera_id Get start)

                // *** End programmer edit section *** (Event.camera_id Get start)
                int result = this.fcamera_id;
                // *** Start programmer edit section *** (Event.camera_id Get end)

                // *** End programmer edit section *** (Event.camera_id Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Event.camera_id Set start)

                // *** End programmer edit section *** (Event.camera_id Set start)
                this.fcamera_id = value;
                // *** Start programmer edit section *** (Event.camera_id Set end)

                // *** End programmer edit section *** (Event.camera_id Set end)
            }
        }
        
        /// <summary>
        /// grz.
        /// </summary>
        // *** Start programmer edit section *** (Event.grz CustomAttributes)

        // *** End programmer edit section *** (Event.grz CustomAttributes)
        [StrLen(255)]
        public virtual string grz
        {
            get
            {
                // *** Start programmer edit section *** (Event.grz Get start)

                // *** End programmer edit section *** (Event.grz Get start)
                string result = this.fgrz;
                // *** Start programmer edit section *** (Event.grz Get end)

                // *** End programmer edit section *** (Event.grz Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Event.grz Set start)

                // *** End programmer edit section *** (Event.grz Set start)
                this.fgrz = value;
                // *** Start programmer edit section *** (Event.grz Set end)

                // *** End programmer edit section *** (Event.grz Set end)
            }
        }
        
        /// <summary>
        /// speed.
        /// </summary>
        // *** Start programmer edit section *** (Event.speed CustomAttributes)

        // *** End programmer edit section *** (Event.speed CustomAttributes)
        public virtual int speed
        {
            get
            {
                // *** Start programmer edit section *** (Event.speed Get start)

                // *** End programmer edit section *** (Event.speed Get start)
                int result = this.fspeed;
                // *** Start programmer edit section *** (Event.speed Get end)

                // *** End programmer edit section *** (Event.speed Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Event.speed Set start)

                // *** End programmer edit section *** (Event.speed Set start)
                this.fspeed = value;
                // *** Start programmer edit section *** (Event.speed Set end)

                // *** End programmer edit section *** (Event.speed Set end)
            }
        }
        
        /// <summary>
        /// year.
        /// </summary>
        // *** Start programmer edit section *** (Event.year CustomAttributes)

        // *** End programmer edit section *** (Event.year CustomAttributes)
        public virtual int year
        {
            get
            {
                // *** Start programmer edit section *** (Event.year Get start)

                // *** End programmer edit section *** (Event.year Get start)
                int result = this.fyear;
                // *** Start programmer edit section *** (Event.year Get end)

                // *** End programmer edit section *** (Event.year Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Event.year Set start)

                // *** End programmer edit section *** (Event.year Set start)
                this.fyear = value;
                // *** Start programmer edit section *** (Event.year Set end)

                // *** End programmer edit section *** (Event.year Set end)
            }
        }
        
        /// <summary>
        /// month.
        /// </summary>
        // *** Start programmer edit section *** (Event.month CustomAttributes)

        // *** End programmer edit section *** (Event.month CustomAttributes)
        public virtual int month
        {
            get
            {
                // *** Start programmer edit section *** (Event.month Get start)

                // *** End programmer edit section *** (Event.month Get start)
                int result = this.fmonth;
                // *** Start programmer edit section *** (Event.month Get end)

                // *** End programmer edit section *** (Event.month Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Event.month Set start)

                // *** End programmer edit section *** (Event.month Set start)
                this.fmonth = value;
                // *** Start programmer edit section *** (Event.month Set end)

                // *** End programmer edit section *** (Event.month Set end)
            }
        }
        
        /// <summary>
        /// day.
        /// </summary>
        // *** Start programmer edit section *** (Event.day CustomAttributes)

        // *** End programmer edit section *** (Event.day CustomAttributes)
        public virtual int day
        {
            get
            {
                // *** Start programmer edit section *** (Event.day Get start)

                // *** End programmer edit section *** (Event.day Get start)
                int result = this.fday;
                // *** Start programmer edit section *** (Event.day Get end)

                // *** End programmer edit section *** (Event.day Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Event.day Set start)

                // *** End programmer edit section *** (Event.day Set start)
                this.fday = value;
                // *** Start programmer edit section *** (Event.day Set end)

                // *** End programmer edit section *** (Event.day Set end)
            }
        }
        
        /// <summary>
        /// hour.
        /// </summary>
        // *** Start programmer edit section *** (Event.hour CustomAttributes)

        // *** End programmer edit section *** (Event.hour CustomAttributes)
        public virtual int hour
        {
            get
            {
                // *** Start programmer edit section *** (Event.hour Get start)

                // *** End programmer edit section *** (Event.hour Get start)
                int result = this.fhour;
                // *** Start programmer edit section *** (Event.hour Get end)

                // *** End programmer edit section *** (Event.hour Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Event.hour Set start)

                // *** End programmer edit section *** (Event.hour Set start)
                this.fhour = value;
                // *** Start programmer edit section *** (Event.hour Set end)

                // *** End programmer edit section *** (Event.hour Set end)
            }
        }
        
        /// <summary>
        /// min.
        /// </summary>
        // *** Start programmer edit section *** (Event.min CustomAttributes)

        // *** End programmer edit section *** (Event.min CustomAttributes)
        public virtual int min
        {
            get
            {
                // *** Start programmer edit section *** (Event.min Get start)

                // *** End programmer edit section *** (Event.min Get start)
                int result = this.fmin;
                // *** Start programmer edit section *** (Event.min Get end)

                // *** End programmer edit section *** (Event.min Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Event.min Set start)

                // *** End programmer edit section *** (Event.min Set start)
                this.fmin = value;
                // *** Start programmer edit section *** (Event.min Set end)

                // *** End programmer edit section *** (Event.min Set end)
            }
        }
        
        /// <summary>
        /// sec.
        /// </summary>
        // *** Start programmer edit section *** (Event.sec CustomAttributes)

        // *** End programmer edit section *** (Event.sec CustomAttributes)
        public virtual int sec
        {
            get
            {
                // *** Start programmer edit section *** (Event.sec Get start)

                // *** End programmer edit section *** (Event.sec Get start)
                int result = this.fsec;
                // *** Start programmer edit section *** (Event.sec Get end)

                // *** End programmer edit section *** (Event.sec Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Event.sec Set start)

                // *** End programmer edit section *** (Event.sec Set start)
                this.fsec = value;
                // *** Start programmer edit section *** (Event.sec Set end)

                // *** End programmer edit section *** (Event.sec Set end)
            }
        }
    }
}
