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
    public class DbPersonelJobDetail
    {
       
        public DbPersonelJobDetail()
        {

        }
        [Key]
        public Guid PersonelID { get; set; }
        public Guid JobID { get; set; }
        public string JobName { get; set; }
        public string Adi { get; set; }
        public long ThrapyID { get; set; }
        public byte[] PersonelPhoto { get; set; }
    }
}