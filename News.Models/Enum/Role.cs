using System.ComponentModel.DataAnnotations;
namespace News.Models.Enum
{
    public enum Role
    {
        [Display(Name= "Journalist")]
        Journalist,
        [Display(Name = "Admin")]
        Admin
    }
}
