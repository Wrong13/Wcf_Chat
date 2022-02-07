using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChatClient.ServiceChat;

namespace ChatClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IServiceChatCallback
    {
        bool IsConnexted = false;
        ServiceChat.ServiceChatClient client;
        int ID;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        void ConnectUser()
        {
            if (!IsConnexted)
            {
                client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
                ID = client.Connect(BoxUserName.Text);
                BoxUserName.IsEnabled = false;
                BtnConnect.Content = "Откл";
                IsConnexted = true;
            }
        }
        void DisconnectUser()
        {
            if (IsConnexted)
            {
                client.Disconnect(ID);
                client = null;
                BoxUserName.IsEnabled = true;
                BtnConnect.Content = "Подкл";
                IsConnexted = false;
            }
        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            if (IsConnexted)
            {
                DisconnectUser();
            }
            else
            {
                ConnectUser();
            }
        }
        
        public void MsgCallback(string msg)
        {
            lbChat.Items.Add(msg);
            lbChat.ScrollIntoView(lbChat.Items[lbChat.Items.Count -1]);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DisconnectUser();
        }

        private void lbChat_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void tbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (client != null)
                {
                    client.SendMsg(tbMessage.Text, ID);
                    tbMessage.Text = null;
                }
            }
        }
    }
}
