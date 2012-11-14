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
using System.Windows.Threading;
using iDeal.silverlight.controls;

namespace iDeal.silverlight.classes
{
    public class CSyncService : CService
    {
        public event DataDownloadedHandler  OnUpdated;
        public event EventHandler OnUpdateRequested;
        public event EventHandler OnStarted;
        public event DataDownloadedHandler OnFirstUpdate;
        public event EventHandler OnStopped;
        public event ExceptionHandler OnException;

        public int UserID { get; set; }
        public int ServicePeriodSecond { get; set; }
        public int Index { get; set; }
        public string ProcedureName { get; set; }
        public EServiceStatus Status { get { return status; } }
        public ServiceCheckControl ServiceCheckControl { get; set; }

        public CSyncService()
            : base()
        {

        }

        public CSyncService(int userID,string procedureName)
            : this()
        {
            Index = 0;
            UserID = userID;
            ProcedureName = procedureName; 
            timer.Interval = TimeSpan.FromMilliseconds(5);
            timer.Tick += new EventHandler(timer_Tick);
        }



        public void Start()
        {
            isContinueRetreive = true;
                 if (OnStarted != null) OnStarted(this, null);
                status = EServiceStatus.Open;
                 Parent.Dispatcher.BeginInvoke(() =>
            { timer.Start();  }); 
        }

        public void Stop()
        {
            isContinueRetreive = false;
            if (OnStopped != null) OnStopped(this, null);
            status = EServiceStatus.Close;

               timer.Stop();   
       ServiceCheckControl.Dispatcher.BeginInvoke(() =>
            {
                ServiceCheckControl.Disconnect();
            });
        }

        protected void ContinueRetrieve()
        {
           
          
                timer.Interval = TimeSpan.FromSeconds(ServicePeriodSecond);
            ServiceCheckControl.Receive();
            timer.Start();
      
            }

        DispatcherTimer timer        = new DispatcherTimer();
        bool firstUse           = true;
        EServiceStatus status   = EServiceStatus.Close;
        bool isContinueRetreive=true;

        void timer_Tick(object sender, EventArgs e)
        {
             timer.Stop();
           
            if (isContinueRetreive)
            {
                ServiceCheckControl.Dispatcher.BeginInvoke(() =>
                {
                    ServiceCheckControl.Transmit ();
                }); 
                if (OnUpdateRequested != null) OnUpdateRequested(this, null);
                GetData(this, ProcedureName + " " + UserID + "," + Index,
                             (s, xml) =>
                             {
                                 CSyncService ss=s as CSyncService;
                                 if (firstUse)
                                 {
                                     if (OnFirstUpdate != null) { firstUse = false; OnFirstUpdate(this, xml); }
                                 }
                                 else
                                 {
                                     if (OnUpdated != null) OnUpdated(this, xml);
                                 }
                                 xml = null;

                                 ss.Parent. Dispatcher.BeginInvoke(() =>
                                 {
                                     ss.ContinueRetrieve();
                                 });
                
                             },
                             (s, ex) =>
                             {
                                 CSyncService ss=s as CSyncService;
                                 if (OnException != null) OnException(s, ex);
                                
                                 ss.Parent. Dispatcher.BeginInvoke(() =>
                                 { ss.ContinueRetrieve(); });
                             });


            }
        }

    }
}
