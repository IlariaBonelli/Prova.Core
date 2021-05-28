using Prova.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.Core.Interfacce
{
    public interface IMainBusinessLayer
    {
        #region Cliente

        IEnumerable<Cliente> FetchClienti();
        bool CreateCliente(Cliente newCliente);
        bool EditCliente(Cliente editedCliente);
        bool DeleteCliente(Cliente ClienteToBeDeleted);
        Cliente FetchClienteById(int id);

        #endregion

        #region Ordine

        IEnumerable<Ordine> FetchOrdini();
        bool CreateOrdine(Ordine newOrdine);
        bool EditOrdine(Ordine editedOrdine);
        bool DeleteOrdine(Ordine OrdineToBeDeleted);
        Ordine FetchOrdineById(int id);


        #endregion




    }
}
