using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace III.文件监控
{
    public class RedisMQHelper
    {


        /// <summary>
        /// 连接字符串
        /// </summary>
        private static readonly string ConnectionString;
        /// <summary>
        /// redis 连接对象
        /// </summary>
        private static IConnectionMultiplexer _connMultiplexer;
        /// <summary>
        /// 默认的key值（用来当作RedisKey的前缀）【此部分为自行修改的，无意义】
        /// </summary>
        public static string DefaultKey { get; private set; }
        /// <summary>
        /// 锁
        /// </summary>
        private static readonly object Locker = new object();
        /// <summary>
        /// 数据库访问对象
        /// </summary>
        private readonly IDatabase _db;
        /// <summary>
        /// 采用双重锁单例模式，保证数据访问对象有且仅有一个
        /// </summary>
        /// <returns></returns>
        public IConnectionMultiplexer GetConnectionRedisMultiplexer()
        {
            if ((_connMultiplexer == null || !_connMultiplexer.IsConnected))
            {
                lock (Locker)
                {
                    if ((_connMultiplexer == null || !_connMultiplexer.IsConnected))
                    {
                        _connMultiplexer = ConnectionMultiplexer.Connect(ConnectionString);
                    }
                }
            }
            return _connMultiplexer;
        }
        /// <summary>
        /// 添加事务处理
        /// </summary>
        /// <returns></returns>
        public ITransaction GetTransaction()
        {
            //创建事务
            return _db.CreateTransaction();
        }
        /// <summary>
        /// 静态的构造函数,
        /// 构造函数是属于类的，而不是属于实例的
        /// 就是说这个构造函数只会被执行一次。也就是在创建第一个实例或引用任何静态成员之前，由.NET自动调用。
        /// </summary>
        static RedisMQHelper()
        {
            ConnectionString = "127.0.0.1:6379,allowadmin=true";// ConfigurationManager.ConnectionStrings["RedisConnectionString"].ConnectionString;
            _connMultiplexer = ConnectionMultiplexer.Connect(ConnectionString);
            // DefaultKey = ConfigurationManager.AppSettings["Redis.DefaultKey"];
            RegisterEvent();
        }
        /// <summary>
        /// 重载构造器
        /// </summary>
        /// <param name="db"></param>
        public RedisMQHelper(int db = -1)
        {
            _db = _connMultiplexer.GetDatabase(db);
        }


        /// <summary>
        /// 添加 key 的前缀
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string AddKeyPrefix(string key)
        {
            return $"{DefaultKey}:{key}";
        }


        /// <summary>
        /// 移除并返回key所对应列表的第一个元素
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public string ListLeftPop(string redisKey)
        {
            redisKey = AddKeyPrefix(redisKey);
            return _db.ListLeftPop(redisKey);
        }
        /// <summary>
        /// 移除并返回key所对应列表的最后一个元素
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public string ListRightPop(string redisKey)
        {
            redisKey = AddKeyPrefix(redisKey);
            return _db.ListRightPop(redisKey);
        }
        /// <summary>
        /// 移除指定key及key所对应的元素
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="redisValue"></param>
        /// <returns></returns>
        public long ListRemove(string redisKey, string redisValue)
        {
            redisKey = AddKeyPrefix(redisKey);
            return _db.ListRemove(redisKey, redisValue);
        }
        /// <summary>
        /// 在列表尾部插入值，如果键不存在，先创建再插入值
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="redisValue"></param>
        /// <returns></returns>
        public long ListRightPush(string redisKey, string redisValue)
        {
            redisKey = AddKeyPrefix(redisKey);
            return _db.ListRightPush(redisKey, redisValue);
        }
        /// <summary>
        /// 在列表头部插入值，如果键不存在，先创建再插入值
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="redisValue"></param>
        /// <returns></returns>
        public long ListLeftPush(string redisKey, string redisValue)
        {
            redisKey = AddKeyPrefix(redisKey);
            return _db.ListLeftPush(redisKey, redisValue);
        }
        /// <summary>
        /// 返回列表上该键的长度，如果不存在，返回0
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public long ListLength(string redisKey)
        {
            redisKey = AddKeyPrefix(redisKey);
            return _db.ListLength(redisKey);
        }
        /// <summary>
        /// 返回在该列表上键所对应的元素
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public IEnumerable<RedisValue> ListRange(string redisKey)
        {
            try
            {
                redisKey = AddKeyPrefix(redisKey);
                return _db.ListRange(redisKey);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 注册事件
        /// </summary>
        private static void RegisterEvent()
        {
            _connMultiplexer.ConnectionRestored += ConnMultiplexer_ConnectionRestored;
            _connMultiplexer.ConnectionFailed += ConnMultiplexer_ConnectionFailed;
            _connMultiplexer.ErrorMessage += ConnMultiplexer_ErrorMessage;
            _connMultiplexer.ConfigurationChanged += ConnMultiplexer_ConfigurationChanged;
            _connMultiplexer.HashSlotMoved += ConnMultiplexer_HashSlotMoved;
            _connMultiplexer.InternalError += ConnMultiplexer_InternalError;
            _connMultiplexer.ConfigurationChangedBroadcast += ConnMultiplexer_ConfigurationChangedBroadcast;
        }

        /// <summary>
        /// 重新配置广播时(主从同步更改)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ConnMultiplexer_ConfigurationChangedBroadcast(object sender, EndPointEventArgs e)
        {
            Console.WriteLine($"{nameof(ConnMultiplexer_ConfigurationChangedBroadcast)}: {e.EndPoint}");
        }
        /// <summary>
        /// 发生内部错误时(调试用)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ConnMultiplexer_InternalError(object sender, InternalErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(ConnMultiplexer_InternalError)}: {e.Exception}");
        }
        /// <summary>
        /// 更改集群时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ConnMultiplexer_HashSlotMoved(object sender, HashSlotMovedEventArgs e)
        {
            Console.WriteLine($"{nameof(ConnMultiplexer_HashSlotMoved)}: {nameof(e.OldEndPoint)}-{e.OldEndPoint} To {nameof(e.NewEndPoint)}-{e.NewEndPoint} ");
        }
        /// <summary>
        /// 配置更改时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ConnMultiplexer_ConfigurationChanged(object sender, EndPointEventArgs e)
        {
            Console.WriteLine($"{nameof(ConnMultiplexer_ConfigurationChanged)}: {e.EndPoint}");
        }
        /// <summary>
        /// 发生错误时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ConnMultiplexer_ErrorMessage(object sender, RedisErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(ConnMultiplexer_ErrorMessage)}: {e.Message}");
        }
        /// <summary>
        /// 物理连接失败时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ConnMultiplexer_ConnectionFailed(object sender, ConnectionFailedEventArgs e)
        {
            Console.WriteLine($"{nameof(ConnMultiplexer_ConnectionFailed)}: {e.Exception}");
        }
        /// <summary>
        /// 建立物理连接时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ConnMultiplexer_ConnectionRestored(object sender, ConnectionFailedEventArgs e)
        {
            Console.WriteLine($"{nameof(ConnMultiplexer_ConnectionRestored)}: {e.Exception}");
        }
    }
}