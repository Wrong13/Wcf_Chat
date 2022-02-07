using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Wcf_Chat
{
    // ПРИМЕЧАНИЕ. Можно использовать команду "Переименовать" в меню "Рефакторинг", чтобы изменить имя интерфейса "IServiceChat" в коде и файле конфигурации.
    [ServiceContract]
    public interface IServiceChat
    {
        [OperationContract]
        void DoWork();

    }
}
