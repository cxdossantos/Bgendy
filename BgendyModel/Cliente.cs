using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BgendyModels
{
    public class Cliente
    {

 //       DtNasc.AddMinutes(60)
        public int Id { get; set; }
        public String Nome { get; set; }
        public int Cpf { get; set; }
        public DateTime DtNasc { get; set; }

        
        public int Fone { get; set; }

    }
}
