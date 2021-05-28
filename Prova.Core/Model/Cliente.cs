using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Prova.Core.Model
{
    [DataContract]
    public class Cliente
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string CodiceCliente { get; set; }

        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public string Cognome { get; set; }

        [DataMember]
        public List<Ordine> Ordini { get; set; }


    }
}
