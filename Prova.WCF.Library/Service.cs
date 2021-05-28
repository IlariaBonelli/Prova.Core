using Prova.Core.BusinessLayer;
using Prova.Core.EF.Repos;
using Prova.Core.Interfacce;
using Prova.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Prova.WCF.Library
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service : IService
    {
        IMainBusinessLayer bl; 

        public Service()
        {
            var clienteRepo = new EFClienteRepos();
            var ordineRepo = new EFOrdineRepos();
            bl = new MainBusinessLayer(clienteRepo, ordineRepo);
        }
        public bool AddNewCliente(Cliente newCliente)
        {
            try
            {
                return bl.CreateCliente(newCliente);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteClienteById(int id)
        {
            try
            {
                var cliente = GetClienteById(id);
                return bl.DeleteCliente(cliente);

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditCliente(Cliente updatedCliente)
        {
            try
            {
                return bl.EditCliente(updatedCliente);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Cliente GetClienteById(int id)
        {
            try
            {
                return bl.FetchClienteById(id);
            }
            catch(Exception)
            {
                return null;
            }
        }

        public List<Cliente> GetClienti()
        {
            try
            {
                return bl.FetchClienti().ToList();
            }
            catch (Exception)
            {
                return new List<Cliente>();
            }
        }
    }
}
