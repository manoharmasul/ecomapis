﻿namespace productcrudforangular.Model
{
    public class AssignShopEmpModel
    {
        public int Id { get; set; }
        public int ShopId { get; set; }
        public int EmpId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
