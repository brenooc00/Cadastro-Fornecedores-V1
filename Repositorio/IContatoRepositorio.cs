using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroFornecedores.Models;

namespace CadastroFornecedores.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListarPorId(int id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Create(ContatoModel contato);
        ContatoModel Update(ContatoModel model);
        bool DeleteConfirm(int id);
    }
}