using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InsuranceIssueApp.BLL;
using InsuranceIssueApp.Model;
using System.Data;
using System.IO;
using ExcelDataReader;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Globalization;
using InsuranceIssueApp.Common;
using Newtonsoft.Json;

namespace InsuranceIssueApp.Controllers
{
    [SessionExpire]
    public class EnquiryController : Controller
    {
        private readonly IEnquiryManager manager = null;
        public EnquiryController()
        {
            manager = new EnquiryManager();
        }
        // GET: Enquiry
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewEnquiry()
        {
            return View();
        }

       
        public ActionResult GetAllEnquiries(string  fromdate, string todate )
        {
            List<Enquiry> listEnquiies = null;
            DateTime dtStartDate = DateTime.ParseExact(fromdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dtEndDate = DateTime.ParseExact(todate, "dd/MM/yyyy", CultureInfo.InvariantCulture);           
            string keyname = fromdate + todate + (int)Session["UserId"];
            if (RedisCacheHelper.keyExistsInCache(keyname))
                listEnquiies = RedisCacheHelper.GetCacheData<Enquiry>(keyname);
            else
            {
                listEnquiies = manager.GetAllEnquires(dtStartDate, dtEndDate, (int)Session["UserId"]);
                RedisCacheHelper.addItemCache<Enquiry>(keyname,listEnquiies);
            }
            return Json(listEnquiies.OrderBy(o => o.ID), JsonRequestBehavior.AllowGet);
        }

        public FileResult Download()
        {
            var FileVirtualPath = "~/App_Data/EnquiryImport.xlsx";
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }

        [HttpPost]
        public JsonResult ImportExcel()
        {
            var list = new List<EnquiryError>();
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase postedFileBase = Request.Files[0];
                string fileName = postedFileBase.FileName;

                byte[] buffer = new byte[postedFileBase.ContentLength];

                postedFileBase.InputStream.Read(buffer, 0, postedFileBase.ContentLength);

                DataTable dt = ConvertExcelToDataTable(buffer, fileName);

                var importList = ConvertDataTableToGenericList(dt);
                string xmlString = ConvertToXmlString(importList);

                if (xmlString != string.Empty)
                {
                    var errorMessage = manager.ImportEnquiry(xmlString,(int)Session["UserId"]);
                    if (errorMessage != string.Empty)
                    {
                        UTF8Encoding encoding = new UTF8Encoding();
                        XmlSerializer xs = new XmlSerializer(typeof(List<EnquiryError>), new XmlRootAttribute("ArrayOfEnquiryError"));
                        MemoryStream memoryStream = new MemoryStream(encoding.GetBytes(errorMessage));
                        list = (List<EnquiryError>)xs.Deserialize(memoryStream);
                    }
                }
            }
            return Json(list.OrderBy(o => o.RowNumber), JsonRequestBehavior.AllowGet);
        }


        public DataTable ConvertExcelToDataTable(byte[] buffer, string fileName)
        {

            Stream fileStream = new MemoryStream(buffer);
            IExcelDataReader excelReader = (fileName.Substring(fileName.LastIndexOf('.') + 1) == "xls") ?
                                                ExcelReaderFactory.CreateBinaryReader(fileStream) :
                                                 ExcelReaderFactory.CreateOpenXmlReader(fileStream);
            //Using Excel Reader
            DataTable dt = excelReader.AsDataSet() != null ? excelReader.AsDataSet().Tables[0] : null;
            fileStream.Close();
            return dt;

        }

        public List<Enquiry> ConvertDataTableToGenericList(DataTable dt)
        {
            List<Enquiry> list = new List<Enquiry>();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bool flag = false;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (Convert.ToString(dt.Rows[i][j]) != string.Empty)
                        {
                            flag = true;
                        }
                    }
                    if (flag)
                    {
                        list.Add(ConvertEnquiryToTableRow(dt.Rows[i]));
                    }
                }
            }

            if (list != null && list.Count > 0)
            {
                list.RemoveAt(0);
            }

            return list;
        }

        public Enquiry ConvertEnquiryToTableRow(DataRow dr)
        {
            Enquiry enquiry = new Enquiry();
            enquiry.CustomerName = Convert.ToString(dr[0]);
            enquiry.DateOfBirth = Convert.ToString(dr[1]);
            enquiry.PhoneNo = Convert.ToString(dr[2]);
            enquiry.PolicyType = Convert.ToString(dr[3]);
            enquiry.SumAssured = Convert.ToString(dr[4]);
            enquiry.PolicyTerm = Convert.ToString(dr[5]);
            enquiry.SmokerStatus = Convert.ToString(dr[6]);

            return enquiry;
        }

        // By using this method we can convert datatable to xml
        public string ConvertDatatableToXML(DataTable dt)
        {
            MemoryStream str = new MemoryStream();
            dt.WriteXml(str, true);
            str.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(str);
            string xmlstr;
            xmlstr = sr.ReadToEnd();
            return (xmlstr);
        }

        public string ConvertToXmlString(IList data)
        {
            if (data.Count > 0)
            {
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(data[0].GetType());
                DataTable table = new DataTable(data[0].GetType().Name);
                for (int i = 0; i < props.Count; i++)
                {
                    PropertyDescriptor prop = props[i];
                    table.Columns.Add(prop.Name, prop.PropertyType);
                }
                object[] values = new object[props.Count];
                foreach (object item in data)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item);
                    }
                    table.Rows.Add(values);
                }
                StringBuilder strXml = new StringBuilder();
                table.WriteXml(XmlWriter.Create(strXml));
                return strXml.ToString();
            }
            return string.Empty;
        }

        public static T DeserializeObject<T>(string pXmlizedString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            XmlSerializer xs = new XmlSerializer(typeof(T));
            MemoryStream memoryStream = new MemoryStream(encoding.GetBytes(pXmlizedString));
            System.Xml.XmlTextWriter xmlTextWriter = new System.Xml.XmlTextWriter(memoryStream, Encoding.UTF8);
            return (T)xs.Deserialize(memoryStream);
        }
    }
}