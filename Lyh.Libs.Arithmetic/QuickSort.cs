namespace Lyh.Libs.Arithmetic
{
    /// <summary>
    /// 快速排序。
    /// </summary>
    public class QuickSort
    {
        /// <summary>
        /// 快速排序算法。
        /// </summary>
        /// <param name="data">排序数组</param>
        /// <param name="low">排序下限</param>
        /// <param name="high">排序上限</param>
        public static void Sort(ref int[] data, int low, int high)
        {
            //简单设定中间值， 并以此为一趟快排的分割点
            //注意这里是一个简单的算法
            //如果想对这个算法进行优化的话， 可以采取随机的方法来获取分割点
            int middle = data[(low + high) / 2];
            //设定移动上下标
            int i = low;
            int j = high;
            //直至分割出两个序列
            do
            {
                //扫描中值左边元素
                while (data[i] < middle && i < high)
                    i++;
                //扫描中值右边元素
                while (data[j] > middle && j > low)
                    j--;
                //找到了一对可交换的值
                if (i <= j)
                {
                    //交换
                    int temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);
            //递归对比分割点元素都小的那个序列进行快速排序
            if (j > low)
                Sort(ref data, low, j);
            //递归对比分割点元素都大的那个序列进行快速排序
            if (i < high)
                Sort(ref data, i, high);
        }
    }
}