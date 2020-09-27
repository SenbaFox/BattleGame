namespace Model
{
    /// <summary>
    /// ゲーム盤インターフェース
    /// </summary>
    public interface IGameBoard
    {
        void ChangedPhase(string phaseName);

        void MovedUnit(Unit unit, Hex hex);

        void FinishedGame(string result);
    }
}
