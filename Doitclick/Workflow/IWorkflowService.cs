using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doitclick.Workflow
{
    public interface IWorkflowService
    {
        int GeneraSolicitud(int ProcesoId, int ClienteId, int UsuarioId);

        int GeneraSolicitud(int ProcesoId, int ClienteId, string UsuarioIdentificador);

        int GeneraSolicitud(int ProcesoId, string ClienteRut, string UsuarioIdentificador);

        void CompletarTarea(int SolicitudId, int TareaId, int UsuarioId);

        void CompletarTarea(int SolicitudId, int TareaId, string UsuarioIdentificador);

        void CompletarTarea(string NumeroTicket, int TareaId, int UsuarioId);

        void CompletarTarea(string NumeroTicket, int TareaId, string UsuarioIdentificador);
    }
}
