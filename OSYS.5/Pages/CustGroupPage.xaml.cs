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
//using OSYS.ServiceReference1;
using OSYS.Controls;
using System.IO;
using System.Text;
using System.Windows.Data;
using System.Reflection;
using C1.Silverlight.DataGrid;
using C1.Silverlight;
using OSYS.Classes.interfaces;
using OSYS.Classes;

namespace OSYS.Pages
{
    public partial class CustGroupPage : AuthenticatedPage
    {
        //OSYSWcfServiceClient service;
        SaveFileDialog objSFD = null;
        public CustGroupPage()
            
        {
            InitializeComponent();
            this.Title = "Abone Grupları";
            //service = new OSYSWcfServiceClient();            
            //service.getCustomerGroupCompleted += new EventHandler<getCustomerGroupCompletedEventArgs>(service_getCustomerGroupCompleted);
            //service.getCustomerGroupAsync();
            objSFD = new SaveFileDialog();
            objSFD.Filter = "Excel Files | *.xls";
            objSFD.DefaultExt = "xls";
            //btngrExport.Clicked += new CGroupButtonsClickEventHandler(btngrExport_Clicked);

        }

        //void btngrExport_Clicked(CButton sender)
        //{
        //    switch (sender.Index)
        //    {
        //        case 0: //EXCEL
        //            objSFD.Filter = "Excel Files | *.xls";
        //            objSFD.DefaultExt = "xls";
        //            UIDriver.ExportToExcel(cgGrid, objSFD);
        //            break;
        //        case 1: //CSV
        //            objSFD.Filter = "Text Files | *.csv";
        //            objSFD.DefaultExt = "csv";
        //            UIDriver.ExportToExcel(cgGrid, objSFD);
        //            break;
        //        case 2: //XML
        //            objSFD.Filter = "XML Files | *.xml";
        //            objSFD.DefaultExt = "xml";
        //            UIDriver.ExportToExcel(cgGrid, objSFD);
        //            break;
        //        case 3: //PNG
        //            container.NotImplemented();
        //            break;
        //        case 4: //PDF
        //            container.NotImplemented();
        //            break;
        //    }
        //}
   

    
        //void service_getCustomerGroupCompleted(object sender, getCustomerGroupCompletedEventArgs e)
        //{
        //    cgGrid.ItemsSource = e.Result;
        //    container.BusyEnd();
        //}



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

       
        void cusc_TaskComplated(object sender, EventArgs e)
        {
           //RefreshList();

        }
        //private void RefreshList()
        //{
        //    service.getCustomerGroupCompleted+=new EventHandler<getCustomerGroupCompletedEventArgs>(service_getCustomerGroupCompleted);
        //    service.getCustomerGroupAsync();
        //}



        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void dELETEButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {

        //    CustGroupControl cusc = new CustGroupControl(null);
        //    cusc.TaskComplated += new EventHandler(cusc_TaskComplated);
        ////    cusc.Parent = container.cMessageBox1;
        //    container.MsgBox((IMsgBoxControl)cusc, EButtons.OkCancel, (r) =>
        //    {
        //        switch (r)
        //        {
        //            case EButton.Ok:
        //                container.BusyStart("Bekleyiniz...");
        //                cusc.Update();
        //                break;
        //            case EButton.Cancel:
        //                break;
        //        }


        //    });

            //container.MsgBox(cusc, EButtons.OkCancel, (r) =>
            //{
            //    switch (r)
            //    {
            //        case EButton.Ok:
            //            container.BusyStart("Bekleyiniz...");
            //            cusc.Update();
            //            break;
            //        case EButton.Cancel:
            //            break;
            //    }


            //});

        }

        //private void btnUpdate_Clicked(object sender, EventArgs e)
        //{
        //    if (cgGrid.SelectedItem != null)
        //    {
        //        CustGroupControl cusc = new CustGroupControl((OSYS.ServiceReference1.CustomerGroup)cgGrid.SelectedItem);
        //        cusc.TaskComplated += new EventHandler(cusc_TaskComplated);
        //        container.MsgBox((IMsgBoxControl)cusc, EButtons.OkCancel, (r) =>
        //        {
        //            switch (r)
        //            {
        //                case EButton.Ok:                    

        //                    container.BusyStart("Bekleyiniz...");
        //                    cusc.Update();
        //                    break;
        //                case EButton.Cancel:
        //                    break;
        //            }


        //        });
        //    }
        //    else
        //    {
        //        container.MsgBox("Listeden grup seçiniz.", EIcon.Error);

        //    }
        //}

        //private void btnDelete_Clicked(object sender, EventArgs e)
        //{

        //    if (cgGrid.SelectedItem != null)
        //    {
        //        container.MsgBox("Grubu silmek istiyormusunuz?", EButtons.YesNo, EIcon.Question, (r) =>
        //        {
        //            if (r == EButton.Yes)
        //            {
        //                container.BusyStart("Bekleyiniz...");

        //                long customerGroupID = ((OSYS.ServiceReference1.CustomerGroup)cgGrid.SelectedItem).ID;
        //                service.CreateCustomerGroupCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(service_CreateCustomerGroupCompleted);
        //                service.CreateCustomerGroupAsync(null,null,2,customerGroupID);
        //            }

        //        });

        //    }

         
        //}

        void service_CreateCustomerGroupCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            //RefreshList();
        }

        private void AuthenticatedPage_Loaded(object sender, RoutedEventArgs e)
        {
            container.BusyStart("Bekleyiniz...");
        }

        private void cgGrid_LoadedCellPresenter(object sender, DataGridCellEventArgs e)
        {

            var helper = new C1MouseHelper(e.Cell.Presenter);
            helper.MouseDoubleClick += (s, a) =>
            {
               // ShowDetail();

            };
        }

        //private void ShowDetail()
        //{
        //    if (cgGrid.SelectedItem != null)
        //    {
        //        GroupControlDetail met = new GroupControlDetail((OSYS.ServiceReference1.CustomerGroup) cgGrid.SelectedItem);
        //        container.MsgBox(met, EButtons.Ok, (r) =>
        //                                               {
        //                                                   switch (r)
        //                                                   {
        //                                                       case EButton.Ok:
        //                                                           break;
        //                                                       case EButton.Cancel:
        //                                                           break;
        //                                                   }
        //                                               });
        //    }
        //}

        //private void cButton1_Clicked(object sender, EventArgs e)
        //{
        //    ShowDetail();
        //}

    }
}
