using Prova.Core.Interfacce;
using Prova.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Prova.Core.EF.Repos
{
    public class EFOrdineRepos : IOrdineRepos
    {
        private readonly MBLContext ctx;

        public EFOrdineRepos():this(new MBLContext()) { }

        public EFOrdineRepos(MBLContext ctx)
        {
            this.ctx = ctx;
        }


        public bool Add(Ordine newOrdine)
        {
            try
            {
                ctx.Ordini.Add(newOrdine);
                ctx.SaveChanges();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Ordine item)
        {
            try
            {
                var Ordine = ctx.Ordini.Find(item.Id);
                if (Ordine != null)
                    ctx.Ordini.Remove(Ordine);
                ctx.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public List<Ordine> Fetch()
        {
            try
            {
                return ctx.Ordini.ToList();
            }
            catch (Exception)
            {
                return new List<Ordine>();
            }
        }

        public Ordine GetById(int id)
        {
            try
            {
                var Ordine = ctx.Ordini.Find(id);
                return Ordine;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(Ordine item)
        {
            try
            {
                ctx.Ordini.Update(item);
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
