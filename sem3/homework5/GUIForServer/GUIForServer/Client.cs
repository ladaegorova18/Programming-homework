﻿using System.ComponentModel;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GUIForServer
{
    /// <summary>
    /// client class
    /// </summary>
    public class Client : INotifyPropertyChanged
    {
        private TcpClient client = null;

        private StreamReader streamReader;
        private StreamWriter streamWriter;

        public bool Connected { get; private set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        /// <summary>
        /// client connection to server
        /// </summary>
        public void Connect(string address, int port)
        {
            try
            {
                client = new TcpClient();
                client.Connect(address, port);
                var stream = client.GetStream();
                streamWriter = new StreamWriter(stream) { AutoFlush = true };
                streamReader = new StreamReader(stream);
                Connected = true;
            }
            catch
            {
                Connected = false;
            }
        }

        /// <summary>
        /// server method to close client
        /// </summary>
        public void Close() => client.Close();

        /// <summary>
        /// user's List command 
        /// </summary>
        /// <param name="path"> path to directory </param>
        /// <returns> list of files in directory </returns>
        public async Task<string> List(string path) => await SendRequest(path, 1).ConfigureAwait(false);

        /// <summary>
        /// user's Get command 
        /// </summary>
        /// <param name="path"> path to file </param>
        /// <returns> file size and file content </returns>
        public async Task<string> Get(string path) => await SendRequest(path, 2).ConfigureAwait(false);

        private async Task<string> SendRequest(string path, int index)
        {
            if (!Connected)
            {
                throw new SocketException();
            }
            try
            {
                await streamWriter.WriteLineAsync($"{index} {path}").ConfigureAwait(false);
                return await streamReader.ReadLineAsync().ConfigureAwait(false);
            }
            catch (SocketException e)
            {
                throw e;
            }
        }
    }
}