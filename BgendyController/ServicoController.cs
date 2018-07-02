using BgendyController.Base;
using BgendyController.DAL;
using BgendyModel;
using BgendyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BgendyController
{
    public class ServicoController : IBaseController<Servico>
    {
        private Contexto contexto = new Contexto();

        public void Adicionar(Servico entity)
        {
            //entity.Ativo = true;
            contexto.Servicos.Add(entity);
            contexto.SaveChanges();
        }

        public Servico BuscarPorID(int id)
        {
            return contexto.Servicos.Find(id);
        }

        public void Editar(Servico entity)
        {
            contexto.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Excluir(int id)
        {
            Servico servico = BuscarPorID(id);

            if (servico != null)
            {
                contexto.Servicos.Remove(servico);
                contexto.SaveChanges();
            }
            else
            {
                throw new NullReferenceException("Não encontrado.");
            }
        }

        public IList<Servico> ListarPorNome(string nome)
        {
            // LAMBDA
            return contexto.Servicos.Where(servico => servico.Descricao.Contains(nome)).ToList();
            //return contexto.Clientes.Where(cliente => cliente.Nome == nome).ToList();
        }

        public IList<Servico> ListarTodos()
        {
            return contexto.Servicos.ToList();
        }
    }
}
