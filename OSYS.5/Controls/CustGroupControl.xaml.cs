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
//using OSYS.ServiceReference1;
using OSYS.Pages;
using OSYS.Classes.interfaces;

namespace OSYS.Controls
{

    //public partial class CustGroupControl : UserControl, IMsgBoxControl
    //{
      
    //    OSYSWcfServiceClient service;
    //    OSYS.ServiceReference1.CustomerGroup customerGroupRecieved = new OSYS.ServiceReference1.CustomerGroup();
    //    public event EventHandler TaskComplated;


    //    public CustGroupControl(OSYS.ServiceReference1.CustomerGroup customerGroup)
    //    {
    //        InitializeComponent();
    //        customerGroupRecieved = customerGroup;


    //        if (customerGroupRecieved!=null)
    //        {
    //            txtHeader.Text = "Grup Düzenleme";
    //        }

    //        //service = new OSYSWcfServiceClient();
            
    //        if (customerGroupRecieved != null)
    //        {
    //            txtName.Text = customerGroupRecieved.Name == null ? "" : customerGroupRecieved.Name;
    //            txtDesc.Text = customerGroupRecieved.Description == null ? "" : customerGroupRecieved.Description;

    //        }


    //       // service.getCustomerGroupCompleted += new EventHandler<getCustomerGroupCompletedEventArgs>(service_getCustomerGroupCompleted);
    //      //  service.getCustomerGroupAsync();
    //    }



    //    public void Update()
    //    {

    //        service.CreateCustomerGroupCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(service_CreateCustomerGroupCompleted);

    //        if (customerGroupRecieved == null)
    //        {
    //            //Yeni kayıt eklenecek

    //            //(CustomerGroup)cmbGroup.SelectedItem).ID

    //            service.CreateCustomerGroupAsync(txtName.Text, txtDesc.Text, 0, 0);



    //        }
    //        else
    //        //Güncelleme yapılacak
    //        {

    //            service.CreateCustomerGroupAsync(txtName.Text, txtDesc.Text, 1, customerGroupRecieved.ID);
    //        }
            
    //    }

    //    void service_CreateCustomerGroupCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    //    {
    //        if (TaskComplated != null) TaskComplated(this, null);
    //    }

    //     public string getName()
    //    {
    //        return txtName.Text;
    //    }

       

    //     //public string checkError()
    //     //{
    //     //    string strErr = string.Empty;

    //     //    if (string.IsNullOrEmpty(txtName.Text))
    //     //    {                 
    //     //        strErr = "Lütfen grup adını giriniz.";
    //     //        txtError.Text = strErr;
    //     //    }

    //     //    return strErr;
    //     //}

    //     public Exception CheckError { get; set; }

    //     public bool Check(EButton b)
    //     {
    //         if (b == EButton.Ok)
    //         {
    //             string strErr = string.Empty;

    //             if (string.IsNullOrEmpty(txtName.Text))
    //             {
    //                 strErr = "Lütfen grup adını giriniz.";
    //                 txtError.Text = strErr;
    //                 CheckError = new Exception(strErr);
    //                 return false;
    //             }
    //             return true;

    //         }
    //         else
    //         {
    //             return false;
    //         }
    //     }
    //}
}
