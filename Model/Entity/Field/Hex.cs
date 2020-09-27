namespace Model
{

    /// <summary>
    /// へクス
    /// </summary>
    public class Hex
    {
        /// <summary>
        /// 地形
        /// </summary>
        public Geography Geography { get; private set; }

        /// <summary>
        /// ここにいる部隊
        /// </summary>
        public Unit LandedUnit { get; private set; }

        /// <summary>
        /// 移動できるか
        /// </summary>
        public bool CanMove => (this.Geography.CanMove && this.IsUnitLandedOn == false);

        /// <summary>
        /// 部隊がいるか
        /// </summary>
        public bool IsUnitLandedOn => (this.LandedUnit != null);

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
        internal void LandedOn(Unit unit)
        {
            this.LandedUnit = unit;
        }

        /// <summary>
        /// 部隊が離れる
        /// </summary>
        internal void TakeOff()
        {
            this.LandedUnit = null;
        }
    }
}
