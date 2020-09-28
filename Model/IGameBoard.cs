namespace Model
{
    /// <summary>
    /// ゲーム盤インターフェース
    /// </summary>
    public interface IGameBoard
    {
        #region メソッド

        /// <summary>
        /// フェーズが変わった時の処理
        /// </summary>
        /// <param name="newPhase">新フェーズ</param>
        void OnChangePhase(IPhase newPhase);

        /// <summary>
        /// 部隊が移動した時の処理
        /// </summary>
        /// <param name="unit">部隊</param>
        /// <param name="hex">へクス</param>
        void OnUnitMove(Unit unit, Hex hex);

        /// <summary>
        /// 攻撃対象が変わった時の処理
        /// </summary>
        /// <param name="unit">部隊</param>
        /// <param name="targetOrNull">攻撃対象、解除された時はNull</param>
        void OnAttackTargetChanged(Unit unit, Unit targetOrNull);

        /// <summary>
        /// 攻撃が発生した時の処理
        /// </summary>
        /// <param name="target">攻撃対象</param>
        /// <param name="targetDamage">攻撃対象の損害</param>
        /// <param name="counteredAttacker">反撃を受けた攻撃部隊</param>
        /// <param name="attackerDamage">攻撃部隊の損害</param>
        void OnAttack(Unit target, int targetDamage, Unit counteredAttacker, int attackerDamage);

        /// <summary>
        /// ゲームが終了した時の処理
        /// </summary>
        /// <param name="result">結果</param>
        void OnFinishedGame(string result);

        #endregion
    }
}
