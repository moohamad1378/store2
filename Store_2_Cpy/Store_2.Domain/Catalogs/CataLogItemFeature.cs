using Store_2.Domain.Attributes;

namespace Store_2.Domain.Catalogs
{
    [Auditable]
    public class CataLogItemFeature
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Valude { get; set; }
        public string Group { get; set; }
        public CataLogItem CataLogItem { get; set; }
        public int CataLogItemId { get; set; }
    }
}
