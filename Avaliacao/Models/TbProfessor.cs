using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Avaliacao.Models
{

    [Table("tb_professor")]
    public class TbProfessor
    {
        [Column("id_professor")]
        [Display(Name = "ID Professor")]
        [Key]
        public int id_professor { get; set; }

        [Display(Name = "Nome Professor")]
        public string nome_professor { get; set; }

        [Display(Name = "Email Professor")]
        public string email_professor { get; set; }

        [Display(Name = "Senha Professor")]
        public string senha_professor { get; set; }

    }
}