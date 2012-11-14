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

namespace OSYS.Classes
{
    public class Customer
    {
        private Customer()
        { }

        public string Address { get; set; }

        public long CustomerGroupID { get; set; }

        public string EMail { get; set; }

        public long ID { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string TaxOfficeName { get; set; }

        public string TaxOfficeNumber { get; set; }
    }

    public class CustomerGroup
    {
        private CustomerGroup()
        {
        }
        public long ID { get; set; }
        public string Name { get; set; }
    }

    public class CustomerMeter
    {
        private CustomerMeter()
        {
        }

        public long CustomerID { get; set; }

        public long ID { get; set; }

        public long MeterID { get; set; }
    }

    public class CustomerV
    {
        public CustomerV()
        {
        }

        public string Address { get; set; }

        public string EMail { get; set; }

        public long GroupID { get; set; }

        public string GroupName { get; set; }

        public long ID { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string TaxOfficeName { get; set; }

        public string TaxOfficeNumber { get; set; }
    }

    public class DeviceTypes
    {

        private DeviceTypes()
        {
        }

        public int ID { get; set; }

        public string LongUnit { get; set; }

        public string Name { get; set; }

        public string Unit { get; set; }
    }

    public class InvoiceItem
    {

        private InvoiceItem()
        {
        }

        public double Amount { get; set; }

        public double Cost { get; set; }

        public long ID { get; set; }

        public long InvoiceID { get; set; }

        public long MeterID { get; set; }

        public int PriceID { get; set; }

        public double UnitPrice { get; set; }
    }

    public class Invoices
    {
        private Invoices()
        {
        }

        public long CostumerID { get; set; }

        public long CostumerMeter { get; set; }

        public DateTime FinalPaymentDate { get; set; }

        public long ID { get; set; }

        public DateTime InvoiceDate { get; set; }

        bool isPaid { get; set; }

        public long MeterID { get; set; }

        public DateTime PaymentDate { get; set; }

        public string Period { get; set; }

        public DateTime PeriodEndDate { get; set; }

        public DateTime PeriodStartDate { get; set; }

        public DateTime ReportDate { get; set; }

        public int Status { get; set; }

    }

    public partial class Meters
    {
        private Meters()
        {
        }

        public DateTime CreatedDate { get; set; }

        public string Description { get; set; }

        public decimal FirstIndex1 { get; set; }

        public decimal FirstIndex2 { get; set; }

        public decimal FirstIndex3 { get; set; }

        public DateTime FirstIndexReportDate { get; set; }

        public long ID { get; set; }

        public decimal LastIndex1 { get; set; }

        public decimal LastIndex2 { get; set; }

        public decimal LastIndex3 { get; set; }

        public DateTime LastIndexReportDate { get; set; }
        public string Mark { get; set; }

        public string MeterNo { get; set; }

        public int MeterTypeID { get; set; }

        public string Model { get; set; }

        public string SerialNo { get; set; }

        public bool Status { get; set; }

        public int TariffID { get; set; }


        public DateTime WarrantyEndDate { get; set; }
    }
}
