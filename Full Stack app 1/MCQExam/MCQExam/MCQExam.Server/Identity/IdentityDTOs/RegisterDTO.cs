namespace MCQExam.Server.Identity.IdentityDTOs
{
    public class RegisterDTO
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string confirmPass { get; set; }
        public int PassKey { get; set; }
        public string Role {  get; set; }
        public string? Course { get; set; }
        public string? Level { get; set; }
    }
}
