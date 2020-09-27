namespace Model
{
    /// <summary>
    /// フェーズインターフェース
    /// </summary>
    internal interface IPhase
    {
        string Name { get; }

        void Start();

        void Finish();

        void SelectUnit(Unit unit);

        void SelectHex(Hex hex);
    }
}
