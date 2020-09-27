using System;
using System.Linq;

namespace Model
{
    /// <summary>
    /// ゲーム
    /// </summary>
    public class Game
    {
        // TODO:シングルトンにする

        private Turn turn;

        private IGameBoard gameBoard;

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

        /// <summary>
        /// 初期化する
        /// </summary>
        /// <param name="gameBoard">ゲーム盤</param>
        /// <param name="oErrMsg">エラーメッセージ</param>
        /// <returns>成功 or 失敗</returns>
        public bool TryInitialize(IGameBoard gameBoard, out string oErrMsg)
        {
            this.gameBoard = gameBoard;
            Setting setting = new Setting();
            try
            {
                if (setting.TryLoad(out Field field, out Army[] armies, out oErrMsg))
                {
                    this.BattleField = field;
                    this.Armies = armies;
                    this.turn = new Turn(gameBoard, this.Armies, field);
                    this.turn.StartNextPhase();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                oErrMsg = e.Message;
                // TODO: ログ出力を実装
                return false;
            }
        }

        public void MoveNextPhase()
        {
            this.turn.FinishCurrentPhase();

            if (this.Armies[0].IsAnnihilation || this.Armies[1].IsAnnihilation)
            {
                this.gameBoard.FinishedGame(this.GetResult());
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

        public void SelectUnit(Unit unit)
        {
            this.turn.SelectUnit(unit);
        }

        public void SelectHex(Hex hex)
        {
            this.turn.SelectHex(hex);
        }
    }
}
