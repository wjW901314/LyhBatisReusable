using System.Collections.Generic;

namespace Lyh.Libs.Arithmetic
{
    /// <summary>
    /// 使用非递归的方式计算斐波拉契数列。
    /// </summary>
    public class PhabeNonRecursion
    {
        //静态列表，用以存储己经计算得到的数列
        private static List<long> phabe;

        /// <summary>
        /// 构造方法。
        /// </summary>
        static PhabeNonRecursion()
        {
            //初始化数列，在一开始使该数列只包含2个元素
            phabe = new List<long>();
            phabe.Add(1);
            phabe.Add(1);
        }

        /// <summary>
        /// 在已经得到的计算结果上，进一步计算斐波拉契数列。
        /// </summary>
        /// <param name="index">计算到第index个元素</param>
        private static void Update(int index)
        {
            //循环计算，直至得到第index个元素
            while (phabe.Count <= index)
            {
                int count = phabe.Count;
                //利用斐波拉契数列的定义进行计算
                long temp = phabe[count - 1] + phabe[count - 2];
                phabe.Add(temp);
            }
        }

        /// <summary>
        /// 获得第index个元素，下标从0开始。
        /// </summary>
        /// <param name="index">下标</param>
        /// <returns>下标为index的元素</returns>
        public static long GetNumber(int index)
        {
            //如果该元素己经在以前被计算，则直接从内存中读取
            //否则则需要延长内存中的斐波拉契数列
            if (phabe.Count <= index)
            {
                Update(index);
            }
            return phabe[index];
        }
    }
}