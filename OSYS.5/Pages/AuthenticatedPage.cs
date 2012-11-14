using DevExpress.Xpf.Scheduler;
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

namespace OSYS.Pages
{
    public class AuthenticatedPage : BasePage
    {
        public AuthenticatedPage():base()
        {
           
        }
        public  bool Authenticate()
        {
            return Security.CurrentUser != null;
        }

        public  bool Authorize()
        {
            return true;
        }

        protected object FindResource(string key)
        {
            return Resources[key];
        }
        readonly List<SchedulerViewBase> views = new List<SchedulerViewBase>();
        protected List<SchedulerViewBase> Views { get { return views; } }
    }
}
