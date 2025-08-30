namespace productcrudforangular.Model
{
    public class User
    {
        public int Id { get; set; }
        //public int EmpId { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
    }
        public class UserModel
        {
            public int Id { get; set; }
            public int EmpId { get; set; }
            public string UserName { get; set; } 
            public string EmailId { get; set; }
            public string PhoneNo { get; set; } 
            public string Password { get; set; } 
            public int CreatedBy { get; set; }
            public DateTime CreatedDate { get; set; }
            public int? ModifiedBy { get; set; }
            public DateTime? ModifiedDate { get; set; }
            public bool IsDeleted { get; set; }
        }
    public class Optvalidationmsg 
    {
        public string validationmsg { get; set; }
    }

    public class sendotp
    {
        public string PhoneNo { get; set; }
        public int UserId { get; set; }
        public string Otp { get; set; }
    }
    public class LogInModel 
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class LoginData
    {
        public int  Id { get; set; }
        public string  UserName { get; set; }
        public int  RoleId { get; set; }
    }
    public class SetPassword
    {
        public string Password { get; set; }
        public int UserId { get; set; }
    }



}
