namespace BlogApp.Model
{
    public class UserLoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class UserRegisterViewModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
