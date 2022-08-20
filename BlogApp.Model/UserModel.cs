namespace BlogApp.Model
{
    public class UserModel 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Id { get; set; }
        public UserRole UserRole { get; set; }
    }
}
