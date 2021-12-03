using Avaliacao.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Avaliacao.Data
{
    public class AvaliacaoContext : DbContext
    {
   
        public AvaliacaoContext() : base("DefaultConnection")
        {
        }


        private readonly AvaliacaoContext _context;

        public AvaliacaoContext(AvaliacaoContext context)
        {
            _context = context;
        }

        public System.Data.Entity.DbSet<Avaliacao.Models.TbDisciplina> TbDisciplinas { get; set; }
        public IList<TbDisciplina> tb_disciplina { get; set; }


        public async Task OnGetAsync(string buscaPorNomeDisciplina)
        {
            var disciplinas = from nome_disciplina in _context.tb_disciplina
                             select nome_disciplina;

            if (!String.IsNullOrEmpty(buscaPorNomeDisciplina))
            {
                disciplinas = disciplinas.Where(b => b.nome_disciplina.Contains(buscaPorNomeDisciplina));
            }

            tb_disciplina = await _context.TbDisciplinas.ToListAsync();

        }




    }
}
