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
using OSYS.Controls;
using OSYS.Classes.interfaces;
using OSYS.Web;
using System.ServiceModel.DomainServices.Client;
using OSYS.Model;
using System.Collections;

namespace OSYS.Pages
{
    public partial class CustMeterPage : AuthenticatedPage
    {

        DSCapriceOfis ds = new DSCapriceOfis();
        DSAtoz context = new DSAtoz();
        string serviceID = ServiceListControl.ServisID;
        LoadOperation<SPA_PersonelJobDetail> loadOp;
        LoadOperation<OSYS.Web.DTO.DbPersonel> DPersonelLoadOp;

        public CustMeterPage()
        {
            InitializeComponent();
            tiServis.IsSelected = true;
            this.Title = "Servis Tanımları";
            //LoadOperation<Personel> loadOp = ds.Load(ds.GetPersonelQuery());
            //loadOp.Completed += (s, a) => { grid.ItemsSource = ds.Personels; };
            BindServis();
            BindPersonelJob();
        }

        public void BindServis()
        {
            LoadOperation<SPA_Therapy> loadOp = context.Load(context.GetTherapyByIDQuery(serviceID), 
                new Action<LoadOperation<SPA_Therapy>>(GetSpa_TherapyEditCompleted), true);

        }

        private void GetSpa_TherapyEditCompleted(LoadOperation<SPA_Therapy> args)
        {
            SPA_Therapy spaTherapy = args.Entities.First();

            if (servisGuncelle == true)
            {
                //spaTherapy.ID = serviceID;
                spaTherapy.TherapyName = txtServisAdi.Text;
                spaTherapy.ServisTime = Convert.ToInt32(nmuPersonelSayisi.Value);
                spaTherapy.Price = txtServisFiyat.Text == null ? 0 : Convert.ToDecimal(txtServisFiyat.Text);
                spaTherapy.IsTax = chkKDV.IsChecked ?? chkKDV.IsChecked == false;
                spaTherapy.IsActive = chkAktif.IsChecked ?? chkAktif.IsChecked == false;
                context.SubmitChanges();
                tiPersonel.IsSelected = true;
            }

            txtServisAdi.Text = spaTherapy.TherapyName;
            txtServisFiyat.Text = (spaTherapy.Price == null ? 0 : spaTherapy.Price).ToString();
            nmuPersonelSayisi.Value = Convert.ToDouble(spaTherapy.ServisTime ?? 0);
            chkAktif.IsChecked = spaTherapy.IsActive ?? false;
            chkKDV.IsChecked = spaTherapy.IsTax ?? false;
        }

        public void ServisGuncelle(SPA_Therapy therapy)
        {
            therapy.ID = Guid.Parse(serviceID);
            therapy.TherapyName = txtServisAdi.Text;
            therapy.ServisTime = Convert.ToInt32(nmuPersonelSayisi.Value);
            therapy.Price = txtServisFiyat.Text == null ? 0 : Convert.ToDecimal(txtServisFiyat.Text);
            therapy.IsTax = chkKDV.IsChecked ?? chkKDV.IsChecked == false;
            therapy.IsActive = chkAktif.IsChecked ?? chkAktif.IsChecked == false;
            context.SubmitChanges();
        }

        bool servisGuncelle = false;
        private void btnServisKaydet_Clicked(object sender, EventArgs e)
        {
            servisGuncelle = true;
            LoadOperation<SPA_Therapy> loadOp = context.Load(context.GetTherapyByIDQuery(serviceID), new Action<LoadOperation<SPA_Therapy>>(GetSpa_TherapyEditCompleted), true);
        }



        private void btnPersonelEkle_Clicked(object sender, EventArgs e)
        {

            PersonelList model = new PersonelList();
            container.BusyStart("Bekleyiniz.");
            container.MsgBox((IMsgBoxControl)model, EButtons.OkCancel, (r) =>
            {
                if (r == EButton.Ok)
                {
                    PersonelEkle();

                }
            });


        }

        void model_TaskCompleted(object sender, EventArgs e)
        {
            BindPersonelJob();
        }

        public void PersonelEkle()
        {
            SPA_PersonelJobDetail personelDetail = new SPA_PersonelJobDetail();
            personelDetail.ID = Guid.NewGuid();
            personelDetail.PersonelID = new Guid(PersonelList.PersonelID);
            personelDetail.Adi = PersonelList.PersonelAdi;
            personelDetail.TherapyID = Guid.Parse(serviceID);
            personelDetail.PersonelPhoto = PersonelList.PersonelPhoto;
            context.SPA_PersonelJobDetails.Add(personelDetail);
            context.SubmitChanges().Completed += CustMeterPage_Completed;
        }



        void CustMeterPage_Completed(object sender, EventArgs e)
        {
            BindPersonelJob();
        }

        public void BindPersonelJob()
        {

            loadOp = context.Load(context.GetPersonelDetailListQuery(serviceID), false);
            loadOp.Completed += DPersonelLoadOp_Completed;
        }

        void DPersonelLoadOp_Completed(object sender, EventArgs e)
        {
            gridPersonelList.ItemsSource = loadOp.Entities;
            container.BusyEnd();
        }
    }
}