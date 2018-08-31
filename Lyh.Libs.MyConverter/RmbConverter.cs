using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lyh.Libs.MyConverter
{
    /// <summary>
    /// Author：lyh
    /// Description：RMB（人民币）操作类
    /// Date：2013-07-16
    /// </summary>
    public class RmbConverter
    {
        /// <summary>
        /// 把数字形式的金额转换为大写形式的金额。
        /// </summary>
        /// <param name="money">数字形式的金额</param>
        /// <returns>大写形式的金额</returns>
        public static string ToUpper(decimal money)
        {
            //0-9所对应的汉字
            string str1 = "零壹贰叁肆伍陆柒捌玖";
            //数字位所对应的汉字 
            string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分";
            //从原num值中取出的值
            string str3 = "";
            //数字的字符串形式
            string str4 = "";
            //人民币大写金额形式 
            string str5 = "";
            //循环变量
            int i;
            //num的值乘以100的字符串长度
            int j;
            //数字的汉语读法
            string ch1 = "";
            //数字位的汉字读法 
            string ch2 = "";
            //用来计算连续的零值是几个
            int nzero = 0;
            //从原num值中取出的值
            int temp;

            //将num取绝对值并四舍五入取2位小数
            money = Math.Round(Math.Abs(money), 2);
            //将num乘100并转换成字符串形式
            str4 = ((long)(money * 100)).ToString();
            //找出最高位
            j = str4.Length;
            if (j > 15)
            {
                return "溢出";
            }
            //取出对应位数的str2的值。如：200.55,j为5所以str2=佰拾元角分
            str2 = str2.Substring(15 - j);

            //循环取出每一位需要转换的值 
            for (i = 0; i < j; i++)
            {
                //取出需转换的某一位的值 
                str3 = str4.Substring(i, 1);
                //转换为数字
                temp = Convert.ToInt32(str3);
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                    //当所取位数不为元、万、亿、万亿上的数字时 
                    if (str3 == "0")
                    {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (str3 != "0" && nzero != 0)
                        {
                            ch1 = "零" + str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                    //该位是万亿，亿，万，元位等关键位 
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 != "0" && nzero == 0)
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (str3 == "0" && nzero >= 3)
                            {
                                ch1 = "";
                                ch2 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (j >= 11)
                                {
                                    ch1 = "";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = "";
                                    ch2 = str2.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (j - 11) || i == (j - 3))
                {
                    //如果该位是亿位或元位，则必须写上 
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;

                if (i == j - 1 && str3 == "0")
                {
                    //最后一位（分）为0时，加上“整” 
                    str5 = str5 + '整';
                }
            }
            if (money == 0)
            {
                str5 = "零元整";
            }
            return str5;
        }

        /// <summary>
        /// 把数字形式的金额转换为大写形式的金额。
        /// </summary>
        /// <param name="money">数字形式的金额</param>
        /// <returns>大写形式的金额</returns>
        public static string ToUpper(string money)
        {
            try
            {
                decimal num = Convert.ToDecimal(money);
                return ToUpper(num);
            }
            catch
            {
                return "非数字形式！";
            }
        }
    }
}