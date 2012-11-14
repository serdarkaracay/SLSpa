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
using OSYS.Classes.interfaces;
using OSYS.Web;
using System.ServiceModel.DomainServices.Client;
using OSYS.Model;
using OSYS.Pages;
using DevExpress.Xpf.Editors;

namespace OSYS.Controls
{
    public partial class ServiceListControl : UserControl, IMsgBoxControl
    {
        private DSAtoz _atozContext = new DSAtoz();
        LoadOperation<SPA_Therapy> loadOp;
        public static string ServisAdi { get; set; }

        public ServiceListControl()
        {
            InitializeComponent();
            this.BindServisList();
            cbServisList.SelectedIndexChanged += cbServisList_SelectedIndexChanged;
        }

        public static string ServisAd()
        {
            return ServisAdi;
        }

        public void BindServisList()
        {
            loadOp = _atozContext.Load(_atozContext.GetSPA_TherapyQuery());
            loadOp.Completed += loadOp_Completed;


        }

        void loadOp_Completed(object sender, EventArgs e)
        {
            cbServisList.ItemsSource = loadOp.Entities;
            cbServisList.DisplayMember = "TherapyName";
            cbServisList.ValueMember = "ID";
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

            return true;

        }


        public static string ServisID { get; set; }

        //public int ServisID()
        //{
        //    if (cbServisList.SelectedIndex > 0)
        //    {
        //        _serviceID = Convert.ToInt32(cbServisList.SelectedValue.ToString());
        //    }
        //    return _serviceID;

        //}

        private void cbServisList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void cbServisList_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            ServisID = cbServisList.EditValue.ToString();
            ComboBoxEdit item = sender as ComboBoxEdit;
            SPA_Therapy value = item.SelectedItem as SPA_Therapy;
            ServisAdi = value.TherapyName;

        }
    }
}
