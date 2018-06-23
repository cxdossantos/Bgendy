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

        public Cliente BuscarPorID(int id)
        {
            return contexto.Clientes.Find(id);
        }

        public void Excluir (int id)
        {
            Cliente cliente = BuscarPorID(id);

            if(cliente != null)
            {
                contexto.Clientes.Remove(cliente);
                contexto.SaveChanges();
            }
            else
            {
                throw new NullReferenceException("Não encontrado.");
            }
        }

        public IList<Cliente> ListarTodos()
        {
            return contexto.Clientes.ToList();
        }

    }
}
