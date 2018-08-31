using System;

namespace Lyh.Libs.Arithmetic
{
    /// <summary>
    /// 使用递归的方式计算斐波拉契数列。
    /// </summary>
    public class PhabeWithRecursion
    {
        /// <summary>
        /// 获得第index个元素，下标从0开始。
        /// </summary>
        /// <param name="index">下标</param>
        /// <returns>下标为index的元素</returns>
        public static long GetNumber(int index)
        {
            if (index < 0)
            {
                throw new Exception("索引超出范围。必须为非负值。\n参数名：index");
            }
            else if (index == 0 || index == 1)
            {
                return 1;
            }
            else
            {
                //利用斐波拉契数列的定义进行计算
                return GetNumber(index - 1) + GetNumber(index - 2);
            }
        }
    }
}
