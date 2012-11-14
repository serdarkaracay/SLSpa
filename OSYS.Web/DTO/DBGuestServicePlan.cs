using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ServiceModel.DomainServices.Hosting;
using System.Web;

namespace OSYS.Web.DTO
{
    [Serializable]
    [EnableClientAccess()]
    public class DBGuestServicePlan
    {
        public DBGuestServicePlan()
        {

        }

        [Key]
        public Guid GuestTherapyID { get; set; }
        public Guid? TherapID { get; set; }
        public string TherapyName { get; set; }
        public DateTime? TherapyDateTime { get; set; }
        public string ServisDesc { get; set; }
        public bool IsCompleted { get; set; }
    }
}