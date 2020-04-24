namespace GUIForServer
{
    /// <summary>
    /// Interface for writing messages on console
    /// </summary>
    public interface IWriteable
    {
        void Write(string line);

        string Read();
    }
}
