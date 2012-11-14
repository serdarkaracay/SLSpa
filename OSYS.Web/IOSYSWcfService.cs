using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using OSYS.Web.DTO;
using System.ServiceModel.Web;
using System.Data;

namespace OSYS.Web
{
    [ServiceContract]
    public interface IOSYSWcfService
    {

      
        [OperationContract]
        List<CustomerGroup> getCustomerGroup();

        [OperationContract]
        DataTable getInvoiceReportE();
     
        [OperationContract]
        List<Customer> getCustomerV();

         
        [OperationContract]
        List<Customer> getCustomerByGroupID(long groupID);
        
         
        [OperationContract]
        List<Prices> getPricesByTariffID(long tariffID);

         
        [OperationContract]
        List<Meter> getMeterV();

         
        [OperationContract]
        List<CustomerMeterDTO> getCustomerMeterV(long customerID);

        [OperationContract]
        List<CustomerMeterDTO> getAllCustomerMeterV();


         
        [OperationContract]
        List<Tariff> getTariff();

         
        [OperationContract]
        List<Prices> getPrices();

         [OperationContract]
        List<ReportDTO> getReports();

         
        [OperationContract]
        List<InvoiceListDTO> getInvoiceList(int MeterTypeID, DateTime InvoiceStartDate, DateTime InvoiceFinishDate, long? CustomerID, long? CustomerGroupID);

        [OperationContract]
        void deleteInvoiceList(int MeterTypeID, DateTime InvoiceStartDate, DateTime InvoiceFinishDate, long? CustomerID, long? CustomerGroupID);


    
 
        [OperationContract]
        List<PrepareInvoiceListDTO> getPrepareInvoiceList(int MeterTypeID, DateTime InvoiceStartDate, long? CustomerID, long? CustomerGroupID);
        
         
        [OperationContract]
        List<MeterMonthV> getMeterMonthsV(int groupID, long meterID);

        [OperationContract]
        List<MeterSummary> getMeterSummary(int years, long meterID);
         
        [OperationContract]
        List<DeviceTypes> getDeviceTypes();
        
         
        [OperationContract]
        List<InvoiceListDTO> getAllInvoiceByCustomerIDQuery(long customerID);


         
        [OperationContract]
        List<InvoiceListDTO> getInvoiceByCustomerID(long customerID, bool isPaid);


        [OperationContract]
        void createInvoiceReportE(int MeterTypeID, DateTime InvoiceStartDate, DateTime InvoiceFinishDate,
                                  long? CustomerID, long? CustomerGroupID);
       

         
        [OperationContract]
        void GetInvoiceReportW(int MeterTypeID, DateTime InvoiceStartDate, long? CustomerID, long? CustomerGroupID);

         
        [OperationContract]
        void CreateCustomer(long GroupID, string Name,string CustomerNo,  string Address, string Phone, string TaxOfficeName, string TaxOfficeNumber, string EMail, int statusFlg, long IDNo);

         [OperationContract]
         void CreateMeter(int? meterTypeID, string serialNo, int? tariffID, bool? status, DateTime? createdDate,
         string meterNo, string mark, string model, string description, DateTime? warrantyEndDate, Guid?
         RTUInstanceName, string RTUName, int? InvoiceDay, int? FinalPaymentDay, int? statusFlg, long? IDNo);

        [OperationContract]
         void CreateCustomerGroup(string name, string desc, int statusFlg, long IDNo);
        [OperationContract]
        void CreateCustomerMeter(long cusomerID, long meterID, int statusFlg, long IDNo);
        [OperationContract]
        void CreateInvoiceE(int meterTypeID, DateTime invoiceDate, long? customerID, long? customerGroupID);
        [OperationContract]
        void CreateInvoiceW(int meterTypeID, DateTime invoiceDate, long? customerID, long? customerGroupID);
        [OperationContract]
        void CreateTariff(string name, string desc, string tariffCode, int statusFlg, long IDNo);
        
        [OperationContract]
        void CreatePrice(
            int TariffID,
            int IndexNo,
            decimal MinValue,
            decimal MaxValue,
            decimal Price,
            string Name,
            decimal Factor,
            int CalculationLevel,
            string ShortName,
            int StatusFlg,
            int IDNo);

        [OperationContract]
        void DeleteMeter(long IDNo);
        [OperationContract]
        void DeleteCustomer(long IDNo);


    }
}
