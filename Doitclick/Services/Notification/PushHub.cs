using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Doitclick.Models.Security;
using System.Security.Claims;

namespace Doitclick.Services.Notification
{
    public class PushHub : Hub
    {

        public async Task SendMessage(string user, string message)
        { 
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        

        public async Task NotificarCotizacionEntrante(Usuario usuario, string numeroTicket)
        {
            await Clients.User(usuario.Identificador).SendAsync("NotificarCotizacionEntrante", numeroTicket);
        }

        public async Task NotificarCotizacionSaliente(Usuario usuario, string numeroTicket)
        {
            await Clients.User(usuario.Identificador).SendAsync("NotificarCotizacionSaliente", numeroTicket);
        }
    }
}
