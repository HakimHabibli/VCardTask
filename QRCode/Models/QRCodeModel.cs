namespace QRCode.Models;

public class QRCodeModel
{
    public int QRCodeType { get; set; }
    public string QRImageURL { get; set; } = string.Empty;

    // email 
    public string ReceiverEmailAddress { get; set; } = string.Empty;
    public string EmailSubject { get; set; } = string.Empty;
    public string EmailMessage { get; set; } = string.Empty;

    // sms 
    public string SMSPhoneNumber { get; set; } = string.Empty;
    public string SMSBody { get; set; } = string.Empty;

}
