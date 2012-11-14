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
using System.Windows.Navigation;
using OSYS.Web;
using OSYS.Classes;
using OSYS.Pages;
using System.ServiceModel.DomainServices.Client;

namespace OSYS.Pages
{
    public partial class ServiceDef : AuthenticatedPage
    {
        private DSAtoz _atozContext = new DSAtoz();

        public ServiceDef()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnServisKaydet_Clicked(object sender, EventArgs e)
        {
            try
            {
                container.BusyStart("Lütfen Bekleyiniz");
                this.ServisEkle();

            }
            catch (Exception)
            {

                throw;
            }



        }

        public void ServisEkle()
        {
            decimal price = 0;
            SPA_Therapy servis = new SPA_Therapy();
            servis.ID = Guid.NewGuid();
            servis.TherapyName = txtServisAdi.Text;
            servis.ServisTime = Convert.ToInt32(nmuPersonelSayisi.Value);
            servis.IsActive = chkAktif.IsChecked;
            if (txtServisFiyat.EditValue != null)
            {
                servis.Price = decimal.Parse(txtServisFiyat.EditValue.ToString());
            }

            servis.IsTax = chkKDV.IsChecked;
            _atozContext.SPA_Therapies.Add(servis);
            _atozContext.SubmitChanges().Completed += new EventHandler(ServiceDef_Completed);

        }

        void ServiceDef_Completed(object sender, EventArgs e)
        {
            container.BusyEnd();

            uiDriver.Activate(EPages.ServiceDefinition);
        }

    }
}
