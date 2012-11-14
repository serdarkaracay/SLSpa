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
    public class DbLogin
    {
        public DbLogin()
        {

        }

        [Key]
        public Guid PersonelID { get; set; }
        public Guid DepartmanID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}