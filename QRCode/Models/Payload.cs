namespace QRCode.Models;

public abstract class Payload
{
    public abstract string GetContent();
}

public class SMS : Payload
{
    public string PhoneNumber { get; }
    public string Body { get; }

    public SMS(string phoneNumber, string body)
    {
        PhoneNumber = phoneNumber;
        Body = body;
    }

    public override string GetContent()
    {
        return $"SMSTO:{PhoneNumber}:{Body}";
    }
}

public class Mail : Payload
{
    public string EmailAddress { get; }
    public string Subject { get; }
    public string Body { get; }

    public Mail(string emailAddress, string subject, string body)
    {
        EmailAddress = emailAddress;
        Subject = subject;
        Body = body;
    }

    public override string GetContent()
    {
        return $"mailto:{EmailAddress}?subject={Subject}&body={Body}";
    }
}

public class VCard : Payload
{
    private readonly string _vcfContent;

    public VCard(string vcfContent)
    {
        _vcfContent = vcfContent;
    }

    public override string GetContent()
    {
        return _vcfContent;
    }
}
