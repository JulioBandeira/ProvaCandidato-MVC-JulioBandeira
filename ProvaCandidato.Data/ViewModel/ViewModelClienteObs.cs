using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaCandidato.Data.ViewModel
{
    public class ViewModelClienteObs
    {
        public int Codigo_Clilente { get; set; }

        [Display(Name = "Observacao")]
        [Required]
        public string Observacao { get; set; }
    }
}
