using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Wcf_Chat
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceChat : IServiceChat
    {
        List <ServerUser> users = new List <ServerUser>();
        int nextId = 1;
        public int Connect(string name)
        {
            ServerUser user = new ServerUser()
            {
                ID = nextId,
                Name = name,
                operationContext = OperationContext.Current
            };
            nextId++;

            SendMessage(user.Name + " Подключился к чату",0);
            users.Add(user);
            return user.ID;
        }

        public void Disconnect(int id)
        {
            var DisUser = users.FirstOrDefault(x => x.ID == id);
            if (DisUser != null)
            {
                users.Remove(DisUser);
                SendMessage(DisUser.Name + " Отключился от чата",0);
            }
        }

        public void SendMessage(string msg, int id)
        {

        }
    }
}
