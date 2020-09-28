using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Model
{
    /// <summary>
    /// 攻撃フェーズ
    /// </summary>
    internal class AttackPhase : IPhase
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
        /// 敵軍
        /// </summary>
        private readonly Army enemy;

        /// <summary>
        /// 部隊毎の攻撃対象
        /// </summary>
        private readonly Dictionary<Unit, Unit> attackTargets = new Dictionary<Unit, Unit>();

        /// <summary>
        /// 選択中の部隊
        /// </summary>
        private Unit selectedUnit;

        /// <summary>
        /// 乱数
        /// </summary>
        private readonly Random random = new Random(DateTime.Now.Second);

        #endregion

        #region プロパティ

        /// <summary>
        /// フェーズ種別
        /// </summary>
        public PhaseType Type => PhaseType.攻撃;

        /// <summary>
        /// フェーズ名
        /// </summary>
        public string Name => this.activeArmy.Name + "攻撃フェーズ";

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="gameBoard">ゲーム盤</param>
        /// <param name="field">戦場</param>
        /// <param name="activeArmy">行動する軍</param>
        /// <param name="enemy">敵軍</param>
        public AttackPhase(IGameBoard gameBoard, Field field, Army activeArmy, Army enemy)
        {
            this.gameBoard = gameBoard;
            this.field = field;
            this.activeArmy = activeArmy;
            this.enemy = enemy;
        }

        /// <summary>
        /// 有効か
        /// </summary>
        /// <returns>有効か</returns>
        public bool IsValid()
        {
            foreach (Unit activeUnit in this.activeArmy.Units)
            {
                foreach (Unit enemyUnit in this.enemy.Units)
                {
                    if (this.field.AreLayingSideBySide(activeUnit, enemyUnit))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 開始する
        /// </summary>
        public void Start()
        {
            foreach (Unit unit in this.activeArmy.Units)
            {
                this.attackTargets.Add(unit, null);
            }
        }

        #region 終了する

        /// <summary>
        /// 終了する
        /// </summary>
        public void Finish()
        {
            Dictionary<Unit, List<Unit>> attackersByTarget = this.GetAttackersByTarget();

            foreach (var (target, attackers) in attackersByTarget)
            {
                this.Attack(attackers.ToArray(), target);
            }

            this.activeArmy.ApplyTakedAttack();
            this.enemy.ApplyTakedAttack();

            this.initialize();
        }

        private Dictionary<Unit, List<Unit>> GetAttackersByTarget()
        {
            Dictionary<Unit, List<Unit>> attackersByTarget = new Dictionary<Unit, List<Unit>>();
            foreach (var (attacker, target) in this.attackTargets)
            {
                if (target == null)
                {
                    continue;
                }

                if (!attackersByTarget.ContainsKey(target))
                {
                    attackersByTarget.Add(target, new List<Unit>());
                }

                attackersByTarget[target].Add(attacker);
            }

            return attackersByTarget;
        }

        #region 攻撃

        private void Attack(Unit[] attackers, Unit target)
        {
            int attackerHeadcount = attackers.Sum(attacker => attacker.Headcount);
            // 複数方向からの攻撃は攻撃力アップ
            int attackerPower = attackers.Length == 1 ? attackerHeadcount : attackerHeadcount *= 2;
            int targetDamage = this.CalculateDamage(attackerPower);
            // 対象がダメージを受ける前に対象の兵力で攻撃側ダメージを計算
            int attackerDamage = this.CalculateDamage(target.Headcount);

            target.TakeDamage(targetDamage);
            // 反撃は、攻撃側の最大兵力の部隊が受ける
            Unit counteredAttacker = attackers.OrderByDescending(unit => unit.Headcount).First();
            counteredAttacker.TakeDamage(attackerDamage);

            this.gameBoard.OnAttack(target, targetDamage, counteredAttacker, attackerDamage);
        }

        private int CalculateDamage(int power)
        {
            int randomValue = this.random.Next(1, 4);

            return randomValue * power / 10;
        }

        #endregion

        private void initialize()
        {
            this.selectedUnit = null;

            foreach (Unit unit in this.attackTargets.Keys)
            {
                this.gameBoard.OnAttackTargetChanged(unit, null);
            }
            this.attackTargets.Clear();
        }

        #endregion

        #region 部隊が選択された時の処理

        /// <summary>
        /// 部隊が選択された時の処理
        /// </summary>
        /// <param name="unit">部隊</param>
        public void OnSelectUnit(Unit unit)
        {
            if (this.activeArmy.Contain(unit))
            {
                this.OnSelectActiveArmyUnit(unit);
            }
            else
            {
                this.OnSelectEnemyUnit(unit);
            }
        }

        private void OnSelectActiveArmyUnit(Unit unit)
        {
            if ((this.selectedUnit != null) && (this.selectedUnit == unit))
            {
                this.selectedUnit = null;
            }
            else
            {
                this.selectedUnit = unit;
            }
        }

        private void OnSelectEnemyUnit(Unit unit)
        {
            if ((this.selectedUnit == null) || !this.field.AreLayingSideBySide(this.selectedUnit, unit))
            {
                return;
            }

            if (this.attackTargets[this.selectedUnit] == unit)
            {
                this.attackTargets[this.selectedUnit] = null;
            }
            else
            {
                this.attackTargets[this.selectedUnit] = unit;
            }

            this.gameBoard.OnAttackTargetChanged(this.selectedUnit, this.attackTargets[this.selectedUnit]);
        }

        #endregion

        /// <summary>
        /// へクスが選択された時の処理
        /// </summary>
        /// <param name="hex">へクス</param>
        public void OnSelectHex(Hex hex)
        {
        }
    }
}
