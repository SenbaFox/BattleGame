namespace Model
{
    /// <summary>
    /// へクス
    /// </summary>
    public class Hex
    {
        #region プロパティ

        /// <summary>
        /// 地形
        /// </summary>
        public Geography Geography { get; private set; }

        /// <summary>
        /// ここにいる部隊
        /// </summary>
        public Unit LandedUnit { get; private set; }

        /// <summary>
        /// 配置できるか
        /// </summary>
        public bool CanLand => (this.Geography.CanLand && this.IsUnitLanded == false);

        /// <summary>
        /// 部隊がいるか
        /// </summary>
        public bool IsUnitLanded => (this.LandedUnit != null);

        #endregion

        #region メソッド

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="geography">地形</param>
        internal Hex(Geography geography)
        {
            this.Geography = geography;
        }

        /// <summary>
        /// 部隊が配置される
        /// </summary>
        /// <param name="unit">部隊</param>
        internal void OnLanded(Unit unit)
        {
            this.LandedUnit = unit;
        }

        /// <summary>
        /// 部隊が離れる
        /// </summary>
        internal void OnTakeOff()
        {
            this.LandedUnit = null;
        }

        #endregion
    }
}
