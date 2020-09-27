using System.Collections.Generic;
using System.Diagnostics;

namespace Model
{
    public class Turn
    {
        private readonly IGameBoard gameBoard;

        private readonly List<IPhase> phases = new List<IPhase>();

        private int currentPhaseIndex = -1;

        public Turn(IGameBoard gameBoard, Army[] armies, Field field)
        {
            this.gameBoard = gameBoard;

            this.phases.Add(new MovePhase(gameBoard, field, armies[0]));
            this.phases.Add(new AttackPhase(gameBoard, field, armies[0], armies[1]));
            this.phases.Add(new MovePhase(gameBoard, field, armies[1]));
            this.phases.Add(new AttackPhase(gameBoard, field, armies[1], armies[0]));
        }

        public void FinishCurrentPhase()
        {
            this.phases[currentPhaseIndex].Finish();
        }

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

        public void SelectUnit(Unit unit)
        {
            this.phases[currentPhaseIndex].SelectUnit(unit);
        }

        public void SelectHex(Hex hex)
        {
            this.phases[currentPhaseIndex].SelectHex(hex);
        }
    }
}
