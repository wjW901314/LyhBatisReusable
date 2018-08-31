using System;

namespace Lyh.Libs.Arithmetic
{
    /// <summary>
    /// 汉诺塔。
    /// </summary>
    public class Hanoi
    {
        /// <summary>
        /// 总共挪动的次数。
        /// </summary>
        private static int count = 0;

        /// <summary>
        /// 移动。
        /// </summary>
        /// <param name="n">盘号</param>
        /// <param name="x">塔x</param>
        /// <param name="y">塔y</param>
        private static void Move(int n, char x, char y)
        {
            count++;
            Console.WriteLine("把{0}号从{1}挪动到{2}", n, x, y);
        }

        /// <summary>
        /// 汉诺塔算法。
        /// </summary>
        /// <param name="n">汉诺塔的层数</param>
        /// <param name="a">塔a</param>
        /// <param name="b">塔b</param>
        /// <param name="c">塔c</param>
        /// <returns>总共挪动的次数</returns>
        public static int Run(int n, char a, char b, char c)
        {
            if (n == 1)
            {
                Move(1, a, c);
            }
            else
            {
                //⑴将塔A上的n-1个碟子借助塔C先移到塔B上。
                Run(n - 1, a, c, b);
                //⑵把塔A上剩下的一个碟子移到塔C上。
                Move(n, a, c);
                //⑶将n-1个碟子从塔B借助塔A移到塔C上。
                Run(n - 1, b, a, c);
            }
            return count;
        }
    }
}