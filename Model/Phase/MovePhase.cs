namespace Model
{
    internal class MovePhase : IPhase
    {
        private readonly IGameBoard gameBoard;

        private readonly Field field;

        private readonly Army activeArmy;

        private Unit selectedUnit;

        public PhaseType Type => PhaseType.移動;

        public string Name => this.activeArmy.Name + "移動フェーズ";

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
            this.activeArmy.StartMovePhase();
        }

        public void Finish()
        {
            this.selectedUnit = null;
            this.activeArmy.FinishMovePhase();
        }

        public void SelectUnit(Unit unit)
        {
            if (this.activeArmy.Contain(unit))
            {
                this.selectedUnit = unit;
            }
        }

        public void SelectHex(Hex hex)
        {
            if (this.CanMove(hex) == false)
            {
                return;
            }

            this.field.SetUnit(this.selectedUnit, hex);
            this.gameBoard.OnUnitMove(this.selectedUnit, hex);
        }

        private bool CanMove(Hex hex)
        {
            return ((this.selectedUnit != null) &&
                    (this.selectedUnit.MovableDistanceInCurrentPhase > 0) &&
                    (hex.CanMove) &&
                    (this.field.AreLayingSideBySide(this.selectedUnit.CurrentHex, hex)));
        }
    }
}
