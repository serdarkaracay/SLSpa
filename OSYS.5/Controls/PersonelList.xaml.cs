using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using OSYS.Classes.interfaces;
using OSYS.Web;
using System.ServiceModel.DomainServices.Client;
using OSYS.Web.DTO;

namespace OSYS.Controls
{
    public partial class PersonelList : UserControl, IMsgBoxControl
    {
        LoadOperation<DbPersonel> loadOpDbPersonel;
        DSCapriceOfis ds = new DSCapriceOfis();
        LoadOperation<View_SPA_PersonelProfil> loadOpPerView;
        //Seçilen servisID si
        string ServiceID = ServiceListControl.ServisID;

        public PersonelList()
        {
            InitializeComponent();
            autoComPersonelAdi.Populating += new PopulatingEventHandler(autoComPersonelAdi_Populating);
            listboxPersonelEkle.SelectionChanged += listboxPersonelEkle_SelectionChanged;
        }

        void autoComPersonelAdi_Populating(object sender, PopulatingEventArgs e)
        {

            if (!ds.IsLoading)
            {
                //LoadOperation<DbPersonel> loadOp = ds.Load(ds.GetPersonelByPersonelAdiQuery(autoComPersonelAdi.Text.ToUpper()), false);
                //listboxPersonelEkle.ItemsSource = loadOp.Entities;
                loadOpPerView = ds.Load(ds.GetViewPersonelProfilQuery(autoComPersonelAdi.Text.ToUpper()));
                loadOpPerView.Completed += loadOpPerView_Completed;
            }

        }

        void loadOpPerView_Completed(object sender, EventArgs e)
        {
            listboxPersonelEkle.ItemsSource = loadOpPerView.Entities;
        }


        public Exception CheckError
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool Check(EButton b)
        {
            return true;
        }


        public static string PersonelID { get; set; }
        public static string PersonelAdi { get; set; }
        public static byte[] PersonelPhoto { get; set; }
        private void listboxPersonelEkle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = sender as ListBox;
            View_SPA_PersonelProfil item = list.SelectedItem as View_SPA_PersonelProfil;
            PersonelAdi = item.Adi;
            PersonelID = Convert.ToString(item.PersonelID);
            PersonelPhoto = item.PersonelFoto;

        }





        public EventHandler TaskCompleted { get; set; }
    }
}
