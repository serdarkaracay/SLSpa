using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media.Imaging;

namespace iDeal.silverlight.controls
{
	public partial class ServiceCheckControl : UserControl
	{
		public ServiceCheckControl()
		{
			// Required to initialize variables
			InitializeComponent();
			AutoDisconnectDuration = 10;
			timer.Interval=TimeSpan.FromSeconds ( AutoDisconnectDuration );
			timer.Tick += new EventHandler(timer_Tick);
            timer2.Interval = TimeSpan.FromSeconds(1);
            timer2.Tick += new EventHandler(timer2_Tick);
			
		}

        void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            VisualStateManager.GoToState(this, "connect", false);
            
        }

		void timer_Tick(object sender, EventArgs e)
		{
			Disconnect();
			timer.Stop();
		}
		DispatcherTimer timer=new DispatcherTimer();
        DispatcherTimer timer2 = new DispatcherTimer();
		
		public int AutoDisconnectDuration{get;set;}
		
		public void Receive()
		{
			timer.Stop();
			VisualStateManager.GoToState(this, "receive", false);
			timer.Start();
            timer2.Start();
		}
		
		public void Transmit()
		{
			timer.Stop();
			VisualStateManager.GoToState(this, "transmit", false);
			timer.Start();
            timer2.Start();
		}
		
		public void Disconnect()
		{
			VisualStateManager.GoToState(this, "disconnect", false); 
		}

        public void Connect()
        {
            VisualStateManager.GoToState(this, "connect", false); 
        }

        private void LayoutRoot_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
        	LayoutRoot.Opacity =1;
        }

        private void LayoutRoot_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
        	LayoutRoot.Opacity =.3;
        }

	}
}