using Prova.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.Core.Interfacce
{
    public interface IClienteRepos:IRepository<Cliente>
    {
        Cliente GetById(int id);
    }
}
