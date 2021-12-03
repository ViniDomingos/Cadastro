using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Avaliacao.Models
{

    [Table("tb_disciplina")]
    public class TbDisciplina
    {
        [Column("id_disciplina")]
        [Display(Name = "ID Disciplina")]
        [Key]
        public int id_disciplina { get; set; }

        [Display(Name = "Nome Disciplina")]
        public string nome_disciplina { get; set; }

        [Display(Name = "Carga Horaria")]
        public int cargahoraria_disciplina { get; set; }

    }
}