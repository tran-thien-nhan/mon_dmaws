namespace day8_demoQR.Models
{
    public class QRCodeModel
    {
        public int QRCodeType { get; set; }
        public string QRImageUrl { get; set; } = string.Empty;

        //for email
        public string ReceiverEmailAddress { get; set; } = string.Empty;
        public string EmailSubject { get; set; } = string.Empty;
        public string EmailMessage { get; set; } = string.Empty;

        //for sms
        public string SMSPhoneNumber { get; set; } = string.Empty;
        public string SMSBody { get; set; } = string.Empty;

        //facebook (tiktok,telegram,...)
        public string FacebookAddress { get; set; } = string.Empty;
        
        //wifi
        public string WifiName { get; set; } = string.Empty;
        public string WifiPassword { get; set; } = string.Empty;
    }
}
