namespace FTPServer
{
    public interface IWriteable 
    {
        void Write(string line);

        string Read();
    }
}
