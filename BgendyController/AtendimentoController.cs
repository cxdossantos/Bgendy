using BgendyController.Base;
using BgendyController.DAL;
using BgendyModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BgendyController
{
    public class AtendimentoController : IBaseController<Atendimento>
    {
        private Contexto contexto = new Contexto();
        public AtendimentoController()
        {
            contexto.Configuration.LazyLoadingEnabled = true;
        }

        public void Adicionar(Atendimento entity)
        {
            //entity.Ativo = true;
            contexto.Servicos.Attach(entity._Servico);
            contexto.Clientes.Attach(entity._Cliente);
            contexto.Atendimentos.Add(entity);
            contexto.SaveChanges();
        }

        public Atendimento BuscarPorID(int id)
        {
            throw new NotImplementedException();
        }

        public void Editar(Atendimento entity)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Atendimento> ListarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public IList<Atendimento> ListarTodos()
        {
            return contexto.Atendimentos.ToList();
        }
    }
}