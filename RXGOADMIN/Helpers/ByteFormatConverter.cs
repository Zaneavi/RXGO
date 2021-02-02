using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace RXGOADMIN.Helpers
{
    public class ByteFormatConverter
    {
        public string convertFile(string byteFile,string fileSavePath)
        {
            try
            {
                string fileExtension = Path.GetExtension(byteFile.Split('#')[1]);
                string fileFormat = byteFile.Split('#')[2];
                byte[] bytes = Convert.FromBase64String(byteFile.Split('#')[0].Replace("data:" + fileFormat + ";base64,", ""));

                String dirPath = System.Web.HttpContext.Current.Server.MapPath(fileSavePath);// ItemUploadFolderPath;//dirPath = @"C:\myfolder\";   // dirPathdd1; //Server.MapPath(ItemUploadFolderPath); //
                String imgName = "";
                if (fileExtension == ".xlsx" || fileExtension == ".xls")
                {
                    imgName = DateTime.Now.ToString("yyyymmddmmsstt") + "my_mage_name.xlsx";
                }
                else if (fileExtension == ".doc" || fileExtension == ".docx")
                {
                    imgName = DateTime.Now.ToString("yyyymmddmmsstt") + "my_mage_name.docx";
                }
                else if (fileExtension == ".txt")
                {
                    imgName = DateTime.Now.ToString("yyyymmddmmsstt") + "my_mage_name.txt";
                }
                else if (fileExtension == ".pdf")
                {
                    imgName = DateTime.Now.ToString("yyyymmddmmsstt") + "my_mage_name.pdf";
                }
                else if (fileExtension == ".ppt" || fileExtension == ".pptx" || fileExtension == ".pptm")
                {
                    imgName = DateTime.Now.ToString("yyyymmddmmsstt") + "my_mage_name.pptx";
                }
                else if (fileExtension == ".png" || fileExtension == ".jpg" || fileExtension == ".jpeg")
                {
                    imgName = DateTime.Now.ToString("yyyymmddmmsstt") + "my_mage_name.bmp";
                }
                else if (fileExtension == ".3gp" || fileExtension == ".flv" || fileExtension == ".mp4" || fileExtension == ".mpeg" || fileExtension == ".avi" || fileExtension == ".wmv")
                {
                    imgName = DateTime.Now.ToString("yyyymmddmmsstt") + "my_mage_name.mp4";
                }
                //f.DocFormat = ext;
                //dirPath = ItemUploadFolderPath;
                // byte[] imgByteArray = Convert.FromBase64String("your_base64_string");
                System.IO.File.WriteAllBytes(dirPath + imgName, bytes);

                string finalFile = fileSavePath + imgName;
                return finalFile;
            }
            catch (Exception ex)
            {

                return "";
            }
        }
    }
}