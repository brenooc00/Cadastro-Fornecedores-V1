using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CadastroFornecedores.Models;
using CadastroFornecedores.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CadastroFornecedores.Controllers
{
    //[Route("[controller]")]
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        private readonly ApiModel _apiModel;
        public ContatoController(IContatoRepositorio contatoRepositorio, ApiModel apiModel)//mudança
        {
            _contatoRepositorio = contatoRepositorio;
            _apiModel = apiModel;//mudança
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContatoModel contato)
        {
            _contatoRepositorio.Create(contato);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Update(ContatoModel contato)
        {
            _contatoRepositorio.Update(contato);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult DeleteConfirm(int id)
        {
            _contatoRepositorio.DeleteConfirm(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> BuscarEndereco(string cep)
        {
            var endereco = await _apiModel.BuscarEnderecoPorCep(cep);
            if (endereco != null)
            {
                return Json(endereco);
            }
            return NotFound();
        }
    }
}