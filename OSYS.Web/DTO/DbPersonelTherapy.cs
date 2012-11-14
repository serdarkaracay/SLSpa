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
    public class DbPersonelTherapy
    {
        public DbPersonelTherapy()
        {

        }
        
        [Key]
        public Guid TherapyID { get; set; }
        public string TherapyName { get; set; }
        public int ServisTime { get; set; }
    }
}