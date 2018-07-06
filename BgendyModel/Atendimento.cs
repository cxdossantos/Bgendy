using BgendyModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BgendyModel
{
    public class Atendimento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual Cliente _Cliente { get; set; }
        public virtual Servico _Servico { get; set; }
        public DateTime DtAtendimentoInicio { get; set; }
        public DateTime DtAtendimentoFim { get; set; }


    }
}
