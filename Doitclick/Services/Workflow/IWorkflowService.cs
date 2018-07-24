using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doitclick.Services.Workflow
{
    public interface IWorkflowService
    {
        void Instanciar(string nombreProceso, string identificacionUsuario, string resumenInstancia);

        void Avanzar(string nombreInternoProceso, string nombreInternoEtapa, string numeroTicket, string identificacionUsuario);

        void Abortar();
    }
}
