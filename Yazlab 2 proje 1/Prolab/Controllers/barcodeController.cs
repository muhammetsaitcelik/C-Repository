
using Prolab.Models;
using System;
using System.Drawing;
using System.Web;
using System.Web.Mvc;
using OnBarcode.Barcode.BarcodeScanner;
using System.Configuration;
using System.Linq.Dynamic;
using System.Linq;

namespace Prolab.Controllers
{

    public class barcodeController : Controller
    {
        LoginDataEntities1 db = new LoginDataEntities1();
        public ActionResult BarCodeReader()
       {

            return View(db.Book.ToList());
        }

              [HttpPost]
        public ActionResult BarCodeReader(HttpPostedFileBase barCodeUpload)
        {
            string localSavePath = "~/UploadFiles/";
            string str = string.Empty;
            string strImage = string.Empty;
            string strBarcode = string.Empty;
          
            if (barCodeUpload != null)
            {
                String fileName = barCodeUpload.FileName;
                localSavePath += fileName;
                barCodeUpload.SaveAs(Server.MapPath(localSavePath));
                Bitmap bitmap = null;
                try
                {
                    bitmap = new Bitmap(barCodeUpload.InputStream);
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
                if (bitmap == null)
                {
                    str = "file is not an image";

                }
                else
                {
                    strImage = "https://localhost:"+Request.Url.Port+"/UploadFiles/"+fileName;
                    strBarcode = ReadBarcodeFromFile(Server.MapPath(localSavePath));
                }

            }
            else
            {
                str = "file is not an image111";
            }
            ViewBag.ErrorMassage = str;
            ViewBag.Barcode = strBarcode;
            ViewBag.BarImage = strImage;
            return View(db.Book.Where(x=>x.isbn.Contains(strBarcode)|| strBarcode==null).ToList());
        }
        private string ReadBarcodeFromFile(string v)
        {
            String[] barcodes = BarcodeScanner.Scan(v,BarcodeType.ISSN);
            return barcodes[0];
            throw new NotImplementedException();
        }
    }
}



