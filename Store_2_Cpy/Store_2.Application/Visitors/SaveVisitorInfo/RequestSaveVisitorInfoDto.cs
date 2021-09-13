using System;

namespace Store_2.Application.Visitors.SaveVisitorInfo
{
    public class RequestSaveVisitorInfoDto
    {
        public string IP { get; set; }
        public string CurrentLink { get; set; }
        public string ReferrerLink { get; set; }
        public string Method { get; set; }
        public string Protocol { get; set; }
        public string PyhysicalPatch { get; set; }
        public VisitorVersionDto Browser { get; set; }
        public VisitorVersionDto Operatonsystem { get; set; }
        public DeviceDto Device { get; set; }
        public string VisitorId { get; set; }
        public DateTime Time { get; set; }
    }
}
