namespace Model
{
    /// <summary>
    /// フェーズインターフェース
    /// </summary>
    public interface IPhase
    {
        PhaseType Type { get; }

        string Name { get; }

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
    }
}
