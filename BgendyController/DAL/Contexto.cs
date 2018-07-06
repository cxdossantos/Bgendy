using BgendyModel;
using BgendyModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BgendyController.DAL
{
    class Contexto : DbContext
    {
        public Contexto() : base("strConn")
        {
             //Padrao (se nao existir base de dados, cria)
           Database.SetInitializer(new CreateDatabaseIfNotExists<Contexto>());

            // Apaga e recria a base toda vez que o projeto eh executado
             //Database.SetInitializer(new DropCreateDatabaseAlways<Contexto>());

             //Apaga e recria a base de dados se houver alteracoes nas modelos
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Contexto>());
            
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
    }
}
