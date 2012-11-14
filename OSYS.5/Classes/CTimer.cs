using System;
using System.Collections.Generic;
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

namespace OSYS.Classes
{
    public delegate void TIMERHandler(object sender);
    public class CTimer
    {

        DispatcherTimer timer = new DispatcherTimer();
        List<TimerWorkItem> list = new List<TimerWorkItem>();


        public CTimer()
        {
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += new EventHandler(timer_Tick);

        }
        public CTimer(int interval)
        {
            timer.Interval = TimeSpan.FromMilliseconds(interval);
            timer.Tick += new EventHandler(timer_Tick);

        }

        public void Start()
        {
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (--list[i].TimeoutTicks <= 0)
                {
                    list[i].Job.Invoke(list[i].Sender);
                    list.RemoveAt(i);
                }
            }
        }


        public int SetTimeout(object sender, TIMERHandler th, int timesTick)
        {
            TimerWorkItem twi = new TimerWorkItem(sender, th, timesTick);
            return SetTimeout(twi);
        }

        public int SetTimeout(TimerWorkItem twi)
        {
            list.Add(twi);
            return twi.GetHashCode();
        }
    }

    public class TimerWorkItem
    {

        private TIMERHandler job;

        public TIMERHandler Job
        {
            get { return job; }
            set { job = value; }
        }

        private int timeoutTicks;

        public int TimeoutTicks
        {
            get { return timeoutTicks; }
            set { timeoutTicks = value; }
        }

        private object sender;

        public object Sender
        {
            get { return sender; }
            set { sender = value; }
        }

        public TimerWorkItem(object _sender, TIMERHandler _job, int _timeoutTicks)
        {
            this.Sender = _sender;
            this.Job = _job;
            this.TimeoutTicks = _timeoutTicks;
        }

    }

}
