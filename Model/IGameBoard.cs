namespace Model
{
    /// <summary>
    /// ゲーム盤インターフェース
    /// </summary>
    public interface IGameBoard
    {
        void OnChangePhase(string phaseName);

        void OnUnitMove(Unit unit, Hex hex);

        void OnAttack(Unit target, int targetDamage, Unit counteredAttacker, int attackerDamage);

        void OnFinishedGame(string result);
    }
}
