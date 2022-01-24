using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaCandidato.Data.Entidade
{
    [Table("ClienteObservacao")]
    public class ClienteObservacao
    {
        [Key]
        [Column("codigo")]
        public int Codigo { get; set; }

        [Column("texto")]
        public string Texto { get; set; }

        public virtual int ClienteId { get; set; }
        public virtual Cliente ObjCliente { get; set; }
    }
}
