using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace OSYS.Classes
{
    public class PersonelIzin
    {
        public PersonelIzin()
        {

        }

        public Guid IzinID { get; set; }
        public Guid PersonelID { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public string Desc { get; set; }
    }
}
