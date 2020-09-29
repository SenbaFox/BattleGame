namespace Model
{
    /// <summary>
    /// 移動フェーズ
    /// </summary>
    internal class MovePhase : IPhase
    {
        #region メンバ変数

        /// <summary>
        /// ゲーム盤
        /// </summary>
        private readonly IGameBoard gameBoard;

        /// <summary>
        /// 戦場
        /// </summary>
        private readonly Field field;

        /// <summary>
        /// 行動する軍
        /// </summary>
        private readonly Army activeArmy;

        /// <summary>
        /// 選択中の部隊
        /// </summary>
        private Unit selectedUnit;

        #endregion

        #region プロパティ

        public PhaseType Type => PhaseType.移動;

        public string Name => this.activeArmy.Name + "移動フェーズ";

        #endregion

        #region メソッド

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="gameBoard">ゲーム盤</param>
        /// <param name="field">戦場</param>
        /// <param name="activeArmy">行動する軍</param>
        public MovePhase(IGameBoard gameBoard, Field field, Army activeArmy)
        {
            this.gameBoard = gameBoard;
            this.field = field;
            this.activeArmy = activeArmy;
        }

        public bool IsValid()
        {
            return true;
        }

        public void Start()
        {
            this.activeArmy.OnStartMovePhase();
        }

        public void Finish()
        {
            this.selectedUnit = null;
            this.activeArmy.OnFinishMovePhase();
        }

        public void OnSelectUnit(Unit unit)
        {
            if (this.activeArmy.Contain(unit))
            {
                this.selectedUnit = unit;
            }
        }

        public void OnSelectHex(Hex hex)
        {
            if (this.CanSetUnit(hex) == false)
            {
                return;
            }

            this.field.SetUnit(this.selectedUnit, hex);
            this.gameBoard.OnUnitMove(this.selectedUnit, hex);
        }

        private bool CanSetUnit(Hex hex)
        {
            return ((this.selectedUnit != null) &&
                    (this.selectedUnit.MovableDistanceInCurrentPhase > 0) &&
                    (hex.CanLand) &&
                    (this.field.AreLayingSideBySide(this.selectedUnit.CurrentHex, hex)));
        }

        #endregion
    }
}
