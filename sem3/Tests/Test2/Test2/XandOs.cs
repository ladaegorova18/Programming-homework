namespace Test2
{
    /// <summary>
    /// logic class for values in grid
    /// </summary>
    public class XandOs
    {
        /// <summary>
        /// count of used cells
        /// </summary>
        public int Count { get; set; } = 0;

        /// <summary>
        /// values in cells
        /// </summary>
        public string[,] Values { get; set; } = new string[3, 3];

        /// <summary>
        /// checks if current player wins
        /// </summary>
        /// <param name="player"> player "X" or "O" </param>
        /// <returns> true if wins </returns>
        public bool CheckWin(string player)
        {
            return
            ((Values[0, 0] == player & Values[0, 1] == player & Values[0, 2] == player)
                ||
            (Values[0, 0] == player & Values[1, 0] == player & Values[2, 0] == player)
                ||
            (Values[2, 0] == player & Values[2, 1] == player & Values[2, 2] == player)
                ||
            (Values[0, 2] == player & Values[1, 2] == player & Values[2, 2] == player)
                ||
            (Values[0, 0] == player & Values[1, 1] == player & Values[2, 2] == player)
                ||
            (Values[0, 2] == player & Values[1, 1] == player & Values[2, 0] == player)
                ||
            (Values[1, 0] == player & Values[1, 1] == player & Values[1, 2] == player)
                ||
            (Values[0, 1] == player & Values[1, 1] == player & Values[2, 1] == player));
        }
    }
}
