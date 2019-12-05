namespace GUIForServer
{
    public interface IWriteable 
    {
        void Write(string line);

        string Read();
    }
}
