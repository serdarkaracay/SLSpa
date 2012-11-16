using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Scheduler;
using OSYS.Classes.interfaces;
using OSYS.Pages;
using OSYS.Web;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace OSYS.Controls
{
    public partial class ServicePlan : UserControl, IMsgBoxControl
    {
        DSAtoz context = new DSAtoz();

        LoadOperation<OSYS.Web.DTO.DBGuestServicePlan> loadOpServicePlan;
        LoadOperation<SPA_PersonelJobDetail> loadPersonel;
        List<ServicePlanPersonelSurrogate> list = new List<ServicePlanPersonelSurrogate>();
        List<ServicePlanSurrogate> servisPlanList = new List<ServicePlanSurrogate>();
        List<ServicePlanReservationSurrogate> resList = new List<ServicePlanReservationSurrogate>();
        LoadOperation<SPA_RezervationSchedule> loadOpResSch;


        public static string GuestID { get; set; }
        public string RoomNumber { get; set; }
        public Guid? TherapyID { get; set; }
        public DateTime StartDateTime { get; set; }
        public string GuestNote { get; set; }
        public string TherapyName { get; set; }
        public string TerapyID { get; set; }
        public string GuestName { get; set; }
        public string ServicePlanID { get; set; }
        //public ServicePlan()
        //{
        //    InitializeComponent();
        //    this.BindGuestServicePlanList();
        //}

        public ServicePlan(string guestID, string roomNumber)
        {
            InitializeComponent();
            ListBoxClear();
            GuestID = guestID;
            RoomNumber = roomNumber;
            this.GetPersonelList();
            BindSchedulerResource();

        }

        public ServicePlan()
        {
            InitializeComponent();
        }

        public void BindSchedulerResource()
        {
            loadOpResSch = context.Load(context.GetSPA_RezervationScheduleQuery());
            loadOpResSch.Completed += loadOpResSch_Completed;
        }

        void loadOpResSch_Completed(object sender, EventArgs e)
        {
            AppointmentStorage aptstor = schServisPlan.Storage.AppointmentStorage;
            aptstor.DataSource = loadOpResSch.Entities;
            aptstor.Mappings.Start = "StartDateTime";
            aptstor.Mappings.End = "EndDateTime";
            aptstor.Mappings.Subject = "Subject";
            aptstor.Mappings.Location = "Location";
            aptstor.Mappings.Description = "GuestNote";
            aptstor.Mappings.ResourceId = "PersonelID";
            aptstor.Mappings.Label = "StatusID";
            aptstor.Mappings.AllDay = "True";
        }

        public void BindGuestServicePlanList()
        {

            loadOpServicePlan = context.Load(context.GetGuestServicePlanQuery(GuestID));
            loadOpServicePlan.Completed += loadOpServicePlan_Completed;
        }

        void loadOpServicePlan_Completed(object sender, EventArgs e)
        {

            foreach (var item in loadOpServicePlan.Entities)
            {

                servisPlanList.Add(new ServicePlanSurrogate
                {
                    TherapyName = item.TherapyName,
                    ServisDateTime = item.TherapyDateTime,
                    GuestNote = item.ServisDesc,
                    TherapyID = item.TherapID,
                    ServiceID = item.GuestTherapyID
                });
            }


            this.lbServisPlanList.ItemsSource = servisPlanList;

        }

        public void ListBoxClear()
        {
            this.lbServisPlanList.ItemsSource = null;
        }

        public void GetPersonelList()
        {
            loadPersonel = context.Load(context.GetSPA_PersonelJobDetailQuery());
            loadPersonel.Completed += loadPersonel_Completed;
        }

        void loadPersonel_Completed(object sender, EventArgs e)
        {
            this.BindGuestServicePlanList();

            foreach (var item in loadPersonel.Entities)
            {
                list.Add(new ServicePlanPersonelSurrogate { PersonelID = item.PersonelID, Adi = item.Adi, TherapyID = item.TherapyID });
            }
        }

        //Servise göre personeller listelenecek.
        public List<ServicePlanPersonelSurrogate> GetPersonelByTherapyID(Guid? therapyID)
        {
            var newPersonelList = list.Where(l => l.TherapyID == therapyID).ToList();
            schServisPlan.Storage.ResourceStorage.DataSource = newPersonelList;
            schServisPlan.Storage.ResourceStorage.Mappings.Caption = "Adi";
            schServisPlan.Storage.ResourceStorage.Mappings.Id = "PersonelID";
            return newPersonelList;
        }


        private void lbServisPlanList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox item = sender as ListBox;
            ServicePlanSurrogate servisPlanItem = item.SelectedItem as ServicePlanSurrogate;
            TherapyID = servisPlanItem.TherapyID;
            StartDateTime = servisPlanItem.ServisDateTime ?? DateTime.Now;
            GuestNote = servisPlanItem.GuestNote;
            TherapyName = servisPlanItem.TherapyName;
            GuestName = Reception.GuestName;
            ServicePlanID = servisPlanItem.ServiceID.ToString();
            GetPersonelByTherapyID(TherapyID);
        }

        void schServisPlan_EditAppointmentFormShowing(object sender, DevExpress.Xpf.Scheduler.EditAppointmentFormEventArgs e)
        {
            e.Form = new CustomAppointmentServicePlan(this, this.schServisPlan, e.Appointment, GetPersonelByTherapyID(TherapyID), RoomNumber, GuestID,
                GuestNote, StartDateTime, TherapyName, TherapyID, GuestName, ServicePlanID);
            e.AllowResize = false;
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
            return check;
        }



        bool check = false;
        private void BtnServisPlanSave_Click(object sender, RoutedEventArgs e)
        {
            check = true;
        }



        //private void cbPersonel_Loaded(object sender, RoutedEventArgs e)
        //{
        //    ComboBoxEdit cbe = sender as ComboBoxEdit;
        //    cbe.ItemsSource = list;
        //    cbe.DisplayMember = "Adi";
        //    cbe.ValueMember = "PersonelID";
        //}

        #region Class
        public class ServicePlanSurrogate
        {
            public Guid ServiceID { get; set; }
            public string TherapyName { get; set; }
            public Guid? TherapyID { get; set; }
            public string RoomNumber { get; set; }
            public string GuestFirstName { get; set; }
            public string GuestLastName { get; set; }
            public Guid PersonelID { get; set; }
            public DateTime? ServisDateTime { get; set; }
            public string EndTimePicker { get; set; }
            public string StartTimePicker { get; set; }
            public string GuestNote { get; set; }
            public string GuestNote2 { get; set; }
            public Guid GuestID { get; set; }
            public List<ServicePlanPersonelSurrogate> PersonelList { get; set; }
        }

        public class ServicePlanPersonelSurrogate
        {
            public Guid PersonelID { get; set; }
            public string Adi { get; set; }
            public Guid? TherapyID { get; set; }
        }

        public class ServicePlanReservationSurrogate
        {
            public Guid ID { get; set; }
            public Guid GuestID { get; set; }
            public bool IsCanceled { get; set; }
            public DateTime StartDateTime { get; set; }
            public DateTime EndDateTime { get; set; }
            public int TherapyID { get; set; }
            public int StatusID { get; set; }
            public string Desc { get; set; }
            public string Subject { get; set; }
            public string Location { get; set; }

        }

        #endregion







    }
}
