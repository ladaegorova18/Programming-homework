namespace SimpleFTP.Tests
{
    /// <summary>
    /// WriteForTests with empty methods
    /// </summary>
    public class WriteForTests : IWriteable
    {
        /// <summary>
        /// empty "write"
        /// </summary>
        public void Write(string line) { }

        /// <summary>
        /// empty "read"
        /// </summary>
        public string Read() => null;
    }
}
