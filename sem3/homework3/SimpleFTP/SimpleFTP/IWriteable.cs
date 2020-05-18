namespace SimpleFTP
{
    /// <summary>
    /// interface to write responses 
    /// </summary>
    public interface IWriteable 
    {
        /// <summary>
        /// method to write messages
        /// </summary>
        /// <param name="message"> message to write </param>
        void Write(string message);

        /// <summary>
        /// method to read messages
        /// </summary>
        /// <returns> message that was read </returns>
        string Read();
    }
}
