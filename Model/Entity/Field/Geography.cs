namespace Model
{
    /// <summary>
    /// 地形
    /// </summary>
    public class Geography
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// 移動できるか
        /// </summary>
        public bool CanMove { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="canMove">移動できるか</param>
        internal Geography(int id, bool canMove)
        {
            this.ID = id;
            this.CanMove = canMove;
        }
    }
}
