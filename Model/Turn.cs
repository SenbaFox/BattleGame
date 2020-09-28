using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// ターン
    /// </summary>
    public class Turn
    {
        #region メンバ変数

        /// <summary>
        /// ゲーム盤
        /// </summary>
        private readonly IGameBoard gameBoard;

        /// <summary>
        /// フェーズ
        /// </summary>
        private readonly List<IPhase> phases = new List<IPhase>();

        /// <summary>
        /// 現フェーズのインデックス
        /// </summary>
        private int currentPhaseIndex = -1;

        #endregion

        #region メソッド

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="gameBoard">ゲーム盤</param>
        /// <param name="armies">軍隊</param>
        /// <param name="field">戦場</param>
        public Turn(IGameBoard gameBoard, Army[] armies, Field field)
        {
            this.gameBoard = gameBoard;

            this.phases.Add(new MovePhase(gameBoard, field, armies[0]));
            this.phases.Add(new AttackPhase(gameBoard, field, armies[0], armies[1]));
            this.phases.Add(new MovePhase(gameBoard, field, armies[1]));
            this.phases.Add(new AttackPhase(gameBoard, field, armies[1], armies[0]));
        }

        /// <summary>
        /// 現在のフェーズを終了する
        /// </summary>
        public void FinishCurrentPhase()
        {
            this.phases[currentPhaseIndex].Finish();
        }

        /// <summary>
        /// 次のフェーズを開始する
        /// </summary>
        public void StartNextPhase()
        {
            do {
                this.currentPhaseIndex =
                    (this.currentPhaseIndex >= (this.phases.Count - 1)) ? 0 : (this.currentPhaseIndex + 1);
            }
            while (!this.phases[currentPhaseIndex].IsValid());

            this.phases[currentPhaseIndex].Start();
            this.gameBoard.OnChangePhase(this.phases[currentPhaseIndex]);
        }

        /// <summary>
        /// 部隊が選択された時の処理
        /// </summary>
        /// <param name="unit">部隊</param>
        public void OnSelectUnit(Unit unit)
        {
            this.phases[currentPhaseIndex].OnSelectUnit(unit);
        }

        /// <summary>
        /// へクスが選択された時の処理
        /// </summary>
        /// <param name="hex">へクス</param>
        public void OnSelectHex(Hex hex)
        {
            this.phases[currentPhaseIndex].OnSelectHex(hex);
        }

        #endregion
    }
}
