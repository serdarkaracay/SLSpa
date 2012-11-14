using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace OSYS.Web.DTO
{
    public class Customer
    {
        public Customer()
        { }
        public long ID { get; set; }
        public int GroupID { get; set; }
        public string Name { get; set; }
        public string CustomerNo { get; set; }

        public string GroupName { get; set; }
        public string Address { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string TaxOfficeName { get; set; }
        public string TaxOfficeNumber { get; set; }
    }

    [DataContract(Namespace = "")]
    public class CustomerGroup
    {
        public CustomerGroup()
        {
        }
        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
    }

    public class CustomerMeter
    {
        public CustomerMeter()
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

        public DeviceTypes()
        {
        }

        public int ID { get; set; }

        public string LongUnit { get; set; }

        public string Name { get; set; }

        public string Unit { get; set; }
    }

    public class InvoiceItem
    {

        public InvoiceItem()
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
        public Invoices()
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

    public partial class Meter
    {
        public Meter()
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

        public string MeterTypeName { get; set; }

        public int MeterTypeID { get; set; }

        public string Model { get; set; }

        public string SerialNo { get; set; }

        public bool Status { get; set; }

        public int TariffID { get; set; }
        public string TariffName { get; set; }


        public DateTime? WarrantyEndDate { get; set; }
        public int Invoiceday { get; set; }
        public int FinalPaymentDay { get; set; }

    }

    public class CustomerMeterDTO
    {
        public CustomerMeterDTO()
        {
        }
        public long ID { get; set; }
        public long CustomerID { get; set; }
        public long MeterID { get; set; }
        public string MeterNo { get; set; }
        public string SerialNo { get; set; }
        public string TypeName { get; set; }
        public string TariffName { get; set; }
        public string CustName { get; set; }
        public int MeterTypesID { get; set; } 


    }

    public class Tariff
    {
        public Tariff()
        {
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TariffCode { get; set; }

    }

    public class Prices
    {
        public Prices()
        {
        }
        public int ID { get; set; }
        public int IndexNo { get; set; }
        
        public int CalculationLevel { get; set; }

        public string Currency { get; set; }

        public decimal Factor { get; set; }

        public decimal MaxValue { get; set; }

        public decimal MinValue { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ShortName { get; set; }
        public string TariffName { get; set; }

        public int TariffID { get; set; }

    }

    public class InvoiceListDTO
    {
        public InvoiceListDTO()
        {

        }

        public long CustomerID { get; set; }

        public DateTime FinalPaymentDate { get; set; }

        public long Id { get; set; }

        public DateTime InvoiceDate { get; set; }

        public bool IsPaid { get; set; }

        public decimal KDV { get; set; }

        public decimal KDVTotalCost { get; set; }

        public string SerialNo { get; set; }

        public string MeterNo { get; set; }
        
        public string GroupName { get; set; }


        public string MeterTypeName { get; set; }

        public string Name { get; set; }

        public DateTime PaymentDate { get; set; }

        public string Period { get; set; }

        public DateTime ReportDate{ get; set; }

        public decimal TotalCost { get; set; }

    }

    public class PrepareInvoiceListDTO
    {
        public PrepareInvoiceListDTO()
        {

        }
        public string Name { get; set; }

        public string GroupName { get; set; }

        public string SerialNo { get; set; }

        public int InvoiceDay { get; set; }

        public DateTime? LastIndexReportDate { get; set; }
       
        public decimal T1 { get; set; }

        public decimal T2 { get; set; }

        public decimal T3 { get; set; }

        public decimal Toplam { get; set; }

        public string ImageUrl { get; set; }

   
    }

    public class ReportDTO
    {
        public ReportDTO()
        {

        }
        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string GroupName { get; set; }

        public string SerialNo { get; set; }
        
        public string TariffName { get; set; }

        public string  Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string MeterType { get; set; } 


        public int MeterTypesID { get; set; }
        


    }

    public sealed partial class MeterMonthV 
    {
        public MeterMonthV()
        {
        }
        public int DataGroupID {get; set;}
        public string DataGroupName { get; set; }
        public long Id { get; set; }
        public long MetersID { get; set; }
        public int MonthID { get; set; }
        public string MonthsName { get; set; }
        public decimal T1 { get; set; }
        public decimal T2 { get; set; }
        public decimal T3 { get; set; }
    
    }

     public class MeterSummary 
    {
         public MeterSummary()
        {
        }
        public int Years {get; set;}
        public string MonthName { get; set; }
        public int MonthID { get; set; }
        public decimal T1_ACTIVE { get; set; }
        public decimal T1_REACTIVE { get; set; }
        public decimal T1_DEMAND { get; set; }
        public decimal T2_ACTIVE { get; set; }
        public decimal T2_REACTIVE { get; set; }
        public decimal T2_DEMAND { get; set; }
        public decimal T3_ACTIVE { get; set; }
        public decimal T3_REACTIVE { get; set; }
        public decimal T3_DEMAND { get; set; }
    }


}