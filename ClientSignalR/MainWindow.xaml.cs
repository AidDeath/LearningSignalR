using Microsoft.AspNetCore.SignalR.Client;
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

namespace ClientSignalR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HubConnection hubConnection;
        public MainWindow()
        {
            InitializeComponent();
            hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7298/chat")
                .WithAutomaticReconnect()
                .Build();
           


        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await hubConnection.StartAsync();
            ConnState.Text = hubConnection.State.ToString();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            hubConnection.SendAsync("Log", "Hello! I am message from client!");
        }        
    }
}
