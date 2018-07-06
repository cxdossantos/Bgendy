﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BgendyModels
{
    public class Cliente
    {

        //       DtNasc.AddMinutes(60)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Nome { get; set; }
        public long Cpf { get; set; }
        public DateTime DtNasc { get; set; }

        
        public long Fone { get; set; }

    }
}
