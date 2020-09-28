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

        #region メンバ変数

        /// <summary>
        /// 機動力
        /// </summary>
        private readonly int mobilePower;

        /// <summary>
        /// 名前
        /// </summary>
        private readonly string name;

        /// <summary>
        /// 現フェーズで移動可能な距離
        /// </summary>
        private int movableDistanceInCurrentPhase;

        /// <summary>
        /// 兵数
        /// </summary>
        private int headcount;

        #endregion

        #region プロパティ

        /// <summary>
        /// 兵数
        /// </summary>
        public int Headcount
        {
            get
            {
                return this.headcount;
            }
            private set
            {
                this.headcount = value > 0 ? value : 0;
                if (this.IsAnnihilation)
                {
                    this.CurrentHex.OnTakeOff();
                }

                this.OnChangedStatus(EventArgs.Empty);
            }
        }

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
        public int MovableDistanceInCurrentPhase
        {
            get
            {
                return this.movableDistanceInCurrentPhase;
            }
            private set
            {
                this.movableDistanceInCurrentPhase = value > 0 ? value : 0;
                this.OnChangedStatus(EventArgs.Empty);
            }
        }

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

        #endregion

        #region メソッド

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
            this.name = name;
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
            this.MovableDistanceInCurrentPhase += -1;
        }


        /// <summary>
        /// ダメージを受ける
        /// </summary>
        /// <param name="damage">ダメージ</param>
        internal void TakeDamage(int damage)
        {
            this.Headcount -= damage;
        }

        /// <summary>
        /// 移動フェーズ開始
        /// </summary>
        internal void OnStartMovePhase()
        {
            this.MovableDistanceInCurrentPhase = this.mobilePower;
        }

        /// <summary>
        /// 移動フェーズ終了
        /// </summary>
        internal void OnFinishMovePhase()
        {
            this.MovableDistanceInCurrentPhase = 0;
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
            return this.name;
        }

        #endregion
    }
}
