using Prova.Core.Interfacce;
using Prova.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prova.Core.BusinessLayer
{
    public class MainBusinessLayer: IMainBusinessLayer
    {
        private readonly IClienteRepos clienteRepo;
        private readonly IOrdineRepos ordineRepo;

        public MainBusinessLayer(IClienteRepos clienteRepo, IOrdineRepos ordineRepo)
        {
           this.clienteRepo = clienteRepo;
           this.ordineRepo = ordineRepo;
        }

        #region Cliente

        public bool CreateCliente(Cliente newCliente)
        {
            return clienteRepo.Add(newCliente);
        }

        public bool EditCliente(Cliente editedCliente)
        {
            return clienteRepo.Update(editedCliente);
        }

        public bool DeleteCliente(Cliente ClienteToBeDeleted)
        {
            return clienteRepo.Delete(ClienteToBeDeleted);
        }

        public IEnumerable<Cliente> FetchClienti()
        {
            return clienteRepo.Fetch();
        }
        public Cliente FetchClienteById(int id)
        {
            return clienteRepo.Fetch().FirstOrDefault(c => c.Id == id);
        }

        #endregion

        #region Ordine

        public bool CreateOrdine(Ordine newOrdine)
        {
            return ordineRepo.Add(newOrdine);
        }

        public bool EditOrdine(Ordine editedOrdine)
        {
            return ordineRepo.Update(editedOrdine);
        }

        public bool DeleteOrdine(Ordine OrdineToBeDeleted)
        {
            return ordineRepo.Delete(OrdineToBeDeleted);
        }

        public IEnumerable<Ordine> FetchOrdini()
        {
            return ordineRepo.Fetch();
        }
        public Ordine FetchOrdineById(int id)
        {
            return ordineRepo.Fetch().FirstOrDefault(o => o.Id == id);
        }








        #endregion
    }
}
