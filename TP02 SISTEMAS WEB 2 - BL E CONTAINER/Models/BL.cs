// Matheus Angelo - CB3025489
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP02_SISTEMAS_WEB_2___BL_E_CONTAINER.Models
{
    public class BL
    {
        public int Id { get; set; }

        [Required]
        public string Numero { get; set; } = string.Empty;

        public string? Consignee { get; set; }

        public string? Navio { get; set; }

        public List<Container> Containers { get; set; } = new();
    }
}
