using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Avaliacao.Models
{

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ProfessorContext : DbContext
    {
        public DbSet<TbProfessor> TbProfessors { get; set; }

        public ProfessorContext() : base("DefaultConnection")
        {

        }

        private readonly ProfessorContext _context;

        public ProfessorContext(ProfessorContext context)
        {
            _context = context;
        }


        public IList<TbProfessor> tb_professor { get; set; }
        
 
        public async Task OnGetAsync(string buscaPorNome)
        {
            var professors = from nome_professor in _context.tb_professor
                              select nome_professor;

            if (!String.IsNullOrEmpty(buscaPorNome))
            {
                professors = professors.Where(b => b.nome_professor.Contains(buscaPorNome));
            }

            tb_professor = await _context.TbProfessors.ToListAsync();
        
        }
    }
}