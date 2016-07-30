using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoBeBlue.Dominio
{

    public enum TodoPrioridade
    {
        BAIXA = 1,
        MEDIA = 2,
        ALTA = 3
    };

    public class Todo
    {
        public int TodoId { get; set; }
        public string Descricao { get; set; }
        public bool Feito { get; set; }
        public TodoPrioridade Prioridade { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }

}
