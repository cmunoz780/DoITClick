using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doitclick.Models.Workflow;
using Doitclick.Models.Security;

namespace Doitclick.Services.Workflow
{
    interface IWorkflowKernel
    {
        Solicitud GenerarSolicitud(Proceso proceso, Usuario usuario);

        Solicitud GenerarSolicitud(string nombreInternoProceso, string identificacionUsuario);

        void ActivarTarea(Proceso proceso, Etapa etapa, Usuario usuario);

        void ActivarTarea(string nombreInternoProceso, string nombreInternoEtapa, string identificacionUsuario);

        void CompletarTarea(Tarea tarea, Usuario usuario);

        void CompletarTarea(string nombreInternoEtapa, string identificacionUsuario);

        void AbortarSolicitud(Solicitud solicitud);

        void AbortarSolicitud(string NumeroTicket);

    }
}
