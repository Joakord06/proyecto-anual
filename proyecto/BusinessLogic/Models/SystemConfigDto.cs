namespace LayeredApp.Business.DTOs
{
    public class SystemConfigDto
    {
        public int MinPasswordLength { get; set; }
        public int QuestionsToAnswer { get; set; }
        public bool RequireUpperLower { get; set; }
        public bool RequireDigits { get; set; }
        public bool RequireSpecial { get; set; }
        public bool Require2FA { get; set; }
        public bool DisallowPreviousPasswords { get; set; }
        public bool DisallowPersonalData { get; set; }
    }
}

