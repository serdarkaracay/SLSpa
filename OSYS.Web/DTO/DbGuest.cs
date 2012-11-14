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
    public class DbGuest
    {
        public DbGuest()
        {

        }
        [Key]
        public Guid GuestID { get; set; }
        public Guid ID { get; set; }
        public string RoomNumber { get; set; }
        public string GuestName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? DiagnosisID { get; set; }
        public string Desc { get; set; }
        public int EssiantelDate { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Release { get; set; }
    }
}