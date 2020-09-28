using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Model
{
    /// <summary>
    /// ロガー
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        private static readonly Logger instance = new Logger();

        /// <summary>
        /// 書き出しオブジェクト
        /// </summary>
        private readonly StreamWriter writer = null;

        #region メソッド

        /// <summary>
        /// インスタンスを取得する
        /// </summary>
        /// <returns>ロガー</returns>
        public static Logger GetInstance()
        {
            return instance;
        }

        private Logger()
        {
            this.writer = new StreamWriter("log.txt", true)
            {
                AutoFlush = true
            };
        }

        /// <summary>
        /// 書き込む
        /// </summary>
        /// <param name="text">文字列</param>
        public void Write(string text)
        {
            string dateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
            string log = $"{dateTime}: {text}";
            this.writer.WriteLine(log);
        }

        #endregion
    }
}
