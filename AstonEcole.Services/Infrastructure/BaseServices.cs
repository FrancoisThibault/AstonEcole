using AstonEcole.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonEcole.Services.Infrastructure
{
    public abstract class BaseServices : IDisposable
    {
        protected AstonEcoleContext Context { get; private set; }

        protected BaseServices()
        {
            Context = new AstonEcoleContext();
        }

        protected BaseServices(BaseServices otherService)
        {
            Context = otherService.Context;
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
           if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}