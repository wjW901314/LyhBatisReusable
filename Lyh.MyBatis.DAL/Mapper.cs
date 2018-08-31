using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;

namespace Lyh.MyBatis.DAL
{
    /// <summary>
    /// Author：lyh
    /// Description：SqlMapper Singleton
    /// Date：2013-11-03
    /// </summary>
    public class Mapper
    {
        private static readonly ISqlMapper instance;
        /// <summary>
        /// SqlMapper 实例
        /// </summary>
        public static ISqlMapper Instance
        {
            get
            {
                return instance;
            }
        }

        private Mapper()
        {
        }

        static Mapper()
        {
            var builder = new DomSqlMapBuilder();
            instance = builder.Configure();
        }
    }
}