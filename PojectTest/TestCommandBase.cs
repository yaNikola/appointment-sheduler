using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojectTest
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly SchedulerDbContext Context;

        public TestCommandBase()
        {
            Context = ContextFactory.Create();
        }

        public void Dispose()
        {
            ContextFactory.Destroy(Context);
        }
    }
}
