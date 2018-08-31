using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Lyh.Libs.MyConverter
{
    /// <summary>
    /// Author：lyh
    /// Description：数据转换类
    /// Date：2013-07-16
    /// </summary>
    public class DataConverter
    {
        public static int TryConvertToInt(object obj)
        {
            int number;
            string value = (obj == null || obj == DBNull.Value) ? string.Empty : obj.ToString();
            bool result = Int32.TryParse(value, out number);
            return number;
        }

        public static DateTime TryConvertToDateTime(object obj)
        {
            DateTime dt;
            string value = (obj == null || obj == DBNull.Value) ? string.Empty : obj.ToString();
            bool result = DateTime.TryParse(value, out dt);
            return dt;
        }

        public static T TryConvertToEnum<T>(object obj) where T : struct
        {
            T t;
            string value = (obj == null || obj == DBNull.Value) ? string.Empty : obj.ToString();
            Enum.TryParse<T>(value, true, out t);
            if (Enum.IsDefined(typeof(T), t))
            {
                return t;
            }
            else
            {
                return new T();
            }
        }

        /// <summary>
        /// 实体类集合转换为数据表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entities">实体类集合</param>
        /// <returns>DataTable</returns>
        public static DataTable ListToDataTable<T>(IList<T> entities)
        {
            //检查实体集合不能为空
            if (entities == null || entities.Count < 1)
            {
                throw new Exception("需转换的集合为空");
            }
            //取出第一个实体的所有属性
            var type = entities[0].GetType();
            var properties = type.GetProperties();

            //生成DataTable的structure
            //生产代码中，应将生成的DataTable结构Cache起来，此处略
            var dt = new DataTable();
            foreach (var t in properties)
            {
                dt.Columns.Add(t.Name);
            }
            //将所有entity添加到DataTable中
            foreach (object entity in entities)
            {
                //检查所有的的实体都为同一类型
                if (entity.GetType() != type)
                {
                    throw new Exception("要转换的集合元素类型不一致");
                }
                var values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity, null);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }

        /// <summary>
        /// 把表转换为对应的实体类
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="table">表</param>
        /// <returns>列表</returns>
        public static IList<T> TableToEntity<T>(DataTable table) where T : class, new()
        {
            Type type = typeof(T);
            IList<T> list = new List<T>();

            foreach (DataRow row in table.Rows)
            {
                PropertyInfo[] properties = type.GetProperties();
                T entity = new T();
                foreach (PropertyInfo p in properties)
                {
                    p.SetValue(entity, row[p.Name], null);
                }
                list.Add(entity);
            }
            return list;
        }
    }
}