using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("Pictures")]
    public class Pictures
    {
        [Key]
        public string HashId { get; set; }
        [Required]
        public byte[] Picture { get; set; }
    }
}