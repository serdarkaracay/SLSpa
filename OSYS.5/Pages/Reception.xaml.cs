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
using DevExpress.XtraScheduler;
using System.ServiceModel.DomainServices.Client;
using System.ServiceModel.DomainServices;
using System.Collections.ObjectModel;
using OSYS.Web;
using DevExpress.Xpf.Scheduler.UI;
using DevExpress.Xpf.Scheduler;
using OSYS.Controls;
using DevExpress.Xpf.Scheduler.Drawing;
using System.Windows.Media.Imaging;
using System.IO;
using OSYS.Classes;
using OSYS.Classes.interfaces;

namespace OSYS.Pages
{
    public partial class Reception : AuthenticatedPage
    {
        DSAtoz context = new DSAtoz();
        DSCapriceOfis ctxOfis = new DSCapriceOfis();
        LoadOperation<OSYS.Web.DTO.DbPersonelJobDetail> loadOP;
        LoadOperation<SPA_RezervationSchedule> loadOpResSch;
        LoadOperation<View_SPA_GuestReservation> loadOpView;
        LoadOperation<Personel> loadPersonel;
        LoadOperation<View_SPA_ScheduleReservation> loadViewSch;
        LoadOperation<OSYS.Web.DTO.DBIzinPersonel> loadIzinPersonel;
        List<PersonelIzin> personelIzinList = new List<PersonelIzin>();
        LoadOperation<OSYS.Web.DTO.DbPersonelTherapy> loadOpPersonelJobDetail;

        public Reception()
        {
            InitializeComponent();
            IzinPersonelInsert();
            ScheduleAyarlar();
            BindGuestListBox();
            BindSchedulerResource();
            BindFizyoterapist();
            //BindLabesList();
            SchRefres();
            ApplyHorizontalResourceHeaderStyle();
        }

        Storyboard timer = new Storyboard();


        #region ScheduleAyarlar
        public void ScheduleAyarlar()
        {
            schRezervasyon.Start = DateTime.Now.AddDays(1);
            DataTemplate template = (DataTemplate)this.Resources["AppointmentCustoTooltip"];
            schRezervasyon.DayView.AppointmentToolTipContentTemplate = template;
            schRezervasyon.DayView.AppointmentDisplayOptions.SnapToCellsMode = AppointmentSnapToCellsMode.Never;
        }
        #endregion

        #region ResourceHeaderImage
        private void ApplyHorizontalResourceHeaderStyle()
        {
            Style style = (Style)this.FindResource("HorizontalResourceHeaderStyle");
            foreach (SchedulerViewBase view in Views)
            {
                view.HorizontalResourceHeaderStyle = style;
            }
        }

        private void ClearHorizontalResourceHeaderStyle()
        {
            foreach (SchedulerViewBase view in Views)
            {
                view.ClearValue(SchedulerViewBase.HorizontalResourceHeaderStyleProperty);
            }
        }
        #endregion

        #region IzinliPersonel
        public void IzinPersonelInsert()
        {
            loadIzinPersonel = context.Load(context.InsertIzinliPersonelQuery());
            loadIzinPersonel.Completed += loadIzinPersonel_Completed;
        }

        void loadIzinPersonel_Completed(object sender, EventArgs e)
        {

        }
        #endregion


        bool bindSchedulerRes = false;
        public DateTime SelectedDatetime { get; set; }
        public void BindSchedulerResource()
        {

            bindSchedulerRes = true;
            loadOpResSch = context.Load(context.GetSPA_RezervationScheduleQuery());
            loadOpResSch.Completed += loadOpResSch_Completed;

            loadOP = context.Load(context.GetResourcePersonelQuery());
            loadOP.Completed += loadOP_Completed;

        }

        void loadOpResSch_Completed(object sender, EventArgs e)
        {
            AppointmentStorage aptstor = schRezervasyon.Storage.AppointmentStorage;
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

        public void BindLabesList()
        {
            DurumList durumlar = new DurumList();
            schRezervasyon.Storage.AppointmentStorage.Labels.Clear();
            foreach (var item in durumlar.GetDurumList())
            {
                AppointmentLabel label = new AppointmentLabel(item.Renk, item.DurumAdi, item.DurumAdi);
                schRezervasyon.Storage.AppointmentStorage.Labels.Add(label);

            }
        }

        void loadOP_Completed(object sender, EventArgs e)
        {

            this.schRezervasyon.Storage.ResourceStorage.DataSource = loadOP.Entities;
            this.schRezervasyon.Storage.ResourceStorage.Mappings.Caption = "Adi";
            this.schRezervasyon.Storage.ResourceStorage.Mappings.Id = "PersonelID";
            this.schRezervasyon.Storage.ResourceStorage.Mappings.Image = "PersonelPhoto";

        }

        public void BindGuestListBox()
        {
            loadViewSch = context.Load(context.GetView_SPA_ScheduleReservationQuery());
            loadViewSch.Completed += loadViewSch_Completed;
        }

        void loadViewSch_Completed(object sender, EventArgs e)
        {
            listBoxReservation.ItemsSource = loadViewSch.Entities;
        }


        private void autoCompRoomNumber_Populating(object sender, PopulatingEventArgs e)
        {
            if (!context.IsLoading)
            {
                loadOpView = context.Load(context.GetViewSpaGuestReservationQuery(autoCompRoomNumber.Text), false);
                loadOpView.Completed += loadOpView_Completed;

            }
        }

        void loadOpView_Completed(object sender, EventArgs e)
        {
            //todo:Listbook null ise ne değeri verebiliriz.
            listBoxMisafir.ItemsSource = loadOpView.Entities;
        }

        private void btnMisafirGecmis_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMisafirYeni_Click(object sender, RoutedEventArgs e)
        {
            SPA_GuestDiagnosisDetail guestFizyo = new SPA_GuestDiagnosisDetail();
            guestFizyo.ID = Guid.NewGuid();
            guestFizyo.PersonelID = new Guid(cbFizyoterapist.EditValue.ToString());
            guestFizyo.GuestID = GuestID;
            guestFizyo.DiagnosisID = Guid.Parse("A584AB63-6039-45DD-94FB-8C8A1D43DB1C"); //'Seçiniz' varsayılan ekleniyor.
            guestFizyo.DescDiagnosis = "Misafir Tehşis";
            guestFizyo.Completed = false;
            guestFizyo.CompletedDateTime = DateTime.Now;
            context.SPA_GuestDiagnosisDetails.Add(guestFizyo);
            MessageBox.Show("Misafir Kaydedildi.");
            context.SubmitChanges().Completed += Reception_Completed;


        }

        void Reception_Completed(object sender, EventArgs e)
        {
            uiDriver.Activate(EPages.Rezervasyon);
            autoCompRoomNumber.Text = string.Empty;
            listBoxMisafir.ItemsSource = null;
        }



        private void listBoxMisafir_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox item = sender as ListBox;
            View_SPA_GuestReservation guest = item.SelectedItem as View_SPA_GuestReservation;
            if (item.SelectedItems.Count > 0)
            {
                GuestID = guest.ID;
                GuestName = guest.FirstName + " " + guest.Name;
                Number = guest.Number;

            }

        }

        public void BindFizyoterapist()
        {
            loadPersonel = ctxOfis.Load(ctxOfis.GetPersonelByFizyoterapistQuery(), false);
            loadPersonel.Completed += loadPersonel_Completed;
        }

        void loadPersonel_Completed(object sender, EventArgs e)
        {
            cbFizyoterapist.ItemsSource = loadPersonel.Entities;
            cbFizyoterapist.DisplayMember = "Adi";
            cbFizyoterapist.ValueMember = "OID";
        }

        //private void schRezervasyon_EditAppointmentFormShowing(object sender, DevExpress.Xpf.Scheduler.EditAppointmentFormEventArgs e)
        //{

        //    e.Form = new CustomAppointmentForm(this.schRezervasyon, e.Appointment, GuestName, TherapyID, GuestID, TherapyName, ServisTime, Number);
        //    e.AllowResize = false;
        //    TherapyID = 0;
        //}



        public long TherapyID { get; set; }
        public static string GuestName { get; set; }
        public string GuestNote { get; set; }
        public string TherapyName { get; set; }
        public int ServisTime { get; set; }
        public string Number { get; set; }
        public Guid PersonelID { get; set; }
        public Guid GuestID { get; set; }


        private void listBoxReservation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox item = sender as ListBox;
            View_SPA_ScheduleReservation guest = item.SelectedItem as View_SPA_ScheduleReservation;
            if (item.SelectedItems.Count > 0)
            {
                string _guestid = guest.GuestID.ToString();
                Number = guest.Number;
                GuestName = guest.FirstName + " " + guest.Name;
                ServicePlan model = new ServicePlan(_guestid, Number);
                container.BusyStart("Bekleyiniz.");
                container.MsgBox((IMsgBoxControl)model, EButtons.OkCancel, (r) =>
                {
                    if (r == EButton.Ok)
                    {


                    }
                });
            }
        }


        #region Durumlar

        public class Durum
        {
            public int DurumID { get; set; }
            public string DurumAdi { get; set; }
            public Color Renk { get; set; }

        }

        public class DurumList
        {
            public List<Durum> GetDurumList()
            {
                List<Durum> list = new List<Durum>();
                list.Add(new Durum { DurumAdi = "Ücretli", Renk = Colors.Orange, DurumID = 1 });
                list.Add(new Durum { DurumAdi = "Ücretsiz", Renk = Colors.LightGray, DurumID = 0 });
                return list;
            }

            public DurumList()
            {
            }
        }

        #endregion



        public void SchRefres()
        {
            int Interval = 3000;

            timer.Duration = new TimeSpan(0, 0, 0, Interval);
            timer.Completed += timer_Completed;
        }

        void timer_Completed(object sender, EventArgs e)
        {
            timer.Stop();
            BindSchedulerResource();
            timer.Begin();
        }

        private void schRezervasyon_AppointmentDrop(object sender, AppointmentDragEventArgs e)
        {

        }

        private void schRezervasyon_AppointmentResized(object sender, AppointmentResizeEventArgs e)
        {

        }

        public void BindServisList(string PersonelID)
        {
            loadOpPersonelJobDetail = context.Load(context.GetPersonelJobByAppointmentQuery(PersonelID));
            loadOpPersonelJobDetail.Completed += loadOpPersonelJobDetail_Completed;
        }

        void loadOpPersonelJobDetail_Completed(object sender, EventArgs e)
        {

            cbServisList.ItemsSource = loadOpPersonelJobDetail.Entities;
            cbServisList.ValueMember = "TherapyID";
            cbServisList.DisplayMember = "TherapyName";
        }

        private void resCb_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            Resource value = new Resource();
            value = (resCb.EditValue as Resource);
            this.BindServisList(value.Id.ToString());
        }

        private void BtnRezerve_Click(object sender, RoutedEventArgs e)
        {
            this.ReservationInsert();
        }

        public void ReservationInsert()
        {
            string beginTime = dateStart.DateTime.ToShortDateString();
            string endTime = dateEnd.DateTime.ToShortDateString();

            DateTime? beginClock = new DateTime();
            beginClock = tpStart.Value as DateTime?;

            DateTime? endClock = new DateTime();
            endClock = tpEnd.Value as DateTime?;

            DateTime beginDateTime = Convert.ToDateTime(beginTime + " " + beginClock.Value.TimeOfDay.ToString());
            DateTime endDateTime = Convert.ToDateTime(endTime + " " + endClock.Value.TimeOfDay.ToString());


            OSYS.Web.DTO.DbPersonelTherapy therapy = cbServisList.SelectedItem as OSYS.Web.DTO.DbPersonelTherapy;
            string _TherapyName = therapy.TherapyName;


            DevExpress.Xpf.Scheduler.Drawing.NamedElement personel = cbPersonelList.SelectedItem as DevExpress.Xpf.Scheduler.Drawing.NamedElement;
            Resource personelID = personel.Id as Resource;
            PersonelID = Guid.Parse(personelID.Id.ToString());

            SPA_RezervationSchedule reservation = new SPA_RezervationSchedule();
            reservation.ID = Guid.NewGuid();
            reservation.PersonelID = PersonelID;
            reservation.GuestID = GuestID;
            reservation.IsCanceled = false;
            reservation.Location = _TherapyName;
            reservation.StartDateTime = beginDateTime;
            reservation.EndDateTime = endDateTime;
            reservation.TherapyID = Guid.Parse(cbServisList.EditValue.ToString());
            reservation.StatusID = 1;
            reservation.GuestNote = txtDesc.Text;
            reservation.Subject = Number + "  " + GuestName;
            context.SPA_RezervationSchedules.Add(reservation);
            context.SubmitChanges().Completed += Reception_Completed;
        }

    }

}
