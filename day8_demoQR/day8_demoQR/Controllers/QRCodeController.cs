using day8_demoQR.Models;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Security.Cryptography;
using static QRCoder.PayloadGenerator;

namespace day8_demoQR.Controllers
{
    public class QRCodeController : Controller
    {
        public IActionResult Index()
        {
            QRCodeModel model = new QRCodeModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(QRCodeModel model)
        {
            Payload? payload = null;
            switch (model.QRCodeType)
            {
                case 1://sms
                    payload = new SMS(model.SMSPhoneNumber, model.SMSBody);
                    break;
                case 2://email
                    payload = new Mail(model.ReceiverEmailAddress, model.EmailSubject, model.EmailMessage);
                    break;
                case 3://fb url
                    payload = new Url(model.FacebookAddress);
                    break;
                case 4://wifi
                    payload = new WiFi(model.WifiName, model.WifiPassword, WiFi.Authentication.WPA);
                    break;
            }

            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(payload);
            BitmapByteQRCode qRCode = new BitmapByteQRCode(qRCodeData);
            string base64String = Convert.ToBase64String(qRCode.GetGraphic(20));
            model.QRImageUrl = "data:image/png;base64," + base64String;
            return View(model);
        }
    }
}
