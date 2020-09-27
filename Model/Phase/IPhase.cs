namespace Model
{
    /// <summary>
    /// フェーズインターフェース
    /// </summary>
    public interface IPhase
    {
        PhaseType Type { get; }

        string Name { get; }

        bool IsValid();

        void Start();

        void Finish();

        void SelectUnit(Unit unit);

        void SelectHex(Hex hex);
    }
}
