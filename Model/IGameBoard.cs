namespace Model
{
    /// <summary>
    /// ゲーム盤インターフェース
    /// </summary>
    public interface IGameBoard
    {
        void OnChangePhase(IPhase phase);

        void OnUnitMove(Unit unit, Hex hex);

        void OnAttackTargetChanged(Unit unit, Unit targetOrNull);

        void OnAttack(Unit target, int targetDamage, Unit counteredAttacker, int attackerDamage);

        void OnFinishedGame(string result);
    }
}
