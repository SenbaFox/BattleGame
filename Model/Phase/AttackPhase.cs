using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    internal class AttackPhase : IPhase
    {
        private readonly IGameBoard gameBoard;

        private readonly Field field;

        private readonly Army activeArmy;

        private readonly Army targetArmy;

        private readonly Dictionary<Unit, Unit> attackTargets = new Dictionary<Unit, Unit>();

        private Unit selectedUnit;

        private readonly Random random = new Random(DateTime.Now.Second);

        public PhaseType Type => PhaseType.攻撃;

        public string Name => this.activeArmy.Name + "攻撃フェーズ";

        public AttackPhase(IGameBoard gameBoard, Field field, Army activeArmy, Army targetArmy)
        {
            this.gameBoard = gameBoard;
            this.field = field;
            this.activeArmy = activeArmy;
            this.targetArmy = targetArmy;
        }

        public bool IsValid()
        {
            foreach (Unit activeUnit in this.activeArmy.Units)
            {
                foreach (Unit targetUnit in this.targetArmy.Units)
                {
                    if (this.field.AreLayingSideBySide(activeUnit.CurrentHex, targetUnit.CurrentHex))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void Start()
        {
        }

        public void Finish()
        {
            Dictionary<Unit, List<Unit>> attackersByTarget = new Dictionary<Unit, List<Unit>>();
            foreach (var (attacker, target) in this.attackTargets)
            {
                if (!attackersByTarget.ContainsKey(target))
                {
                    attackersByTarget.Add(target, new List<Unit>());
                }
                
                attackersByTarget[target].Add(attacker);
            }

            foreach (var (target, attackers) in attackersByTarget)
            {
                this.Attack(attackers.ToArray(), target);
            }

            this.activeArmy.ApplyTakedAttack();
            this.targetArmy.ApplyTakedAttack();

            foreach (Unit unit in this.attackTargets.Keys)
            {
                this.gameBoard.OnAttackTargetChanged(unit, null);
            }

            this.selectedUnit = null;
            this.attackTargets.Clear();
        }

        private void Attack(Unit[] attackers, Unit target)
        {
            int attackerHeadcount = attackers.Sum(attacker => attacker.Headcount);
            int attackerPower = attackerHeadcount;
            if (attackers.Length > 1)
            {
                attackerPower *= 2;
            }
            int targetDamage = this.CalculateDamage(attackerPower);
            // 対象がダメージを受ける前に対象の兵力で攻撃側ダメージを計算
            int attackerDamage = this.CalculateDamage(target.Headcount);

            target.TakeDamage(targetDamage);
            Unit counteredAttacker = attackers.OrderByDescending(unit => unit.Headcount).First();
            counteredAttacker.TakeDamage(attackerDamage);

            this.gameBoard.OnAttack(target, targetDamage, counteredAttacker, attackerDamage);
        }

        private int CalculateDamage(int power)
        {
            int randomValue = this.random.Next(1, 2);

            // TODO:テスト用なので元に戻す
            //return randomValue * power / 20;
            return randomValue * power / 2;
        }

        public void SelectUnit(Unit unit)
        {
            if ((this.selectedUnit != null) && (this.selectedUnit == unit))
            {
                this.selectedUnit = null;
            }
            else if (this.activeArmy.Contain(unit))
            {
                this.selectedUnit = unit;
            }
            else if(this.selectedUnit != null)
            {
                if (!this.field.AreLayingSideBySide(this.selectedUnit.CurrentHex, unit.CurrentHex))
                {
                    return;
                }

                if (this.attackTargets.ContainsKey(this.selectedUnit))
                {
                    if (this.attackTargets[this.selectedUnit] == unit)
                    {
                        this.attackTargets[this.selectedUnit] = null;
                        this.gameBoard.OnAttackTargetChanged(this.selectedUnit, null);
                    }
                    else
                    {
                        this.attackTargets[this.selectedUnit] = unit;
                        this.gameBoard.OnAttackTargetChanged(this.selectedUnit, unit);
                    }
                }
                else
                {
                    this.attackTargets.Add(this.selectedUnit, unit);
                    this.gameBoard.OnAttackTargetChanged(this.selectedUnit, unit);
                }
            }
        }

        public void SelectHex(Hex hex)
        {
        }
    }
}
