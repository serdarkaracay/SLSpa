using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using OSYS.Web.DBServices;
using System.Configuration;
using OSYS.Web.DTO;
using System.Data;

namespace OSYS.Web
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,
                 InstanceContextMode = InstanceContextMode.PerSession)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class OSYSWcfService : IOSYSWcfService
    {
        string connectionString = string.Empty;
        CSqlOperator sqlOp;
        Dictionary<string, object> sqlprm;
        int i = 0;

        public OSYSWcfService()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            sqlOp = new CSqlOperator(connectionString);
            sqlprm = new Dictionary<string, object>();
        }

        public List<CustomerGroup> getCustomerGroup()
        {
            sqlprm.Clear();
            DataTable dtGroup = this.sqlOp.executeSPInstantly("OSYS..sp_GetCustomerGroup", sqlprm);
            CustomerGroup cg;
            List<CustomerGroup> sgList = new List<CustomerGroup>();

            foreach (DataRow row in dtGroup.Rows)
            {
                cg = new CustomerGroup();
                cg.ID = Convert.ToInt64(row["ID"]);
                cg.Name = row["Name"].ToString();
                cg.Description = row["Description"] == null ? null : row["Description"].ToString();
                sgList.Add(cg);
            }
            return sgList;
        }


        public DataTable getInvoiceReportE()
        {
            sqlprm.Clear();
            //sqlprm = new Dictionary<string, object>();
            //sqlprm.Add("InvoiceID", InvoiceID);
            DataTable dtCus = this.sqlOp.executeSPInstantly("OSYS..sp_GetInvoiceReportE", sqlprm);
            return (dtCus);

        }

        public DataTable getInvoiceReportW()
        {
            sqlprm.Clear();
            //sqlprm = new Dictionary<string, object>();
            //sqlprm.Add("InvoiceID", InvoiceID);
            DataTable dtCus = this.sqlOp.executeSPInstantly("OSYS..sp_GetInvoiceReportW", sqlprm);
            return (dtCus);

        }


        

        public List<Customer> getCustomerV()
        {
            sqlprm.Clear();
            DataTable dtCus = this.sqlOp.executeSPInstantly("OSYS..sp_GetCustomerV", sqlprm);
            Customer cus;
            List<Customer> cusList = new List<Customer>();

            foreach (DataRow row in dtCus.Rows)
            {
                cus = new Customer();
                cus.ID = Convert.ToInt64(row["ID"]);
                cus.GroupID = Convert.ToInt32(row["GroupID"]);
                cus.Name = row["Name"] == null ? null : row["Name"].ToString();
                cus.GroupName = row["GroupName"] == null ? null : row["GroupName"].ToString();
                cus.CustomerNo = row["CustomerNo"] == null ? null : row["CustomerNo"].ToString();
                cus.Address = row["Address"] == null ? null : row["Address"].ToString();
                cus.EMail = row["EMail"] == null ? null : row["EMail"].ToString();
                cus.Phone = row["Phone"] == null ? null : row["Phone"].ToString();
                cus.TaxOfficeName = row["TaxOfficeName"] == null ? null : row["TaxOfficeName"].ToString();
                cus.TaxOfficeNumber = row["TaxOfficeNumber"] == null ? null : row["TaxOfficeNumber"].ToString();
                cusList.Add(cus);
            }
            dtCus.Clear();
            return cusList;
        }

        public List<Customer> getCustomerByGroupID(long groupID)
        {
            sqlprm.Clear();
            sqlprm = new Dictionary<string, object>();
            sqlprm.Add("groupID", groupID);
            DataTable dtCus = this.sqlOp.executeSPInstantly("OSYS..sp_GetCustomerByGroupID", sqlprm);
            Customer cus;
            List<Customer> cusList = new List<Customer>();

            foreach (DataRow row in dtCus.Rows)
            {
                cus = new Customer();
                cus.Name = row["Name"] == null ? null : row["Name"].ToString();
                cus.EMail = row["EMail"] == null ? null : row["EMail"].ToString();
                cus.Phone = row["Phone"] == null ? null : row["Phone"].ToString();
             
                cusList.Add(cus);
            }
            dtCus.Clear();
            return cusList;
        }


        public List<Meter> getMeterV()
        {

            sqlprm.Clear();
            DataTable dtMeter = this.sqlOp.executeSPInstantly("OSYS..sp_GetMeterV", sqlprm);
            Meter meter;
            List<Meter> meterList = new List<Meter>();

            foreach (DataRow row in dtMeter.Rows)
            {
                meter = new Meter();
                meter.ID = Convert.ToInt64(row["ID"]);
                meter.MeterTypeID = Convert.ToInt32(row["MeterTypeID"]);
                meter.MeterTypeName = row["MeterTypeName"] == null ? null : row["MeterTypeName"].ToString();
                meter.SerialNo = row["SerialNo"] == null ? null : row["SerialNo"].ToString();
                meter.TariffID = Convert.ToInt32(row["TariffID"]);
                meter.TariffName = row["TariffName"] == null ? null : row["TariffName"].ToString();
                // meter.CreatedDate = Convert.ToDateTime(row["CreatedDate"]);
                meter.MeterNo = row["MeterNo"] == null ? null : row["MeterNo"].ToString();
                meter.Mark = row["Mark"] == null ? null : row["Mark"].ToString();
                meter.Model = row["Model"] == null ? null : row["Model"].ToString();
                meter.Description = row["Description"] == null ? null : row["Description"].ToString();
                meter.Status = Convert.ToBoolean(row["Status"]);
                // meter.WarrantyEndDate = row["WarrantyEndDate"] == null ? DateTime.MinValue : Convert.ToDateTime(row["WarrantyEndDate"]);
                meter.Invoiceday = Convert.ToInt32(row["Invoiceday"]);
                meter.FinalPaymentDay = Convert.ToInt32(row["FinalPaymentDay"]);
                meterList.Add(meter);
            }
            dtMeter.Clear();
            return meterList;
        }

        public List<CustomerMeterDTO> getCustomerMeterV(long customerID)
        {

            sqlprm.Clear();
            sqlprm = new Dictionary<string, object>();
            sqlprm.Add("customerID", customerID);

            DataTable dtCm = this.sqlOp.executeSPInstantly("OSYS..sp_GetCustomerMeterV", sqlprm);
            CustomerMeterDTO cmDTO;
            List<CustomerMeterDTO> cmDTOList = new List<CustomerMeterDTO>();

            foreach (DataRow row in dtCm.Rows)
            {
                cmDTO = new CustomerMeterDTO();
                cmDTO.ID = Convert.ToInt64(row["ID"]);
                cmDTO.CustomerID = Convert.ToInt64(row["CustomerID"]);
                cmDTO.TariffName = row["TariffName"] == null ? null : row["TariffName"].ToString();
                cmDTO.MeterNo = row["MeterNo"] == null ? null : row["MeterNo"].ToString();
                cmDTO.SerialNo = row["SerialNo"] == null ? null : row["SerialNo"].ToString();
                cmDTO.TypeName = row["TypeName"] == null ? null : row["TypeName"].ToString();

                cmDTOList.Add(cmDTO);


            }
            dtCm.Clear();
            return cmDTOList;
        }

        public List<CustomerMeterDTO> getAllCustomerMeterV()
        {

            sqlprm.Clear();
            sqlprm = new Dictionary<string, object>();
           

            DataTable dtCm = this.sqlOp.executeSPInstantly("OSYS..sp_getAllCustomerMeterV", sqlprm);
            CustomerMeterDTO cmDTO;
            List<CustomerMeterDTO> cmDTOList = new List<CustomerMeterDTO>();

            foreach (DataRow row in dtCm.Rows)
            {
                cmDTO = new CustomerMeterDTO();
                cmDTO.ID = Convert.ToInt64(row["ID"]);
                cmDTO.CustomerID = Convert.ToInt64(row["CustomerID"]);
                cmDTO.MeterTypesID = Convert.ToInt32(row["MeterTypesID"]);
                cmDTO.TariffName = row["TariffName"] == null ? null : row["TariffName"].ToString();
                cmDTO.MeterNo = row["MeterNo"] == null ? null : row["MeterNo"].ToString();
                cmDTO.SerialNo = row["SerialNo"] == null ? null : row["SerialNo"].ToString();
                cmDTO.TypeName = row["TypeName"] == null ? null : row["TypeName"].ToString();
                cmDTO.CustName = row["CustName"] == null ? null : row["CustName"].ToString();
                cmDTO.MeterID = Convert.ToInt64(row["MeterID"]);
        
                cmDTOList.Add(cmDTO);


            }
            dtCm.Clear();
            return cmDTOList;
        }

        public List<Tariff> getTariff()
        {

            sqlprm.Clear();

            DataTable dtTariff = this.sqlOp.executeSPInstantly("OSYS..sp_GetTariffs", sqlprm);
            Tariff trf;
            List<Tariff> tariffList = new List<Tariff>();

            foreach (DataRow row in dtTariff.Rows)
            {
                trf = new Tariff();
                trf.ID = Convert.ToInt32(row["ID"]);
                trf.Name = row["Name"] == null ? null : row["Name"].ToString();
                trf.TariffCode = row["TariffCode"] == null ? null : row["TariffCode"].ToString();
                trf.Description = row["Description"] == null ? null : row["Description"].ToString();

                tariffList.Add(trf);


            }
            dtTariff.Clear();
            return tariffList;
        }



        public List<Prices> getPrices()
        {

            sqlprm.Clear();

            DataTable dtPrices = this.sqlOp.executeSPInstantly("OSYS..sp_GetPricesV", sqlprm);
            Prices prc;
            List<Prices> priceList = new List<Prices>();

            foreach (DataRow row in dtPrices.Rows)
            {
                prc = new Prices();
                prc.ID = Convert.ToInt32(row["ID"]);
                prc.Price = Convert.ToDecimal(row["Price"]);
                prc.TariffID = Convert.ToInt32(row["TariffID"]);
                prc.Factor = Convert.ToDecimal(row["Factor"]);
                prc.MaxValue = Convert.ToDecimal(row["MaxValue"]);
                prc.MinValue = Convert.ToDecimal(row["MinValue"]);
                prc.Name = row["Name"] == null ? null : row["Name"].ToString();
                prc.TariffName = row["TariffName"] == null ? null : row["TariffName"].ToString();
                prc.IndexNo = Convert.ToInt32(row["IndexNo"]);
                prc.CalculationLevel = Convert.ToInt32(row["CalculationLevel"]);
                prc.ShortName = row["ShortName"] == null ? null : row["ShortName"].ToString();

                priceList.Add(prc);


            }
            dtPrices.Clear();
            return priceList;
        }
        public List<Prices> getPricesByTariffID(long tariffID)
        {

            sqlprm.Clear();
            sqlprm = new Dictionary<string, object>();
            sqlprm.Add("tariffID", tariffID);

            DataTable dtPrices = this.sqlOp.executeSPInstantly("OSYS..sp_GetPriceByTariffID", sqlprm);
            Prices prc;
            List<Prices> priceList = new List<Prices>();

            foreach (DataRow row in dtPrices.Rows)
            {
                prc = new Prices();
                prc.ID = Convert.ToInt32(row["ID"]);
                prc.Price = Convert.ToDecimal(row["Price"]);
                prc.TariffID = Convert.ToInt32(row["TariffID"]);
                prc.Factor = Convert.ToDecimal(row["Factor"]);
                prc.MaxValue = Convert.ToDecimal(row["MaxValue"]);
                prc.MinValue = Convert.ToDecimal(row["MinValue"]);
                prc.Name = row["Name"] == null ? null : row["Name"].ToString(); 
                prc.IndexNo = Convert.ToInt32(row["IndexNo"]);
                prc.CalculationLevel = Convert.ToInt32(row["CalculationLevel"]);
                prc.ShortName = row["ShortName"] == null ? null : row["ShortName"].ToString();

                priceList.Add(prc);


            }
            dtPrices.Clear();
            return priceList;
        }


        public List<InvoiceListDTO> getInvoiceList(int MeterTypeID, DateTime InvoiceStartDate, DateTime InvoiceFinishDate, long? CustomerID, long? CustomerGroupID)
        {

            sqlprm.Clear();
            sqlprm.Add("MeterTypeID", MeterTypeID);
            sqlprm.Add("InvoiceStartDate", InvoiceStartDate);
            sqlprm.Add("InvoiceFinishDate", InvoiceFinishDate);
            sqlprm.Add("CustomerID", CustomerID);
            sqlprm.Add("CustomerGroupID", CustomerGroupID);

            DataTable dtInvList = this.sqlOp.executeSPInstantly("OSYS..sp_GetInvoiceList", sqlprm);
            InvoiceListDTO inv;
            List<InvoiceListDTO> invoiceList = new List<InvoiceListDTO>();

            /*
       Invoices.ID
      ,Customer.Name
      ,CustomerGroup.Name as GroupName    
      ,MeterTypes.Name MeterTypeName 
      ,Invoices.InvoiceDate     
      ,Meters.SerialNo   
      ,ReportDate
      ,KDV
      ,TotalCost
      ,KDVTotalCost  
             */

            foreach (DataRow row in dtInvList.Rows)
            {
                inv = new InvoiceListDTO();
                inv.Id = Convert.ToInt64(row["ID"]);
                inv.CustomerID = Convert.ToInt32(row["CustomerID"]);
                inv.Name = row["Name"] == null ? null : row["Name"].ToString();
                inv.GroupName = row["GroupName"] == null ? null : row["GroupName"].ToString();
                inv.InvoiceDate = Convert.ToDateTime(row["InvoiceDate"]);             
                inv.SerialNo = row["SerialNo"] == null ? null : row["SerialNo"].ToString();
                inv.MeterTypeName = row["MeterTypeName"] == null ? null : row["MeterTypeName"].ToString();
                inv.KDV = Convert.ToDecimal(row["Kdv"]);
                inv.KDVTotalCost = Convert.ToDecimal(row["KdvTotalCost"]);
                inv.TotalCost = Convert.ToDecimal(row["TotalCost"]);

                invoiceList.Add(inv);


            }
            dtInvList.Clear();
            return invoiceList;
        }
        public void deleteInvoiceList(int MeterTypeID, DateTime InvoiceStartDate, DateTime InvoiceFinishDate, long? CustomerID, long? CustomerGroupID)
        {

            sqlprm.Clear();
            sqlprm.Add("MeterTypeID", MeterTypeID);
            sqlprm.Add("InvoiceStartDate", InvoiceStartDate);
            sqlprm.Add("InvoiceFinishDate", InvoiceFinishDate);
            sqlprm.Add("CustomerID", CustomerID);
            sqlprm.Add("CustomerGroupID", CustomerGroupID);

            sqlOp.executeSP("OSYS..sp_DeleteInvoiceList", sqlprm);
        }


        public void createInvoiceReportE(int MeterTypeID, DateTime InvoiceStartDate, DateTime InvoiceFinishDate, long? CustomerID, long? CustomerGroupID)
        {
            sqlprm.Clear();
            sqlprm.Add("MeterTypeID", MeterTypeID);
            sqlprm.Add("InvoiceStartDate", InvoiceStartDate);
            sqlprm.Add("InvoiceFinishDate", InvoiceFinishDate);
            sqlprm.Add("CustomerID", CustomerID);
            sqlprm.Add("CustomerGroupID", CustomerGroupID);
            this.sqlOp.executeSP("OSYS..sp_InvoiceReportE", sqlprm);
          
        }

        public void createInvoiceReportW(int MeterTypeID, DateTime InvoiceStartDate, DateTime InvoiceFinishDate, long? CustomerID, long? CustomerGroupID)
        {
            sqlprm.Clear();
            sqlprm.Add("MeterTypeID", MeterTypeID);
            sqlprm.Add("InvoiceStartDate", InvoiceStartDate);
            sqlprm.Add("InvoiceFinishDate", InvoiceFinishDate);
            sqlprm.Add("CustomerID", CustomerID);
            sqlprm.Add("CustomerGroupID", CustomerGroupID);
            this.sqlOp.executeSP("OSYS..sp_InvoiceReportW", sqlprm);

        }


        public List<DeviceTypes> getDeviceTypes()
        {

            sqlprm.Clear();

            DataTable dtDType = this.sqlOp.executeSPInstantly("OSYS..sp_GetDeviceTypes", sqlprm);
            DeviceTypes dType;
            List<DeviceTypes> dTypeList = new List<DeviceTypes>();

            foreach (DataRow row in dtDType.Rows)
            {
                dType = new DeviceTypes();
                dType.ID = Convert.ToInt32(row["ID"]);
                dType.Name = row["Name"] == null ? null : row["Name"].ToString();

                dTypeList.Add(dType);
            }

            dtDType.Clear();
            return dTypeList;
        }

        public List<InvoiceListDTO> getAllInvoiceByCustomerIDQuery(long customerID)
        {
            sqlprm = new Dictionary<string, object>();
            sqlprm.Add("customerID", customerID);

            DataTable dtInvList = this.sqlOp.executeSPInstantly("OSYS..sp_GetAllInvoiceByCustomerID", sqlprm);
            InvoiceListDTO inv;
            List<InvoiceListDTO> invoiceList = new List<InvoiceListDTO>();

            foreach (DataRow row in dtInvList.Rows)
            {

                inv = new InvoiceListDTO();
                inv.CustomerID = Convert.ToInt32(row["CustomerID"]);
                inv.InvoiceDate = Convert.ToDateTime(row["InvoiceDate"]);
                inv.FinalPaymentDate = Convert.ToDateTime(row["FinalPaymentDate"]);
                inv.PaymentDate = Convert.ToDateTime(row["PaymentDate"]);
                inv.IsPaid = Convert.ToBoolean(row["IsPaid"]);
                inv.MeterNo = row["MeterNo"] == null ? null : row["MeterNo"].ToString();
                inv.MeterTypeName = row["MeterTypeName"] == null ? null : row["MeterTypeName"].ToString();
                inv.KDV = Convert.ToDecimal(row["Kdv"]);
                inv.KDVTotalCost = Convert.ToDecimal(row["KdvTotalCost"]);
                inv.TotalCost = Convert.ToDecimal(row["TotalCost"]);
                invoiceList.Add(inv);

            }
            dtInvList.Clear();
            return invoiceList;


        }

        public List<InvoiceListDTO> getInvoiceByCustomerID(long customerID, bool isPaid)
        {
            sqlprm = new Dictionary<string, object>();
            sqlprm.Add("customerID", customerID);
            sqlprm.Add("isPaid", isPaid);

            DataTable dtInvList = this.sqlOp.executeSPInstantly("OSYS..sp_GetInvoiceByCustomerID", sqlprm);
            InvoiceListDTO inv;
            List<InvoiceListDTO> invoiceList = new List<InvoiceListDTO>();

            foreach (DataRow row in dtInvList.Rows)
            {

                inv = new InvoiceListDTO();
                inv.CustomerID = Convert.ToInt32(row["CustomerID"]);
                inv.InvoiceDate = Convert.ToDateTime(row["InvoiceDate"]);
                inv.FinalPaymentDate = Convert.ToDateTime(row["FinalPaymentDate"]);
                inv.PaymentDate = Convert.ToDateTime(row["PaymentDate"]);
                inv.IsPaid = Convert.ToBoolean(row["IsPaid"]);
                inv.MeterNo = row["MeterNo"] == null ? null : row["MeterNo"].ToString();
                inv.MeterTypeName = row["MeterTypeName"] == null ? null : row["MeterTypeName"].ToString();
                inv.KDV = Convert.ToDecimal(row["KDV"]);
                inv.KDVTotalCost = Convert.ToDecimal(row["KDVTotalCost"]);
                inv.TotalCost = Convert.ToDecimal(row["TotalCost"]);
                invoiceList.Add(inv);

            }
            dtInvList.Clear();
            return invoiceList;
        }

        public List<PrepareInvoiceListDTO> getPrepareInvoiceList(int MeterTypeID, DateTime InvoiceStartDate, long? CustomerID, long? CustomerGroupID)
        {
            Dictionary<string, object> sqlprm = new Dictionary<string, object>();
            sqlprm.Add("MeterTypeID", MeterTypeID);
            sqlprm.Add("InvoiceStartDate", InvoiceStartDate);
            sqlprm.Add("CustomerID", CustomerID);
            sqlprm.Add("CustomerGroupID", CustomerGroupID);
        
            DataTable dtInvList = this.sqlOp.executeSPInstantly("OSYS..sp_PrepareInvoiceList", sqlprm);
            PrepareInvoiceListDTO inv;
            List<PrepareInvoiceListDTO> invoiceList = new List<PrepareInvoiceListDTO>();

            foreach (DataRow row in dtInvList.Rows)
            {
                
                inv = new PrepareInvoiceListDTO();                           
                inv.Name = row["Name"] == null ? null : row["Name"].ToString();
                inv.GroupName = row["GroupName"] == null ? null : row["GroupName"].ToString();
                inv.SerialNo = row["SerialNo"] == null ? null : row["SerialNo"].ToString();
                inv.InvoiceDay = Convert.ToInt32(row["InvoiceDay"]);          
                inv.LastIndexReportDate =Convert.IsDBNull(row["LastIndexReportDate"])? (DateTime?)null:Convert.ToDateTime(row["LastIndexReportDate"]);

                inv.T1 = Convert.ToDecimal(row["T1"]);
                inv.T2 = Convert.ToDecimal(row["T2"]);
                inv.T3 = Convert.ToDecimal(row["T3"]);
                inv.Toplam = Convert.ToDecimal(row["TOPLAM"]);
                if (inv.Toplam <= 0)
                {
                    inv.ImageUrl = "../Images/erroricon32.png";
                }
                else
                {
                    inv.ImageUrl = "../Images/okicon32.png";
                }

                invoiceList.Add(inv);
            }
            dtInvList.Clear();
            return invoiceList;

            /*
            Name, 
            GroupName,
            SerialNo,
            InvoiceDay, 
            LastIndexReportDate,
            T1,
            T2,
            T3,
            TOPLAM       
             * */


        }


        public List<ReportDTO> getReports()
        {
         
            DataTable dtInvList = this.sqlOp.executeSPInstantly("OSYS..sp_getReports", sqlprm);
            ReportDTO inv;
            List<ReportDTO> invoiceList = new List<ReportDTO>();

            foreach (DataRow row in dtInvList.Rows)
            {
                inv = new ReportDTO();
                inv.Name = row["Name"] == null ? null : row["Name"].ToString();
                inv.GroupName = row["GroupName"] == null ? null : row["GroupName"].ToString();
                inv.MeterType = row["MeterType"] == null ? null : row["MeterType"].ToString();
                inv.SerialNo = row["SerialNo"] == null ? null : row["SerialNo"].ToString();
                inv.TariffName = row["TariffName"] == null ? null : row["TariffName"].ToString();
                inv.Address = row["Address"] == null ? null : row["Address"].ToString();
                inv.Phone = row["Phone"] == null ? null : row["Phone"].ToString();
                inv.Email = row["Email"] == null ? null : row["Email"].ToString();
                inv.MeterTypesID = Convert.ToInt32(row["MeterTypesID"]);


                switch (inv.MeterTypesID)
                {
                    case 1:
                        inv.ImageUrl = "../Images/electricity.png";
                        break;
                    case 2:
                        inv.ImageUrl = "../Images/water.png";
                        break;
                    case 3:
                        inv.ImageUrl = "../Images/gas.png";
                        break;
                }

                invoiceList.Add(inv);
            }
            dtInvList.Clear();
            return invoiceList;

            /*
           GroupName,
           Name,
           TypeName MeterType,
           SerialNo,
           TariffName,
           [Address],
           Phone,
           Email,
           MeterTypesID
             * 
             * */


        }



        public void GetInvoiceReportE(int MeterTypeID, DateTime InvoiceStartDate, long? CustomerID, long? CustomerGroupID)
        {
            Dictionary<string, object> sqlprm = new Dictionary<string, object>();
            sqlprm.Add("MeterTypeID", MeterTypeID);
            sqlprm.Add("InvoiceStartDate", InvoiceStartDate);
            sqlprm.Add("CustomerID", CustomerID);
            sqlprm.Add("CustomerGroupID", CustomerGroupID);

            sqlOp.executeSP("OSYS..sp_CreateCustomer", sqlprm);
            sqlprm.Clear();

        }

        public void GetInvoiceReportW(int MeterTypeID, DateTime InvoiceStartDate, long? CustomerID, long? CustomerGroupID)
        {
            Dictionary<string, object> sqlprm = new Dictionary<string, object>();
            sqlprm.Add("MeterTypeID", MeterTypeID);
            sqlprm.Add("InvoiceStartDate", InvoiceStartDate);
            sqlprm.Add("CustomerID", CustomerID);
            sqlprm.Add("CustomerGroupID", CustomerGroupID);

            sqlOp.executeSP("OSYS..sp_CreateCustomer", sqlprm);
            sqlprm.Clear();

        }


        public void CreateCustomer(long GroupID, string Name,string CustomerNo, string Address, string Phone, string TaxOfficeName, string TaxOfficeNumber, string EMail, int statusFlg, long IDNo)
        {
            sqlprm = new Dictionary<string, object>();
            sqlprm.Add("@CustomerGroupID", GroupID);
            sqlprm.Add("Name", Name);
            sqlprm.Add("CustomerNo", CustomerNo);
            sqlprm.Add("Address", Address);
            sqlprm.Add("Phone", Phone);
            sqlprm.Add("TaxOfficeName", TaxOfficeName);
            sqlprm.Add("TaxOfficeNumber", TaxOfficeNumber);
            sqlprm.Add("EMail", EMail);
            sqlprm.Add("statusFlg", statusFlg);
            sqlprm.Add("IDNo", IDNo);

            sqlOp.executeSP("OSYS..sp_CreateCustomer", sqlprm);
            sqlprm.Clear();


        }

        public void DeleteCustomer(long IDNo)
        {
            sqlprm.Add("IDNo", IDNo);
            sqlOp.executeSP("OSYS..sp_DeleteCustomer", sqlprm);
            sqlprm.Clear();
        }

        public void CreateCustomerGroup(string name, string desc, int statusFlg, long IDNo)
        {
            sqlprm = new Dictionary<string, object>();
            sqlprm.Add("name", name);
            sqlprm.Add("Desc", desc);
            sqlprm.Add("statusFlg", statusFlg);
            sqlprm.Add("IDNo", IDNo);
            sqlOp.executeSP("OSYS..sp_CreateCustomerGroup", sqlprm);
            sqlprm.Clear();

        }

        public void CreateCustomerMeter(long customerID, long meterID, int statusFlg, long IDNo)
        {
            sqlprm = new Dictionary<string, object>();
            sqlprm.Add("customerID", customerID);
            sqlprm.Add("meterID", meterID);
            sqlprm.Add("statusFlg", statusFlg);
            sqlprm.Add("IDNo", IDNo);

            sqlOp.executeSP("OSYS..sp_CreateCustomerMeter", sqlprm);
            sqlprm.Clear();

        }

        public void CreateInvoiceE(int meterTypeID, DateTime invoiceDate, long? customerID, long? customerGroupID)
        {
            sqlprm = new Dictionary<string, object>();
            sqlprm.Add("meterTypeID", meterTypeID);
            sqlprm.Add("InvoiceStartDate", invoiceDate);
            sqlprm.Add("customerID", customerID);
            sqlprm.Add("customerGroupID", customerGroupID);

            sqlOp.executeSP("OSYS..sp_CreateInvoiceE", sqlprm);
            sqlprm.Clear();
        }


        public void CreateInvoiceW(int meterTypeID, DateTime invoiceDate, long? customerID, long? customerGroupID)
        {
            sqlprm = new Dictionary<string, object>();
            sqlprm.Add("meterTypeID", meterTypeID);
            sqlprm.Add("InvoiceStartDate", invoiceDate);
            sqlprm.Add("customerID", customerID);
            sqlprm.Add("customerGroupID", customerGroupID);

            sqlOp.executeSP("OSYS..sp_CreateInvoiceW", sqlprm);
            sqlprm.Clear();


        }

        public void CreateTariff(string name, string desc, string tariffCode, int statusFlg, long IDNo)
        {
            sqlprm = new Dictionary<string, object>();
            sqlprm.Add("name", name);
            sqlprm.Add("desc", desc);
            sqlprm.Add("tariffCode", tariffCode);
            sqlprm.Add("statusFlg", statusFlg);
            sqlprm.Add("IDNo", IDNo);
            sqlOp.executeSP("OSYS..sp_CreateTariffs", sqlprm);
            sqlprm.Clear();

        }
        public void CreatePrice(
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
            int IDNo)
        {
            sqlprm = new Dictionary<string, object>();
            sqlprm.Add("TariffID", TariffID);
            sqlprm.Add("IndexNo", IndexNo);
            sqlprm.Add("MinValue", MinValue);
            sqlprm.Add("MaxValue", MaxValue);
            sqlprm.Add("Price", Price);
            sqlprm.Add("Name", Name);
            sqlprm.Add("Factor", Factor);
            sqlprm.Add("CalculationLevel", CalculationLevel);
            sqlprm.Add("ShortName", ShortName);
            sqlprm.Add("statusFlg", StatusFlg);
            sqlprm.Add("IDNo", IDNo);

            sqlOp.executeSP("OSYS..sp_CreatePrice", sqlprm);
            sqlprm.Clear();

        }

        public void CreateMeter(int? meterTypeID, string serialNo, int? tariffID, bool? status, DateTime? createdDate,
         string meterNo, string mark, string model, string description, DateTime? warrantyEndDate, Guid?
         RTUInstanceName, string RTUName, int? InvoiceDay, int? FinalPaymentDay, int? statusFlg, long? IDNo)
        {
            Dictionary<string, object> sqlprm = new Dictionary<string, object>();
            sqlprm.Add("meterTypeID", meterTypeID);
            sqlprm.Add("serialNo", serialNo);
            sqlprm.Add("tariffID", tariffID);
            sqlprm.Add("status", status);
            sqlprm.Add("createdDate", createdDate);
            sqlprm.Add("meterNo", meterNo);
            sqlprm.Add("mark", mark);
            sqlprm.Add("model", model);
            sqlprm.Add("description", description);
            sqlprm.Add("warrantyEndDate", warrantyEndDate);
            // sqlprm.Add("RTUInstanceName", RTUInstanceName);
            // sqlprm.Add("RTUName", RTUName);
            sqlprm.Add("InvoiceDay", InvoiceDay);
            sqlprm.Add("FinalPaymentDay", FinalPaymentDay);
            sqlprm.Add("statusFlg", statusFlg);
            sqlprm.Add("IDNo", IDNo);
            sqlOp.executeSP("OSYS..sp_CreateMeters", sqlprm);
            sqlprm.Clear();

        }

        public void DeleteMeter(long IDNo)
        {
            sqlprm = new Dictionary<string, object>();
            sqlprm.Add("IDNo", IDNo);
            sqlOp.executeSP("OSYS..sp_DeleteMeters", sqlprm);
            sqlprm.Clear();

        }

        public List<MeterMonthV> getMeterMonthsV(int groupID, long meterID)
        {
            Dictionary<string, object> sqlprm = new Dictionary<string, object>();
            sqlprm.Add("dataGroupID", groupID);
            sqlprm.Add("meterID", meterID);


            DataTable dtCm = this.sqlOp.executeSPInstantly("OSYS..sp_GetMeterMonthsV", sqlprm);
            MeterMonthV cmDTO;
            List<MeterMonthV> cmDTOList = new List<MeterMonthV>();

            foreach (DataRow row in dtCm.Rows)
            {
                cmDTO = new MeterMonthV();
                cmDTO.DataGroupID = Convert.ToInt32(row["DataGroupID"]);
                cmDTO.MetersID = Convert.ToInt32(row["MetersID"]);
                cmDTO.MonthID = Convert.ToInt32(row["MonthID"]);
                cmDTO.DataGroupName = row["DataGroupName"] == null ? null : row["DataGroupName"].ToString();
                cmDTO.MonthsName = row["MonthsName"] == null ? null : row["MonthsName"].ToString();
                cmDTO.T1 = Convert.ToDecimal(row["T1"]);
                cmDTO.T2 = Convert.ToDecimal(row["T2"]);
                cmDTO.T3 = Convert.ToDecimal(row["T3"]);
                cmDTOList.Add(cmDTO);

            }
            dtCm.Clear();
            return cmDTOList;
        }

        public List<MeterSummary> getMeterSummary(int years, long meterID)
        {
            Dictionary<string, object> sqlprm = new Dictionary<string, object>();
            sqlprm.Add("years", years);
            sqlprm.Add("meterID", meterID);


            DataTable dtCm = this.sqlOp.executeSPInstantly("OSYS..sp_GetMeterSummary", sqlprm);
            MeterSummary cmDTO;
            List<MeterSummary> cmDTOList = new List<MeterSummary>();

            foreach (DataRow row in dtCm.Rows)
            {
                cmDTO = new MeterSummary();
                cmDTO.Years = Convert.ToInt32(row["Years"]);
                cmDTO.MonthID = Convert.ToInt32(row["MonthID"]);
                cmDTO.MonthName = row["MonthName"] == null ? null : row["MonthName"].ToString();
              
                cmDTO.T1_ACTIVE = Convert.ToDecimal(row["T1_ACTIVE"]);
                cmDTO.T1_REACTIVE = Convert.ToDecimal(row["T1_REACTIVE"]);
                cmDTO.T1_DEMAND = Convert.ToDecimal(row["T1_DEMAND"]);

                cmDTO.T2_ACTIVE = Convert.ToDecimal(row["T2_ACTIVE"]);
                cmDTO.T2_REACTIVE = Convert.ToDecimal(row["T2_REACTIVE"]);
                cmDTO.T2_DEMAND = Convert.ToDecimal(row["T2_DEMAND"]);
               
                cmDTO.T3_ACTIVE = Convert.ToDecimal(row["T3_ACTIVE"]);
                cmDTO.T3_REACTIVE = Convert.ToDecimal(row["T3_REACTIVE"]);
                cmDTO.T3_DEMAND = Convert.ToDecimal(row["T3_DEMAND"]);


                cmDTOList.Add(cmDTO);

            }
            dtCm.Clear();
            return cmDTOList;
        }




    }
}


