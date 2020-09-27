using Newtonsoft.Json.Linq;
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
        /// <summary>
        /// ロードする
        /// </summary>
        /// <param name="oField">戦場</param>
        /// <param name="oArmies">両軍</param>
        /// <param name="oErrMsg">エラーメッセージ</param>
        /// <returns></returns>
        public bool TryLoad(out Field oField, out Army[] oArmies, out string oErrMsg)
        {
            oField = null;
            oArmies = null;

            const string PATH = @"Setting.json";
            if (File.Exists(PATH) == false)
            {
                oErrMsg = PATH + "が存在しません。";
                return false;
            }
            JObject setting = JObject.Parse(File.ReadAllText(PATH));

            if (this.TryCreateField(setting, out oField, out oErrMsg) == false)
            {
                return false;
            }

            if (this.TryCreateArmies(setting, oField, out oArmies, out oErrMsg) == false)
            {
                return false;
            }

            return true;
        }

        private bool TryCreateField(JObject setting, out Field oField, out string oErrMsg)
        {
            oField = null;
            oErrMsg = string.Empty;

            List<Geography> geographies = new List<Geography>();
            geographies.Add(new Geography(0, true));    // 平地
            geographies.Add(new Geography(1, false));   // 海

            List<Hex[]> hexLines = new List<Hex[]>();
            foreach (var line in setting["Field"])
            {
                List<Hex> hexLine = new List<Hex>();
                foreach (int geographyID in line)
                {
                    Geography geography = geographies.Where(geo => geo.ID == geographyID).FirstOrDefault();
                    if (geography == null)
                    {
                        oErrMsg = "Fieldの設定に未対応の地形ID:" + geographyID.ToString() + "が含まれています。";
                        return false;
                    }
                    hexLine.Add(new Hex(geography));
                }
                hexLines.Add(hexLine.ToArray());
            }
            oField = new Field(hexLines.ToArray());
            return true;
        }

        private bool TryCreateArmies(JObject setting, Field field, out Army[] oArmies, out string oErrMsg)
        {
            oArmies = null;
            oErrMsg = string.Empty;

            Dictionary<int, Branch> branches = new Dictionary<int, Branch>();
            branches.Add(0, Branch.歩兵);
            branches.Add(1, Branch.騎兵);

            List<Army> armies = new List<Army>();
            foreach (var armySetting in setting["Armies"])
            {
                int armyID = armies.Count;
                string armyName = armySetting["Name"].ToString();
                Army army = new Army(armyID, armyName);
                armies.Add(army);

                List<Unit> units = new List<Unit>();
                foreach (var unitSetting in armySetting["Units"])
                {
                    string unitName = unitSetting["Name"].ToString();
                    int branchID = (int)unitSetting["Branch"];
                    int mobilePower = (int)unitSetting["MobilePower"];
                    int headcount = (int)unitSetting["Headcount"];

                    if (branches.ContainsKey(branchID) == false)
                    {
                        oErrMsg = "Unitsの設定に未対応の兵科ID:" + branchID.ToString() + "が含まれています。";
                        return false;
                    }

                    Unit unit = new Unit(army, unitName, branches[branchID], mobilePower, headcount);

                    units.Add(unit);

                    var location = unitSetting["Location"];
                    int x = (int)location[0];
                    int y = (int)location[1];
                    field.SetUnit(unit, x, y);
                }

                army.Units = units.ToArray();
            }

            if (armies.Count != 2)
            {
                oErrMsg = "Armiesには2つ設定してください。";
                return false;
            }

            oArmies = armies.ToArray();
            return true;
        }
    }
}
