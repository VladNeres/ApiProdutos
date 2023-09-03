using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionSql.Dtos
{
    public class ReadCategoriaDto
    {
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }

        public DateTime DataAlteracao { get; set; }
    }
}
