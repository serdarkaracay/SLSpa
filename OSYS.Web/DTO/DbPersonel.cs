using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.DomainServices.Hosting;
using System.ComponentModel.DataAnnotations;

namespace OSYS.Web.DTO
{
    [Serializable]
    [EnableClientAccess()]
    public class DbPersonel
    {
        public DbPersonel()
        {

        }
        [Key]
        public Guid ID { get; set; }
        public string PersonelAdi { get; set; }
        public string UzmanlikAlani { get; set; }
        public bool Yedek { get; set; }
    }
}