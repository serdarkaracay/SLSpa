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
        public Guid PersonelID { get; set; }
        public string PersonelAdi { get; set; }
        public bool PersonelAktif { get; set; }
    }
}