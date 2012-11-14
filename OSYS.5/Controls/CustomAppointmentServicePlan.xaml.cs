using DevExpress.Xpf.Scheduler;
using DevExpress.XtraScheduler;
using OSYS.Web;
using System;
using System.Collections.Generic;
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
    public partial class CustomAppointmentServicePlan : UserControl
    {
        DSAtoz context = new DSAtoz();
        SchedulerControl control;
        LoadOperation<SPA_GuestTherapyDetail> loadOpGuestTherapy;
        Appointment appointment;

        List<OSYS.Controls.ServicePlan.ServicePlanPersonelSurrogate> personelList = new List<ServicePlan.ServicePlanPersonelSurrogate>();
        public string RoomNumber { get; set; }
        public string GuestID { get; set; }
        public string GuestNote { get; set; }
        public DateTime StartDateTime { get; set; }
        public string TherapyName { get; set; }
        public Guid? TherapyID { get; set; }
        public string GuestName { get; set; }
        public string ServicePlanID { get; set; }

        public CustomAppointmentServicePlan(SchedulerControl control, Appointment apt, List<OSYS.Controls.ServicePlan.ServicePlanPersonelSurrogate> list, string roomNumber, string guestID, string guestNote,
            DateTime startDateTime, string therapyName, Guid? therapyID, string guestName, string servicePlanID)
        {
            InitializeComponent();
            if (control == null || apt == null)
                throw new ArgumentNullException("control");
            if (control == null || apt == null)
                throw new ArgumentNullException("apt");



            RoomNumber = roomNumber;
            GuestID = guestID;
            GuestNote = guestNote;
            personelList = list;
            StartDateTime = startDateTime;

            cbPersonelList.Clear();
            cbPersonelList.ItemsSource = list;
            cbPersonelList.DisplayMember = "Adi";
            cbPersonelList.ValueMember = "PersonelID";

            TherapyName = therapyName;
            TherapyID = therapyID;
            GuestName = guestName;
            ServicePlanID = servicePlanID;


        }

        public CustomAppointmentServicePlan()
        { }


        public SchedulerControl Control { get { return control; } }
        public Appointment app { get; set; }

        private void BtnServisPlanSave_Click(object sender, RoutedEventArgs e)
        {
            RezervationInsert();
        }

        public void RezervationInsert()
        {
            string beginTime = StartDateTime.ToShortDateString();

            DateTime? beginClock = new DateTime();
            beginClock = tpStartTime.Value as DateTime?;

            DateTime? endClock = new DateTime();
            endClock = tpEndTime.Value as DateTime?;

            DateTime beginDateTime = Convert.ToDateTime(beginTime + " " + beginClock.Value.TimeOfDay.ToString());
            DateTime endDateTime = Convert.ToDateTime(beginTime + " " + endClock.Value.TimeOfDay.ToString());


            SPA_RezervationSchedule reservation = new SPA_RezervationSchedule();
            reservation.ID = Guid.NewGuid();
            reservation.PersonelID = Guid.Parse(cbPersonelList.EditValue.ToString());
            reservation.GuestID = Guid.Parse(GuestID);
            reservation.IsCanceled = false;
            reservation.Location = TherapyName;
            reservation.StartDateTime = beginDateTime;
            reservation.EndDateTime = endDateTime;
            reservation.TherapyID = TherapyID;
            reservation.StatusID = 0;
            reservation.GuestNote = GuestNote + "--" + txtServisNote.Text;
            reservation.Subject = RoomNumber + "  " + GuestName;
            context.SPA_RezervationSchedules.Add(reservation);

            loadOpGuestTherapy = context.Load(context.GetTherapyGuestDetailQuery(ServicePlanID),
                new Action<LoadOperation<SPA_GuestTherapyDetail>>(GetSpa_TherapyGuestDetailUpdate), true);

        }


        private void GetSpa_TherapyGuestDetailUpdate(LoadOperation<SPA_GuestTherapyDetail> args)
        {
            if (args.Entities.Count() > 0)
            {
                SPA_GuestTherapyDetail db = args.Entities.First();
                db.IsCompleted = true;
            }
            context.SubmitChanges().Completed += CustomAppointmentServicePlan_Completed;
        }

        void CustomAppointmentServicePlan_Completed(object sender, EventArgs e)
        {
            ServicePlan sp = new ServicePlan();
            sp.BindSchedulerResource();
            sp.BindGuestServicePlanList();
            SchedulerFormBehavior.Close(this, false);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SchedulerFormBehavior.SetTitle(this, GuestName+" "+TherapyName);
        }


    }
}
