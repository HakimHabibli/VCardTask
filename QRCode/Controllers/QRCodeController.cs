using Microsoft.AspNetCore.Mvc;
using QRCoder;
using static QRCoder.PayloadGenerator;

namespace QRCode.Controllers
{
    public class QRCodeController : Controller
    {
        public IActionResult Index()
        {
            QRCode.Models.QRCodeModel model = new();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(QRCode.Models.QRCodeModel model)
        {
            Payload? payload = null;

            switch (model.QRCodeType)
            {
                case 1: // compose sms
                    payload = new SMS(model.SMSPhoneNumber, model.SMSBody);
                    break;
                case 2: //compose email
                    payload = new Mail(model.ReceiverEmailAddress, model.EmailSubject, model.EmailMessage);
                    break;
            }

            QRCodeGenerator qrGenerator = new();//QRCodeGenerator klassina aid bir obyekt yaradiriq

            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload);//həmin yaratdığımız obyekti məlumatlarla birlikdə QRCodeGenerator klassinin methodundan istifade edib melumatlarila birlikdə yaradiriq 



            BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
            string base64String = Convert.ToBase64String(qrCode.GetGraphic(20));
            model.QRImageURL = "data:image/png;base64," + base64String;

            return View(model);

        }
    }


}
