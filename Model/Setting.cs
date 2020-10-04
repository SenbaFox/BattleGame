using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Model
{
    /// <summary>
    /// 設定
    /// </summary>
    public class Setting
    {
        #region メンバ変数

        /// <summary>
        /// 地形配列
        /// </summary>
        private readonly Geography[] geographies = new Geography[]
        {
            new Geography(0, true),    // 平地
            new Geography(1, false),   // 山
            new Geography(2, false),   // 川、海
            new Geography(3, true)   // 浅瀬
        };

        private readonly Dictionary<int, Branch> branches = new Dictionary<int, Branch>
        {
            { 0, Branch.歩兵 },
            { 1, Branch.騎兵 }
        };

        #endregion

        #region メソッド

        /// <summary>
        /// ロードする
        /// </summary>
        /// <param name="oField">戦場</param>
        /// <param name="oArmies">両軍</param>
        public void Load(out Field oField, out Army[] oArmies)
        {
            oField = null;
            oArmies = null;

            const string PATH = @"Assets\Setting.json";
            if (File.Exists(PATH) == false)
            {
                throw new Exception(PATH + "が存在しません。");
            }
            JObject setting = JObject.Parse(File.ReadAllText(PATH));

            oField = this.CreateField(setting);
            oArmies = this.CreateArmies(setting, oField);
        }

        #region 戦場オブジェクト生成

        private Field CreateField(JObject setting)
        {
            List<Hex[]> hexLines = new List<Hex[]>();
            foreach (var line in setting["Field"])
            {
                Hex[] hexLine = line.Values<int>().Select(id => this.CreateHex(id)).ToArray();
                hexLines.Add(hexLine);
            }

            return new Field(hexLines.ToArray());
        }

        private Hex CreateHex(int geographyID)
        {
            Geography geography = this.geographies.Where(geo => geo.ID == geographyID).FirstOrDefault();
            if (geography == null)
            {
                throw new Exception($"Fieldの設定に未対応の地形ID:{geographyID}が含まれています。");
            }

            return new Hex(geography);
        }

        #endregion

        #region 軍オブジェクト生成

        private Army[] CreateArmies(JObject setting, Field field)
        {
            List<Army> armies = new List<Army>();
            foreach (var armySetting in setting["Armies"])
            {
                int armyID = armies.Count;
                Army army = this.CreateArmy(armySetting, armyID, field);

                armies.Add(army);
            }

            if (armies.Count != 2)
            {
                throw new Exception("Armiesには2つ設定してください。");
            }

            return armies.ToArray();
        }

        private Army CreateArmy(JToken armySetting, int armyID, Field field)
        {
            string armyName = armySetting["Name"].ToString();
            Army army = new Army(armyID, armyName);

            army.Units = armySetting["Units"].Select(setting => this.CreateUnit(setting, army, field)).ToArray();

            if (army.Units.Length == 0)
            {
                throw new Exception($"{army}に部隊が1つも設定されていません。");
            }

            return army;
        }

        private Unit CreateUnit(JToken unitSetting, Army army, Field field)
        {
            string unitName = unitSetting["Name"].ToString();
            int branchID = (int)unitSetting["Branch"];
            int mobilePower = (int)unitSetting["MobilePower"];
            int headcount = (int)unitSetting["Headcount"];

            if (this.branches.ContainsKey(branchID) == false)
            {
                throw new Exception($"Unitsの設定に未対応の兵科ID:{branchID}が含まれています。");
            }

            if (mobilePower <= 0)
            {
                throw new Exception("Unitsの設定にmobilePowerが0以下のUnitが含まれています。");
            }

            if (headcount <= 0)
            {
                throw new Exception("Unitsの設定にheadcountが0以下のUnitが含まれています。");
            }

            Unit unit = new Unit(army, unitName, this.branches[branchID], mobilePower, headcount);

            var location = unitSetting["Location"];
            int x = (int)location[0];
            int y = (int)location[1];
            field.SetUnit(unit, x, y);

            return unit;
        }

        #endregion

        #endregion
    }
}
