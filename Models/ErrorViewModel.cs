using System;

namespace dockernet.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class PrivacyViewModel
    {
        public string Heading {get; set;}
    }
}
