using System;
using System.Collections.Generic;

namespace Lyh.Libs.Arithmetic
{
    /// <summary>
    /// N皇后问题。
    /// </summary>
    public class Queens
    {
        //棋盘列表，每一项代表一个解的棋盘
        private List<int[,]> chessBoard;

        //维度
        private int dimension;
        /// <summary>
        /// 只读属性，返回维度。
        /// </summary>
        public int Dimension
        {
            get { return dimension; }
            set { dimension = value; }
        }

        /// <summary>
        /// 根据索引取得一个解的棋盘。
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns>一个解的棋盘（int[,]）</returns>
        public int[,] this[int index]
        {
            get
            {
                return GetChessBoard(index);
            }
        }

        /// <summary>
        /// 根据索引取得一个解的棋盘。
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns>一个解的棋盘（int[,]）</returns>
        public int[,] GetChessBoard(int index)
        {
            if (index >= chessBoard.Count || index < 0)
                return null;
            else
                return chessBoard[index];
        }

        /// <summary>
        /// 获取解的数量。
        /// </summary>
        public int Count
        {
            get
            {
                return chessBoard.Count;
            }
        }

        /// <summary>
        /// 不允许默认的公共构造方法。
        /// </summary>
        private Queens()
        {
        }

        /// <summary>
        /// 构造方法，需要提供维度来构造。
        /// </summary>
        /// <param name="n">维度</param>
        public Queens(int n)
        {
            //初始化解
            chessBoard = new List<int[,]>(n);
            //存储维度
            dimension = n;
            //计算并得到所有解
            Calculate();
        }

        /// <summary>
        /// 算法入口。
        /// </summary>
        private void Calculate()
        {
            //初始化一个棋盘
            int[] board = new int[dimension];
            //循环摆放N个皇后，直至第一皇后也需要回溯
            for (int row = 0; row < dimension && row >= 0; )
            {
                //是否需要回溯的标志
                bool found = false;
                for (int column = board[row]; column < dimension; column++)
                {
                    //检查是否有冲突
                    if (!IsConflict(row, board, column))
                    {
                        //表示没有冲突，实际摆放当前皇后
                        board[row] = column;
                        //如何当前摆放的是最后一个皇后，则表明己经找到一个解
                        if (row == (dimension - 1))
                        {
                            //复制当前棋盘并且存储这个解
                            int[,] result = new int[dimension, dimension];
                            for (int i = 0; i < dimension; i++)
                            {
                                //1-代表可以放一个皇后
                                result[i, board[i]] = 1;
                            }
                            chessBoard.Add(result);
                            //一个解得到后，就需要回溯来寻找下一个解
                            found = false;
                        }
                        else
                        {
                            //不需要回溯
                            found = true;
                        }
                        break;
                    }
                }
                if (found)
                {
                    row++;
                }
                else
                {
                    //这里回溯，复位当前皇后
                    board[row] = 0;
                    //回溯到上一个皇后
                    row--;
                    if (row >= 0)
                        board[row]++;
                }
            }
        }

        /// <summary>
        ///  检查当前摆放是否有冲突。
        /// </summary>
        /// <param name="row">当前尝试摆放的行数</param>
        /// <param name="board">当前棋盘</param>
        /// <param name="column">当前尝试摆放的列数</param>
        /// <returns>bool</returns>
        private bool IsConflict(int row, int[] board, int column)
        {
            for (int i = 0; i < row; i++)
            {
                if (column == board[i] || (row - i) == Math.Abs(board[i] - column))
                    return true;
            }
            return false;
        }
    }
}
