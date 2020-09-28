using System.Collections.Generic;
using System.Linq;

namespace Model
{
    /// <summary>
    /// 軍
    /// </summary>
    public class Army
    {
        #region メンバ変数

        /// <summary>
        /// 所属する部隊のリスト
        /// </summary>
        private readonly List<Unit> unitList = new List<Unit>();

        #endregion

        #region プロパティ

        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 所属する部隊
        /// </summary>
        public Unit[] Units 
        {
            get
            {
                return this.unitList.ToArray();
            }
            internal set
            {
                this.unitList.AddRange(value);
            }
        }

        /// <summary>
        /// 兵数
        /// </summary>
        public int HeadCount
        {
            get
            {
                return this.unitList.Sum(unit => unit.Headcount);
            }
        }

        /// <summary>
        /// 全滅したか
        /// </summary>
        public bool IsAnnihilation
        {
            get
            {
                return (this.unitList.Count == 0);
            }
        }

        #endregion

        #region メソッド

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">名前</param>
        internal Army(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        /// <summary>
        /// 所属するか
        /// </summary>
        /// <param name="unit">部隊</param>
        /// <returns>所属するか</returns>
        public bool Contain(Unit unit)
        {
            return this.unitList.Contains(unit);
        }

        /// <summary>
        /// 受けた攻撃を反映する
        /// </summary>
        public void ApplyTakedAttack()
        {
            Unit[] annihilatedUnits = this.unitList.Where(unit => unit.IsAnnihilation).ToArray();
            foreach (Unit unit in annihilatedUnits)
            {
                this.unitList.Remove(unit);
            }
        }

        /// <summary>
        /// 移動フェーズ開始
        /// </summary>
        internal void OnStartMovePhase()
        {
            this.unitList.ForEach(unit => unit.OnStartMovePhase());
        }

        /// <summary>
        /// 移動フェーズ終了
        /// </summary>
        internal void OnFinishMovePhase()
        {
            this.unitList.ForEach(unit => unit.OnFinishMovePhase());
        }

        public override string ToString()
        {
            return this.Name;
        }

        #endregion
    }
}
