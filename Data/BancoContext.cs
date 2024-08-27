using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroFornecedores.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroFornecedores.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options){}
        public DbSet<ContatoModel> Fornecedores { get; set;}
        
    }
}