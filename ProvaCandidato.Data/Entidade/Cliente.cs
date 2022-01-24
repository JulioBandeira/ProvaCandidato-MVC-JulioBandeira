using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProvaCandidato.Data.Entidade
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [Column("codigo")]
        public int Codigo { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "* O nome deve estar entre de 3 a 50 carecterp´d.")]
        [Required]
        [Column("nome")]
        public string Nome { get; set; }

        [Column("data_nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        //[Remote("IsAlreadySigned", "Register", HttpMethod = "POST", ErrorMessage = "EmailId already exists in database.")]
        [Display(Name = "Data Cidade")]
        [Required]
        public DateTime? DataNascimento { get; set; }

        [Column("codigo_cidade")]
        [Display(Name = "Cidade")]
        public int CidadeId { get; set; }

        public bool Ativo { get; set; }

        [ForeignKey("CidadeId")]
        public virtual Cidade Cidade { get; set; }

        public virtual ICollection<ClienteObservacao> ListaObservacao{ get; set; } 
    }
}