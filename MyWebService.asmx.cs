/*using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ALXO
{
  
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
   
    public class MyWebService : System.Web.Services.WebService
    {
        private readonly string xmlFilePath = @"file:///C:/inetpub/wwwroot/frontend/User1.xml";
        private readonly string downloadsFolderPath = @"C:\Users\nbharath\Downloads\";

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string ValidateUser(string username, string password, string roleID)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*"); // Allow cross-origin
            try
            {
                if (!File.Exists(xmlFilePath))
                {
                    return "{\"status\":\"error\", \"message\":\"User data file not found.\"}";
                }

                XmlDocument doc = new XmlDocument();
                doc.Load(xmlFilePath);

                if (doc.DocumentElement == null || doc.DocumentElement.Name != "Users")
                {
                    return "{\"status\":\"error\", \"message\":\"Invalid XML structure.\"}";
                }

                string xpathQuery = string.Format("/Users/User[Username='{0}' and Password='{1}' and RoleID='{2}']", username, password, roleID);
                XmlNode userNode = doc.SelectSingleNode(xpathQuery);

                if (userNode != null)
                {
                    return "{\"status\":\"success\", \"message\":\"User successfully login.\"}";
                }
                else
                {
                    return "{\"status\":\"error\", \"message\":\"Invalid username, password, or role.\"}";
                }
            }
            catch (Exception ex)
            {
                return "{\"status\":\"error\", \"message\":\"" + ex.Message + "\"}";
            }
        }

       

        [WebMethod]
        public List<string> GetSystemFolders()
        {
            return new List<string> { "Downloads", "Desktop", "Documents" };
        }

        [WebMethod]
        public List<FileInfo> StartScan()
        {
            try
            {
                
                var scannedFiles = new List<FileInfo>
                {
                    new FileInfo { FileName = "scanned_pdf(1)", DateModified = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), FileType = "DOCX", FileSize = 512 }
                };

               
                foreach (var file in scannedFiles)
                {
                    string filePath = Path.Combine(downloadsFolderPath, file.FileName + "." + file.FileType.ToLower());
                    if (!File.Exists(filePath))
                    {
                        File.Create(filePath).Dispose(); 
                    }
                }

                return scannedFiles;
            }
            catch (Exception ex)
            {
                throw new Exception("Error during scanning: " + ex.Message);
            }
        }

        [WebMethod]
        public List<FileInfo> GetFilesWithPathsInFolder(string folderPath)
        {
           
            var files = new Dictionary<string, List<FileInfo>>
            {
                { 
                    "Downloads", new List<FileInfo>
                    {
                        new FileInfo { FileName = "scan.pdf", DateModified = "2024-12-01", FileType = "PDF", FileSize = 2048 },
                        new FileInfo { FileName = "print.pdf", DateModified = "2024-12-02", FileType = "PDF", FileSize = 2048 },
                        new FileInfo { FileName = "copy.pdf", DateModified = "2024-12-05", FileType = "PDF", FileSize = 2048 },
                        new FileInfo { FileName = "fax.pdf", DateModified = "2024-11-25", FileType = "PDF", FileSize = 1024 }
                    }
                },
                { 
                    "Desktop", new List<FileInfo>
                    {
                        new FileInfo { FileName = "print.pdf", DateModified = "2024-12-05", FileType = "PDF", FileSize = 5120 },
                        new FileInfo { FileName = "IFax.pdf", DateModified = "2024-12-05", FileType = "PDF", FileSize = 5120 },
                        new FileInfo { FileName = "Faxsend.pdf", DateModified = "2024-11-05", FileType = "PDF", FileSize = 5120 },
                        new FileInfo { FileName = "copy.pdf", DateModified = "2024-10-20", FileType = "PDF", FileSize = 128 },
                        new FileInfo { FileName = "copy.pdf", DateModified = "2024-10-20", FileType = "PDF", FileSize = 128 }
                    }
                },
                { 
                    "Documents", new List<FileInfo>
                    {
                        new FileInfo { FileName = "copy.docx", DateModified = "2024-08-03", FileType = "DOCX", FileSize = 4096 },
                        new FileInfo { FileName = "Fax.pdf", DateModified = "2024-10-05", FileType = "PDF", FileSize = 5120 },
                        new FileInfo { FileName = "Exchange.pdf", DateModified = "2024-01-05", FileType = "PDF", FileSize = 5120 },
                        new FileInfo { FileName = "scan.pdf", DateModified = "2024-11-15", FileType = "PDF", FileSize = 3072 }
                    }
                }
            };

           
            if (files.ContainsKey(folderPath))
            {
                
                var scannedFiles = GetScannedFiles();
                files[folderPath].AddRange(scannedFiles);
            }

            return files.ContainsKey(folderPath) ? files[folderPath] : new List<FileInfo>();
        }

        
        private List<FileInfo> GetScannedFiles()
        {
            
            return new List<FileInfo>
            {
                new FileInfo { FileName = "scanned_pdf(1)", DateModified = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), FileType = "DOCX", FileSize = 512 }

            };
        }

       
        public class FileInfo
        {
            public string FileName { get; set; }
            public string DateModified { get; set; }
            public string FileType { get; set; }
            public int FileSize { get; set; }
        }
    }
}*/