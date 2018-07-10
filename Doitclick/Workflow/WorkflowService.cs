using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doitclick.Data;

namespace Doitclick.Workflow
{
    public class WorkflowService : IWorkflowService
    {
        public ApplicationDbContext Context { get; set; }

        public WorkflowService()
        {

        }

        public WorkflowService(ApplicationDbContext _context)
        {
            Context = _context;
        }


        public void CompletarTarea(int SolicitudId, int TareaId, int UsuarioId)
        {
            throw new NotImplementedException();
        }

        public void CompletarTarea(int SolicitudId, int TareaId, string UsuarioIdentificador)
        {
            throw new NotImplementedException();
        }

        public void CompletarTarea(string NumeroTicket, int TareaId, int UsuarioId)
        {
            throw new NotImplementedException();
        }

        public void CompletarTarea(string NumeroTicket, int TareaId, string UsuarioIdentificador)
        {
            throw new NotImplementedException();
        }

        public int GeneraSolicitud(int ProcesoId, int ClienteId, int UsuarioId)
        {
            
            throw new NotImplementedException();
        }

        public int GeneraSolicitud(int ProcesoId, int ClienteId, string UsuarioIdentificador)
        {
            throw new NotImplementedException();
        }

        public int GeneraSolicitud(int ProcesoId, string ClienteRut, string UsuarioIdentificador)
        {
            throw new NotImplementedException();
        }
    }
}
