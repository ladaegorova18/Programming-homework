namespace SimpleFTP
{
    /// <summary>
    /// interface to write responses 
    /// </summary>
    public interface IWriteable 
    {
        void Write(string line);

        string Read();
    }
}
