namespace Store_2.Domain.Catalogs
{
    public class CatalogItemImage
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public CataLogItem CataLogItem { get; set; }
        public int CataLogItemId { get; set; }
    }
}
