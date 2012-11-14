using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OSYS.Web.DTO
{
    public class DBPersonelSurrogate
    {
        public Guid ID { get; set; }
        public Guid PersonelID { get; set; }
        public Guid PersonelJobID { get; set; }
        public string Adi { get; set; }
    }
}