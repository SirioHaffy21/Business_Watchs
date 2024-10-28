using System.ComponentModel.DataAnnotations;

namespace Business_Watch.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}