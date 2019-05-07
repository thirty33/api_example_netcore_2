using System.ComponentModel.DataAnnotations;

namespace Users_Api.Resources
{
    public class SaveCategoryResource
    {

        //public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
