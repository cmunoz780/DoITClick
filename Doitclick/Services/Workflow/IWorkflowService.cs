using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doitclick.Services.Workflow
{
    public interface IWorkflowService
    {
        void Instanciar();

        void Avanzar();

        void Abortar();
    }
}
