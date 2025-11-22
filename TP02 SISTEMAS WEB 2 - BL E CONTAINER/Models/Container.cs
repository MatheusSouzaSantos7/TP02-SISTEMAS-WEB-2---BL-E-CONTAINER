// Matheus Angelo - CB3025489
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP02_SISTEMAS_WEB_2___BL_E_CONTAINER.Models
{
    public class Container
    {
        public int Id { get; set; }

        [Required]
        [StringLength(11)]
        public string Numero { get; set; } = string.Empty;

        [Required]
        public string Tipo { get; set; } = "Dry";

        [Range(20, 40)]
        public int Tamanho { get; set; } = 20;

        public int BLId { get; set; }
        public BL? BL { get; set; }
    }
}
