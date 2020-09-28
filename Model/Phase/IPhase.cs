namespace Model
{
    /// <summary>
    /// フェーズインターフェース
    /// </summary>
    public interface IPhase
    {
        #region プロパティ

        /// <summary>
        /// フェーズ種別
        /// </summary>
        PhaseType Type { get; }

        /// <summary>
        /// フェーズ名
        /// </summary>
        string Name { get; }

        #endregion

        #region メソッド

        /// <summary>
        /// 有効か
        /// </summary>
        /// <returns>有効か</returns>
        bool IsValid();

        /// <summary>
        /// 開始する
        /// </summary>
        void Start();

        /// <summary>
        /// 終了する
        /// </summary>
        void Finish();

        /// <summary>
        /// 部隊が選択された時の処理
        /// </summary>
        /// <param name="unit">部隊</param>
        void OnSelectUnit(Unit unit);

        /// <summary>
        /// へクスが選択された時の処理
        /// </summary>
        /// <param name="hex">へクス</param>
        void OnSelectHex(Hex hex);

        #endregion
    }
}
