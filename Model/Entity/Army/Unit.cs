using System;

namespace Model
{
    /// <summary>
    /// 部隊
    /// </summary>
    public　class Unit
    {
        /// <summary>
        /// ステータス変更イベント
        /// </summary>
        public event EventHandler ChangedStatus;

        /// <summary>
        /// 機動力
        /// </summary>
        private readonly int mobilePower;

        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 兵数
        /// </summary>
        public int Headcount { get; private set; }

        /// <summary>
        /// 現在いるへクス
        /// </summary>
        public Hex CurrentHex { get; private set; }

        /// <summary>
        /// 所属する軍
        /// </summary>
        public Army Army { get; private set; }

        /// <summary>
        /// 兵科
        /// </summary>
        public Branch Branch { get; private set; }

        /// <summary>
        /// 現フェーズで移動可能な距離
        /// </summary>
        public int MovableDistanceInCurrentPhase { get; private set; }

        /// <summary>
        /// 全滅したか
        /// </summary>
        public bool IsAnnihilation
        {
            get
            {
                return (this.Headcount <= 0);
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="army">軍隊</param>
        /// <param name="name">名前</param>
        /// <param name="branch">兵科</param>
        /// <param name="mobilePower">機動力</param>
        /// <param name="headcount">兵数</param>
        internal Unit(Army army, string name, Branch branch, int mobilePower, int headcount)
        {
            this.Army = army;
            this.Name = name;
            this.Branch = branch;
            this.mobilePower = mobilePower;
            this.Headcount = headcount;
        }

        /// <summary>
        /// 移動する
        /// </summary>
        /// <param name="hex">移動先のへクス</param>
        internal void Move(Hex hex)
        {
            this.CurrentHex = hex;
            if (this.MovableDistanceInCurrentPhase > 0)
            {
                this.MovableDistanceInCurrentPhase += -1;
            }
            this.OnChangedStatus(EventArgs.Empty);
        }


        /// <summary>
        /// ダメージを受ける
        /// </summary>
        /// <param name="damage">ダメージ</param>
        internal void TakeDamage(int damage)
        {
            this.Headcount -= damage;
            if (this.Headcount < 0)
            {
                this.Headcount = 0;
            }
            this.OnChangedStatus(EventArgs.Empty);
        }

        /// <summary>
        /// 移動フェーズ開始
        /// </summary>
        internal void StartMovePhase()
        {
            this.MovableDistanceInCurrentPhase = this.mobilePower;
            this.OnChangedStatus(EventArgs.Empty);
        }

        /// <summary>
        /// 移動フェーズ終了
        /// </summary>
        internal void FinishMovePhase()
        {
            this.MovableDistanceInCurrentPhase = 0;
            this.OnChangedStatus(EventArgs.Empty);
        }

        /// <summary>
        /// ステータス変更イベントを発生させる
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnChangedStatus(EventArgs e)
        {
            this.ChangedStatus?.Invoke(this, e);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
