using BgendyController.Base;
using BgendyController.DAL;
using BgendyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BgendyController
{
    public class ClienteController : IBaseController<Cliente>
    {
        private Contexto contexto = new Contexto();

        public void Adicionar(Cliente entity)
        {
            //entity.Ativo = true;
            contexto.Clientes.Add(entity);
            contexto.SaveChanges();
        }


    }
}
