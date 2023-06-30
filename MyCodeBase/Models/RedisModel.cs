using StackExchange.Redis;

using System;
using System.Collections.Specialized;
using System.Configuration;

namespace MyCodeBase.Models
{
    public class RedisModel
    {

        private void test1()
        {
            // 建立 reids 連線
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            // 也可以一次連多個
            //ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("server1:6379,server2:6379");
            //string config = redis.Configuration;

            // 獲取 Redis 資料庫 
            IDatabase db = redis.GetDatabase();

            // 通過db使用Redis API （http://redis.io/commands）
            db.StringSet("mykey", "myvalue", new TimeSpan(0, 10, 0), When.Always, CommandFlags.None);
            string value = string.Empty;
            if (db.KeyExists("mykey"))
            {
                value = db.StringGet("mykey");
            }
        }

        private void test2()
        {
            //step-1: 設置Redis鏈接
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");

            //step-2: 創建連接到特定服務的 PUB/SUB 連接
            ISubscriber sub = redis.GetSubscriber();

            //step-3: 訂閱頻道，並處於監聽狀態，接受消息並處理
            string result = string.Empty;
            sub.Subscribe("messages", (channel, message) =>
            {
                result = string.Format("Channel:{0} ; Message:{1} .", channel.ToString(), message);
            });
        }

        private void test3()
        {
            //step-1: 設置Redis鏈接
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");

            //step-2: 創建連接到特定服務的 PUB/SUB 連接
            ISubscriber sub = redis.GetSubscriber();

            //step-3: 在另一個進程或是機器上，發佈消息
            sub.Publish("messages", "hello");
        }
    }
}