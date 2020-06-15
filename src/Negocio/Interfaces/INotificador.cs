using Negocio.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
