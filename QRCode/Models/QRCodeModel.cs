namespace QRCode.Models
{
    public class QRCodeModel
    {
        public int QRCodeType { get; set; } // QR kod növü: 1 - SMS, 2 - Email, 3 - VCARD
        public string QRImageURL { get; set; } = string.Empty; // QR kod şəkil URL-i

        // SMS üçün
        public string SMSPhoneNumber { get; set; } = string.Empty;
        public string SMSBody { get; set; } = string.Empty;

        // Email üçün
        public string ReceiverEmailAddress { get; set; } = string.Empty;
        public string EmailSubject { get; set; } = string.Empty;
        public string EmailMessage { get; set; } = string.Empty;

        // VCARD üçün
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Company { get; set; }
        public string? Job { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? ZIP { get; set; }
        public string? Fax { get; set; }
    }
}
