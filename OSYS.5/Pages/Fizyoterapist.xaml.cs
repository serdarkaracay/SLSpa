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
using System.ServiceModel.DomainServices.Client;
using System.ServiceModel.DomainServices;
using OSYS.Classes;

namespace OSYS.Pages
{
    public partial class Fizyoterapist : AuthenticatedPage
    {
        DSAtoz context = new DSAtoz();
        LoadOperation<OSYS.Web.DTO.DbGuest> loadOpGuest;
        LoadOperation<SPA_Diagnosis> loadOpDia;
        LoadOperation<SPA_GuestDiagnosisDetail> loadDiaD;
        LoadOperation<SPA_Therapy> loadTherapy;
        LoadOperation<View_SPA_GuestDiagnosticDetail> loadViewD;
        LoadOperation<OSYS.Web.DTO.DBGuestServicePlan> loadGuestServicePlan;
        List<OSYS.Web.DTO.DBGuestServicePlan> listGuestServicePlan = new List<Web.DTO.DBGuestServicePlan>();

        public Fizyoterapist()
        {
            InitializeComponent();
            this.BindGuestList();
            this.BindDiagnosisList();
            this.BindFizyoterapistTherapy();
        }

        public void BindGuestList()
        {
            loadOpGuest = context.Load(context.GetFizyoterapistGuestQuery(UserSession.UserID.ToString()));
            loadOpGuest.Completed += loadOpGuest_Completed;
        }

        void loadOpGuest_Completed(object sender, EventArgs e)
        {
            listboxGuest.ItemsSource = loadOpGuest.Entities;

        }

        public Guid GuestID { get; set; }
        public Guid ID { get; set; }
        bool dataform = false;

        private void listboxGuest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataform = true;
            ListBox list = sender as ListBox;
            OSYS.Web.DTO.DbGuest guest = list.SelectedItem as OSYS.Web.DTO.DbGuest;
            GuestID = guest.GuestID;
            ID = guest.ID;
            loadViewD = context.Load(context.GetFizyoterapistByGuestIDQuery(GuestID.ToString()));
            loadViewD.Completed += loadViewD_Completed;
            BindGuestServicePlan(GuestID);
        }

        void loadViewD_Completed(object sender, EventArgs e)
        {
            if (loadViewD.Entities.Count() > 0)
            {
                View_SPA_GuestDiagnosticDetail db = loadViewD.Entities.First();
                tbMisafirAdi.Text = db.FirstName;
                tbMisafirSoy.Text = db.LastName;
                tbOda.Text = db.RoomNumber;
                tbGiris.Text = db.ArriveDate.ToString("dd.MM.yyyy");
                tbCikis.Text = db.DepartureDate.ToString("dd.MM.yyyy");
                diagnosisList.EditValue = db.DiagnosisID;
                txtDesc.Text = db.DescDiagnosis;
            }

        }


        public void BindDiagnosisList()
        {
            loadOpDia = context.Load(context.GetSPA_DiagnosisQuery());
            loadOpDia.Completed += loadOpDia_Completed;
        }

        void loadOpDia_Completed(object sender, EventArgs e)
        {

            diagnosisList.ItemsSource = loadOpDia.Entities;
            diagnosisList.DisplayMember = "DiagnosisName";
            diagnosisList.ValueMember = "ID";
        }

        public void BindFizyoterapistTherapy()
        {
            loadTherapy = context.Load(context.GetSPA_TherapyQuery());
            loadTherapy.Completed += loadTherapy_Completed;
        }

        void loadTherapy_Completed(object sender, EventArgs e)
        {
            List<Therapy> list = new List<Therapy>();
            foreach (var item in loadTherapy.Entities)
            {
                list.Add(new Therapy { TherapyID = item.ID, TherapyName = item.TherapyName });
            }

            cbeServisList.ItemsSource = list;
            cbeServisList.DisplayMember = "TherapyName";
            cbeServisList.ValueMember = "TherapyID";
        }

        public class Therapy
        {
            public Guid TherapyID { get; set; }
            public string TherapyName { get; set; }
            public bool Sec { get; set; }
            public DateTime Tarih { get; set; }
            public string ServisNote { get; set; }
        }

        List<int> secilenler = new List<int>();

        void Fizyoterapist_Completed(object sender, EventArgs e)
        {
           
            this.BindGuestServicePlan(GuestID);
            txtDesc.Text = string.Empty;
            cbeServisList.Clear();
            dateEditServis.Clear();
            if (refresh)
            {
                uiDriver.Activate(EPages.Fizyoterapist);
            }
           
        }

        bool refresh = false;
        private void btnMisafirEkle_Clicked(object sender, EventArgs e)
        {
            if (listboxGuestServisPlan.Items.Count > 0)
            {
                loadDiaD = context.Load(context.GetDiagnosisDetailUpdateQuery(ID.ToString()),
                    new Action<LoadOperation<SPA_GuestDiagnosisDetail>>(GetSpa_DiagnosisDetailUpdate), true);
            }
            else
            {
                MessageBox.Show("Lütfen Servis Seçiniz.");
            }
        }

        private void GetSpa_DiagnosisDetailUpdate(LoadOperation<SPA_GuestDiagnosisDetail> args)
        {
            refresh = true;
            SPA_GuestDiagnosisDetail db = args.Entities.First();
            db.Completed = true;
            //context.SubmitChanges();
            context.SubmitChanges().Completed += Fizyoterapist_Completed;
            

        }

     
        private void btnServisListPlan_Click(object sender, RoutedEventArgs e)
        {

          
            SPA_GuestTherapyDetail guestTherapy = new SPA_GuestTherapyDetail();
            guestTherapy.ID = Guid.NewGuid();
            guestTherapy.GuestID = GuestID;
            guestTherapy.TherapyID = Guid.Parse(cbeServisList.EditValue.ToString());
            guestTherapy.TherapyDateTime = Convert.ToDateTime(dateEditServis.EditValue);
            guestTherapy.TherapyNote = txtDesc.Text;
            guestTherapy.IsCompleted = false;
            context.SPA_GuestTherapyDetails.Add(guestTherapy);
            context.SubmitChanges().Completed+=Fizyoterapist_Completed;

           

            //if (!guestListRefresh)
            //{
            // loadDiaD = context.Load(context.GetDiagnosisDetailUpdateQuery(ID.ToString()),
            //   new Action<LoadOperation<SPA_GuestDiagnosisDetail>>(GetSpa_DiagnosisDetailUpdate), true);
            //}


        }

        public void BindGuestServicePlan(Guid GuestID)
        {
            string _guestID = GuestID.ToString();
            loadGuestServicePlan = context.Load(context.GetGuestServicePlanQuery(_guestID));
            loadGuestServicePlan.Completed += loadGuestServicePlan_Completed;
        }

        void loadGuestServicePlan_Completed(object sender, EventArgs e)
        {
            listboxGuestServisPlan.ItemsSource = loadGuestServicePlan.Entities;
        }

    }
}
