using System;
using System.Linq;

namespace Model
{
    /// <summary>
    /// 戦場
    /// </summary>
    public class Field
    {
        /// <summary>
        /// へクスの2次元配列
        /// </summary>
        public Hex[][] Hexes { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="hexes">へクスの2次元配列</param>
        internal Field(Hex[][] hexes)
        {
            this.Hexes = hexes;
        }

        /// <summary>
        /// 部隊を配置
        /// </summary>
        /// <param name="unit">部隊</param>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
        internal void SetUnit(Unit unit, int x, int y)
        {
            this.SetUnit(unit, this.Hexes[x][y]);
        }

        /// <summary>
        /// 部隊を配置
        /// </summary>
        /// <param name="unit">部隊</param>
        /// <param name="hex">へクス</param>
        internal void SetUnit(Unit unit, Hex hex)
        {
            // TODO: チェック追加
            if(unit.CurrentHex != null)
            {
                unit.CurrentHex.TakeOff();
            }
            hex.OnLanded(unit);
            unit.Move(hex);
        }

        /// <summary>
        /// 2つのへクスが隣り合っているか
        /// </summary>
        /// <param name="hex1">へクス1</param>
        /// <param name="hex2">へクス2</param>
        /// <returns>隣り合っているか</returns>
        internal bool AreLayingSideBySide(Hex hex1, Hex hex2)
        {
            int[] hex1Index = this.GetIndex(hex1);
            int[] hex2Index = this.GetIndex(hex2);

            int xDelta = Math.Abs(hex1Index[0] - hex2Index[0]);
            int yDelta = Math.Abs(hex1Index[1] - hex2Index[1]);

            if (yDelta == 0)
            {
                // 同じへクスは隣り合ってるとみなさない
                return (xDelta == 1);
            }

            if (yDelta == 1)
            {
                if (hex1Index[1] % 2 == 0)
                {
                    return ((xDelta == 0) || (hex2Index[0] == (hex1Index[0] - 1)));
                }
                else
                {
                    return ((xDelta == 0) || (hex2Index[0] == (hex1Index[0] + 1)));
                }
            }

            return false;
        }

        private int[] GetIndex(Hex hex)
        {
            int y = this.Hexes
                .Select((line, i) => new { Line = line, Index = i })
                .Where(lineWithIndex => lineWithIndex.Line.Contains(hex))
                .Select(lineWithIndex => lineWithIndex.Index)
                .First();

            int x = this.Hexes[y]
                .Select((value, i) => new { Value = value, Index = i })
                .Where(hexWithIndex => hexWithIndex.Value == hex)
                .Select(hexWithIndex => hexWithIndex.Index)
                .First();

            return new int[]{ x, y };
        }
    }
}
