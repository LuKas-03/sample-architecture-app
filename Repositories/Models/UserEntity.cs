using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    internal class UserEntity
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
    }
}
