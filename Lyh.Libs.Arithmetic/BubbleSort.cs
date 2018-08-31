namespace Lyh.Libs.Arithmetic
{
    /// <summary>
    /// 冒泡排序。
    /// </summary>
    public class BubbleSort
    {
        /// <summary>
        /// 冒泡排序算法。
        /// </summary>
        /// <param name="data">排序数组</param>
        public static void Sort(ref int[] data)
        {
            //外层循环从（0）到（数组长度-2）
            for (int i = 0; i < data.Length - 1; i++)
            {
                //外层循环从（1）到（数组长度-1）
                for (int j = i + 1; j < data.Length; j++)
                {
                    //找到了一对可交换的值
                    if (data[i] > data[j])
                    {
                        //交换
                        int temp = data[i];
                        data[i] = data[j];
                        data[j] = temp;
                    }
                }
            }
        }
    }
}