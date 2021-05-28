using Prova.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Prova.WCF.Library
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        List<Cliente> GetClienti();

        [OperationContract]
        Cliente GetClienteById(int id);

        [OperationContract]
        bool AddNewCliente(Cliente newCliente);

        [OperationContract]
        bool EditCliente(Cliente updatedCliente);

        [OperationContract]
        bool DeleteClienteById(int id);
    }
    
    
}
