namespace Model
{
    /// <summary>
    /// 地形
    /// </summary>
    public class Geography
    {
        #region プロパティ

        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// 配置できるか
        /// </summary>
        public bool CanLand { get; private set; }

        #endregion

        #region メソッド

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="canLand">配置できるか</param>
        internal Geography(int id, bool canLand)
        {
            this.ID = id;
            this.CanLand = canLand;
        }

        #endregion
    }
}
