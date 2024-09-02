using Microsoft.AspNetCore.Mvc;
using QRCode.Models;
using QRCoder;

namespace QRCode.Controllers
{
    public class QRCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new QRCodeModel());
        }

        [HttpPost]
        public IActionResult Index(QRCodeModel model)
        {

            // QR Code payload seçimini idarə edir
            string? payload = null;
            switch (model.QRCodeType)
            {
                case 1: // SMS
                    payload = $"SMSTO:{model.SMSPhoneNumber}:{model.SMSBody}";
                    break;
                case 2: // Email
                    payload = $"mailto:{model.ReceiverEmailAddress}?subject={model.EmailSubject}&body={model.EmailMessage}";
                    break;
                case 3: // VCARD
                    payload = GenerateVCardPayload(model);
                    break;
            }

            if (payload != null)
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.H);
                BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
                string base64String = Convert.ToBase64String(qrCode.GetGraphic(20));
                model.QRImageURL = "data:image/png;base64," + base64String;
            }


            return View(model);
        }

        private string GenerateVCardPayload(QRCodeModel model)
        {
            return "BEGIN:VCARD\r\n" +
                   $"VERSION:3.0\r\n" +
                   $"FN:{model.FirstName} {model.LastName}\r\n" +
                   $"N:{model.LastName};{model.FirstName};;;\r\n" +
                   $"EMAIL;TYPE=INTERNET:{model.Email}\r\n" +
                   $"TEL;TYPE=WORK:{model.PhoneNumber}\r\n" +
                   $"ADR;TYPE=HOME;LABEL=\"{model.City}, {model.Country}\"\r\n" +
                   $"ORG:{model.Company}\r\n" +
                   $"TITLE:{model.Job}\r\n" +
                   $"ADR;TYPE=WORK;LABEL=\"{model.ZIP}\"\r\n" +
                   $"TEL;TYPE=FAX:{model.Fax}\r\n" +
                   "END:VCARD\r\n";
        }
    }
}
