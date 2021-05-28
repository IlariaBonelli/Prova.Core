using Prova.Core.Interfacce;
using Prova.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Prova.Core.EF.Repos
{
    public class EFClienteRepos : IClienteRepos
    {
        private readonly MBLContext ctx;

        public EFClienteRepos(): this(new MBLContext()) { }

        public EFClienteRepos(MBLContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Cliente newCliente)
        {
            try
            {
                ctx.Clienti.Add(newCliente);
                ctx.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Cliente item)
        {
            try 
            {
                var Cliente = ctx.Clienti.Find(item.Id);
                if (Cliente != null)
                    ctx.Clienti.Remove(Cliente);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Cliente> Fetch()
        {
            try
            {
                return ctx.Clienti.ToList();
            }
            catch (Exception)
            {
                return new List<Cliente>();
            }
        }

        public Cliente GetById(int id)
        {
            try 
            {
                var Cliente = ctx.Clienti.Include(c => c.Ordini)
                    .FirstOrDefault(c => c.Id == id);
                return Cliente;
            }
            catch (Exception)
            { 
                return null;
            }
        }

        public bool Update(Cliente updatedCliente)
        {
            try
            {
                ctx.Clienti.Update(updatedCliente);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
