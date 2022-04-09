using System.Threading.Tasks;

namespace GUIForServer
{
    /// <summary>
    /// Server start
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Creates server to listen
        /// </summary>
        static async Task Main(string[] args)
        {
            var server = new Server(8888);
            await server.Process();
        }
    }
}
