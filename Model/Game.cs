using System;
using System.Linq;

namespace Model
{
    /// <summary>
    /// ゲーム
    /// </summary>
    public class Game
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        private static readonly Game instance = new Game();

        #region メンバ変数

        /// <summary>
        /// ターン
        /// </summary>
        private Turn turn;

        /// <summary>
        /// ゲーム盤
        /// </summary>
        private IGameBoard gameBoard;

        #endregion

        #region プロパティ

        /// <summary>
        /// 戦場
        /// </summary>
        public Field BattleField { get; private set; }

        /// <summary>
        /// 軍
        /// </summary>
        public Army[] Armies { get; private set; }

        #endregion

        #region メソッド

        /// <summary>
        /// インスタンスを取得する
        /// </summary>
        /// <returns>ゲーム</returns>
        public static Game GetInstance()
        {
            return instance;
        }

        private Game() { }

        /// <summary>
        /// 初期化する
        /// </summary>
        /// <param name="gameBoard">ゲーム盤</param>
        public void Initialize(IGameBoard gameBoard)
        {
            this.gameBoard = gameBoard;

            Setting setting = new Setting();
            setting.Load(out Field field, out Army[] armies);

            this.BattleField = field;
            this.Armies = armies;
            this.turn = new Turn(gameBoard, this.Armies, field);

            this.turn.StartNextPhase();
        }

        /// <summary>
        /// 次のフェーズへ移行
        /// </summary>
        public void MoveNextPhase()
        {
            this.turn.FinishCurrentPhase();

            if (this.Armies[0].IsAnnihilation || this.Armies[1].IsAnnihilation)
            {
                this.gameBoard.OnFinishedGame(this.GetResult());
                return;
            }

            this.turn.StartNextPhase();
        }

        private string GetResult()
        {
            Army winner = this.Armies.FirstOrDefault(army => !army.IsAnnihilation);

            if (winner == null)
            {
                return "引き分け！";
            }
            else
            {
                return winner.Name + "の勝利！";
            }
        }

        /// <summary>
        /// 部隊が選択された時の処理
        /// </summary>
        /// <param name="unit">部隊</param>
        public void OnSelectUnit(Unit unit)
        {
            this.turn.OnSelectUnit(unit);
        }

        /// <summary>
        /// へクスが選択された時の処理
        /// </summary>
        /// <param name="hex">へクス</param>
        public void OnSelectHex(Hex hex)
        {
            this.turn.OnSelectHex(hex);
        }

        #endregion
    }
}
