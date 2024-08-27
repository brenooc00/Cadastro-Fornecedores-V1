using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroFornecedores.Data;
using CadastroFornecedores.Models;

namespace CadastroFornecedores.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Fornecedores.FirstOrDefault(x=> x.id == id);
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Fornecedores.ToList(); //Atenção ao tolist
        }

        public ContatoModel Create(ContatoModel contato)
        {
            _bancoContext.Fornecedores.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public ContatoModel Update(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.id);
            if(contatoDB == null) throw new System.Exception("Houve um erro na atualização do fornecedor");

            contatoDB.nome = contato.nome;
            contatoDB.cnpj = contato.cnpj;
            contatoDB.segmento = contato.segmento;
            contatoDB.cep = contato.cep;
            contatoDB.endereco = contato.endereco;

            _bancoContext.Fornecedores.Update(contatoDB);
            _bancoContext.SaveChanges();
            return contatoDB;
        }
        public bool DeleteConfirm(int id)
        {
            ContatoModel contatoDB = ListarPorId(id);

            if(contatoDB == null) throw new System.Exception("Houve um erro ao deletar o fornecedor");

            _bancoContext.Fornecedores.Remove(contatoDB);
            _bancoContext.SaveChanges();

            return true;
        }

    }
}