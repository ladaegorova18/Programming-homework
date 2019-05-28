namespace ConsoleGame
{
    /// <summary>
    /// To draw on console in main program and not to draw while unit-testing
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        /// redraws map every turn
        /// </summary>
        /// <param name="coords"> gamer coords </param>
        /// <param name="oldCoords"> old gamer coords </param>
        void Draw((int, int) coords, (int, int) oldCoords);

        /// <summary>
        /// draws gamer on map
        /// </summary>
        /// <param name="gamerCoords"> gamer coords </param>
        void DrawGamer((int, int) gamerCoords);
    }
}
