namespace LayeredApp.Business.DTOs
{
    public class SecurityQuestionDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Question { get; set; } = null!;
    }
}
