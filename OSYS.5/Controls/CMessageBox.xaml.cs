﻿using System;
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
using OSYS.Classes.interfaces;

namespace OSYS
{
    public delegate void DialogResultHandler(EButton r);
    public enum EButtons
    {
        YesNo,
        Ok,
        OkCancel,
        None
    }
    public enum EIcon
    {
        Warning,
        Info,
        Error,
        Question,
        Help,
        Progress,
        None
    }
    public enum EButton
    {
        Yes,
        No,
        Ok,
        Cancel,
        None
    }

    public partial class CMessageBox : UserControl
    {
        public CMessageBox()
        {
            // Required to initialize variables
            InitializeComponent();
            Visibility = Visibility.Collapsed;
        }

        DialogResultHandler drh;

        public void Show(string msg, EButtons buttons, EIcon icon, DialogResultHandler r)
        {
            SetButtons(buttons);
            SetIcon(icon);
            drh = r;
            textBlock.Visibility = Visibility.Visible;
            textBlock.Text = msg;
            Visibility = Visibility.Visible;
        }

        public void Show(string msg, DialogResultHandler r)
        {
            Show(msg, EButtons.Ok, EIcon.None, r);
        }

        public void Show(string msg, EIcon icon, DialogResultHandler r)
        {
            Show(msg, EButtons.Ok, icon, r);
        }

        public void Show(string msg, EIcon icon)
        {
            Show(msg, EButtons.Ok, icon, null);
        }

        public void Show(string msg, EButtons buttons, DialogResultHandler r)
        {
            Show(msg, buttons, EIcon.None, r);
        }

        private IMsgBoxControl cont { get; set; }

        public void Show(IMsgBoxControl control, EButtons buttons, DialogResultHandler r)
        {
            //SetBackground();
            textBlock.Visibility = Visibility.Collapsed;
            gridControls.Children.Clear();
            gridControls.Children.Add(control as Control);
            SetButtons(buttons);
            SetIcon(EIcon.None);
            drh = r;
            cont = control;
            gridControls.Visibility = Visibility.Visible;
            Visibility = Visibility.Visible;
        }

        public void Show(Control control, EButtons buttons, DialogResultHandler r)
        {
            textBlock.Visibility = Visibility.Collapsed;
            gridControls.Children.Clear();
            gridControls.Children.Add(control);
            SetButtons(buttons);
            SetIcon(EIcon.None);
            drh = r;
             gridControls.Visibility = Visibility.Visible;
           Visibility = Visibility.Visible;
        }

        public void Show(string msg, EButtons buttons, EIcon icon)
        {
            Show(msg, buttons, icon, null);
        }

        public void Show(string msg, int showPeriod)
        {
            SetIcon(EIcon.None);
            SetButtons(EButtons.None);
            textBlock.Visibility = Visibility.Visible; 
            textBlock.Text = msg;
            Visibility = Visibility.Visible;
            SetTimer(showPeriod);
        }

        public void Show(string msg, EIcon icon, int showPeriod)
        {
            SetIcon(icon);
            SetButtons(EButtons.None);
            textBlock.Visibility = Visibility.Visible;
            textBlock.Text = msg;
            Visibility = Visibility.Visible;
            SetTimer(showPeriod);
        }
        public void BusyStart(string msg)
        {
            SetIcon(EIcon.Progress);
            SetButtons(EButtons.None);
            textBlock.Visibility = Visibility.Visible;
            textBlock.Text = msg;
            Visibility = Visibility.Visible;
        }
        public void SetBusyText(string msg)
        {

            try
            {
                textBlock.Text = msg;
            }
            catch
            {
                
               
            }
        
          
        }
        public void BusyEnd()
        {

            try
            {
               Visibility = Visibility.Collapsed; 
            }
            catch (Exception)
            {
                
               
            }
          
        }


        void SetIcon(EIcon icon)
        {
           
                switch (icon)
                {
                    case EIcon.Warning:
                        gridControls.Visibility = Visibility.Collapsed;
                        progress.Visibility = Visibility.Collapsed;
                        image.Source = (Resources["lw"] as ImageBrush).ImageSource;
                        image.Visibility = Visibility.Visible;
                        break;
                    case EIcon.Info:
                        gridControls.Visibility = Visibility.Collapsed;
                        progress.Visibility = Visibility.Collapsed;
                        image.Source = (Resources["li"] as ImageBrush).ImageSource;
                        image.Visibility = Visibility.Visible;
                        break;
                    case EIcon.Error:
                        gridControls.Visibility = Visibility.Collapsed;
                        progress.Visibility = Visibility.Collapsed;
                        image.Source = (Resources["le"] as ImageBrush).ImageSource;
                        image.Visibility = Visibility.Visible;
                        break;
                    case EIcon.Question:
                        gridControls.Visibility = Visibility.Collapsed;
                        progress.Visibility = Visibility.Collapsed;
                        image.Source = (Resources["lq"] as ImageBrush).ImageSource;
                        image.Visibility = Visibility.Visible;
                        break;
                    case EIcon.Progress:
                        gridControls.Visibility = Visibility.Collapsed;
                        image.Visibility = Visibility.Collapsed;
                        progress.Visibility = Visibility.Visible;
                        break;
                    case EIcon.None:
                    default:
                        progress.Visibility = Visibility.Collapsed;
                        image.Visibility = Visibility.Collapsed;
                        gridControls.Visibility = Visibility.Collapsed;
                        break;
                }
           
        }

        void SetButtons(EButtons buttons)
        {
           
                 switch (buttons)
                 {
                     case EButtons.YesNo:
                         gridButtons.Visibility =
                         gridYesNo.Visibility = Visibility.Visible;
                         gridOkCancel.Visibility =
                         gridOk.Visibility = Visibility.Collapsed;
                         Focus();
                         btnYes.Focus();
                         break;
                     case EButtons.Ok:
                         gridButtons.Visibility =
                         gridOk.Visibility = Visibility.Visible;
                         gridOkCancel.Visibility =
                         gridYesNo.Visibility = Visibility.Collapsed;
                         Focus();
                         btnOk.Focus();
                         break;
                     case EButtons.OkCancel:
                         gridButtons.Visibility =
                         gridOkCancel.Visibility = Visibility.Visible;
                         gridOk.Visibility =
                         gridYesNo.Visibility = Visibility.Collapsed;
                         Focus();
                         btnOk.Focus();
                         break;
                     case EButtons.None:
                         gridButtons.Visibility = Visibility.Collapsed;
                         break;
                 }
            
        }

        void SetTimer(int showPeriod)
        {
            DispatcherTimer timer=new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(showPeriod <= 0 ? 1 : showPeriod);
            timer.Tick += (s, e) => { Dispatcher.BeginInvoke(() => { Visibility = Visibility.Collapsed; timer.Stop(); }); };
            timer.Start();
        }

        private void btnLogon_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            if (drh != null) drh.Invoke(EButton.Yes);
        }

        private void btnLogon_Copy_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            if (drh != null) drh.Invoke(EButton.No);
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
           
            if (cont == null)
            {
                Visibility = Visibility.Collapsed;
                if (drh != null) drh.Invoke(EButton.Ok);
            }
            else
            {
                if (cont.Check(EButton.Ok))
                {
                    cont = null;
                    Visibility = Visibility.Collapsed;
                    if (drh != null) drh.Invoke(EButton.Ok);
                   
                }
               
               
                
            }
            
        }

        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            cont = null;
            Visibility = Visibility.Collapsed;
            if (drh != null) drh.Invoke(EButton.Cancel);
        }
    }
}