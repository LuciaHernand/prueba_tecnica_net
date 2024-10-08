using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5
{
    [Table("MBAOption")]
    public class MBAOption
    {
        [Key]
        public int OptionId { get; set; }
        [Required]
        private string _optionName;

        public string OptionName
        {
            get => _optionName;
            set => _optionName = value ?? " "; // Si el valor es null, asigna un espacio
        }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
