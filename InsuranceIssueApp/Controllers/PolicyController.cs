using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InsuranceIssueApp.BLL;
using InsuranceIssueApp.Model;
using System.Globalization;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Configuration;

namespace InsuranceIssueApp.Controllers
{
    [SessionExpire]
    public class PolicyController : Controller
    {
        private readonly IPolicyManager manager = null;

        public PolicyController()
        {
            manager = new PolicyManager();
        }
        // GET: Policy
        public ActionResult Index(long tempPolicyNo = 0)
        {
            if (tempPolicyNo != 0)
            {
               // Session["TempPolicyNo"] = tempPolicyNo;
                ViewBag.TempPolicyNo = tempPolicyNo;
            }
            else
            {
               // Session["TempPolicyNo"] = 0;
                ViewBag.TempPolicyNo = 0;
            }
            return View();
        }

        public ActionResult loadTabPolicyDetail(long tempPolicyNo)
        {
            PolicyDetailViewModel detail = manager.GetPolicyAllDetail(tempPolicyNo);
            detail.Documents = manager.GetSupportingDocument(tempPolicyNo);
            return Json(detail, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UnwriterReview()
        {
            // List<InsurrerDetail> detail = manager.ViewUnwriterReviewList((int)Session["UserId"], 2);            
            return View();
        }

        public ActionResult GetAllPoliciesForReview(string fromdate, string todate)
        {
            DateTime dtStartDate = DateTime.ParseExact(fromdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dtEndDate = DateTime.ParseExact(todate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            List<PolicyDetailViewModel> listEnquiies = manager.ViewUnwriterReviewList(dtStartDate, dtEndDate, 2);
            return Json(listEnquiies.OrderBy(o => o.TempPolicyNo), JsonRequestBehavior.AllowGet);
        }

        public ActionResult MyQueuePolicies()
        {
            return View();
        }

        public ActionResult GenerateAgentCommission()
        {
            return View();
        }

        public ActionResult GetAllPoliciesForGenrate(string fromdate, string todate)
        {
            DateTime dtStartDate = DateTime.ParseExact(fromdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dtEndDate = DateTime.ParseExact(todate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            List<PolicyDetailViewModel> listEnquiies = manager.ViewUnwriterReviewList(dtStartDate, dtEndDate, 4);
            return Json(listEnquiies.OrderBy(o => o.TempPolicyNo), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GenerateAgentCommissionUpdate(string fromdate, string todate, int agentid, string reportflag)
        {
            DateTime dtStartDate = DateTime.ParseExact(fromdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dtEndDate = DateTime.ParseExact(todate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            List<AgentCommissionResult> listEnquiies = manager.GenerateCommission(dtStartDate, dtEndDate, agentid, reportflag);
            return Json(listEnquiies.OrderBy(o => o.PolicyNo), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UploadSupportingDocuments()
        {
            long id = Convert.ToInt64(Request.Form["ID"]);
            if (Request.Files.Count > 0)
            {                
                CloudStorageAccount cloudStorageAccount = GetConnectionString();
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(ConfigurationManager.AppSettings["ContainerName"]);

                for (int fileNum = 0; fileNum < Request.Files.Count; fileNum++)
                {
                    string fileName = Path.GetFileName(Request.Files[fileNum].FileName);
                    if (Request.Files[fileNum] != null &&
                    Request.Files[fileNum].ContentLength > 0)
                    {
                        CloudBlockBlob azureBlockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);
                        azureBlockBlob.UploadFromStream(Request.Files[fileNum].InputStream);
                        SupportingDocument detail = new SupportingDocument();
                        detail.TempPolicyNo = id;
                        detail.FileName = fileName;
                        detail.CreatedBy = (int)Session["UserId"];
                        if (fileNum == 0)
                            detail.DisplayFileName = "Aadhar Document";
                        else if (fileNum == 1)
                            detail.DisplayFileName = "Pan Document";
                        else if (fileNum == 2)
                            detail.DisplayFileName = "Medical Checkup Document";
                        manager.InsertSupportingDocument(detail);
                    }                    
                }
            }
            List<SupportingDocument> listDocument = manager.GetSupportingDocument(id);
            return Json(listDocument, JsonRequestBehavior.AllowGet);

        }

        public static CloudStorageAccount GetConnectionString()
        {
            string accountname = ConfigurationManager.AppSettings["accountName"];
            string key = ConfigurationManager.AppSettings["key"];
            string connectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", accountname, key);
            return CloudStorageAccount.Parse(connectionString);
        }

        public FileResult DownloadSupportingDocument(string fileName)
        {
            CloudStorageAccount cloudStorageAccount = GetConnectionString();
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(ConfigurationManager.AppSettings["ContainerName"]);
            CloudBlockBlob azureBlockBlob = cloudBlobContainer.GetBlockBlobReference(fileName); 
            Stream blobStream = azureBlockBlob.OpenRead();
            return File(blobStream, azureBlockBlob.Properties.ContentType, fileName);
        }

        public ActionResult GetSupportingDocument(string tempPolicyNo)
        {
            List<SupportingDocument> listDocument = manager.GetSupportingDocument(Convert.ToInt64(tempPolicyNo));
            return Json(listDocument, JsonRequestBehavior.AllowGet);
        }
    }
}