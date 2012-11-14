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
    public class DBIzinPersonel
    {
        public DBIzinPersonel()
        {

        }

        [Key]
        public Guid PersonelID { get; set; }
        public Guid IzinID { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }

    }
}