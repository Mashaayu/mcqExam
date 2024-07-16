using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
