namespace productcrudforangular.Model
{
    public class EmployeeModel
    {
     
            public int Id { get; set; }
            public string EmpName { get; set; } 
            public string EmailId { get; set; } 
            public string EmpPhoneNo { get; set; }
            public int RoleId { get; set; }
            public int CreatedBy { get; set; }
            public DateTime CreatedDate { get; set; }
            public int? ModifiedBy { get; set; }
            public DateTime? ModifiedDate { get; set; }
            public bool IsDeleted { get; set; }


    }
    public class EmployeeGetModel
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string EmailId { get; set; }
        public string EmpPhoneNo { get; set; }
        public int RoleId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string EmpRole { get; set; }
        public string ShopeName { get; set; }
        public int ShopId { get; set; }
        public int AssignId { get; set; }
    }

}
