using DocumentFormat.OpenXml.Bibliography;

namespace productcrudforangular.Model
{
    public class Shop
    {
        public int Id { get; set; }
        public string ShopeName { get; set; }
        public int StateId { get; set; }
        public int DistId { get; set; }
        public int TalukaId { get; set; }
        public int CityId { get; set; }
    }
    public class GetShopModel
    {
        public int Id { get; set; }
        public string ShopeName	 {get;set;}
        public int StateId		 {get;set;}
        public string StateName     {get; set;}
        public int DistId        {get; set;}
        public string DistrictName  {get; set;}
        public int TalukaId      {get; set;}
        public string TalukaName    {get; set;}
        public int CityId        {get; set;}
        public string CityName      {get; set;}
    }
}
