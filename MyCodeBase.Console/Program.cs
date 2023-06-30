using StackExchange.Redis;

using System;
using System.Collections.Specialized;
using System.Configuration;

// 建立 reids 連線
ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
// 也可以一次連多個
//ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("server1:6379,server2:6379");
//string config = redis.Configuration;

// 獲取 Redis 資料庫 
var db = redis.GetDatabase();

// 通過db使用Redis API （http://redis.io/commands）
db.StringSet("mykey", "myvalue", new TimeSpan(0, 10, 0), When.Always, CommandFlags.None);
// 創建連接到特定服務的 PUB/SUB 連接
ISubscriber sub = redis.GetSubscriber();
// 訂閱頻道，並處於監聽狀態，接受消息並處理
var result = string.Empty;
sub.Subscribe("messages", (channel, message) =>
{
    result = string.Format("Channel:{0} ; Message:{1} .", channel.ToString(), message);
});
// 在另一個進程或是機器上，發佈消息
sub.Publish("messages", "hello");

// 用 Key 找 Redis 內資料 
var findKey = "mykey";
var printKey = db.KeyExists(findKey)
    ? db.KeyExists(findKey).ToString() + ": " + db.StringGet(findKey)
    : findKey + " is not exist!";
Console.WriteLine(printKey);
// 寫入資料
var Key = "myKey";
var _lockKey = $"{"LockKey"}{Key}";
if (!db.KeyExists(_lockKey))
{
    // 透過多寫一個key來表示在寫入中
    db.StringSet(_lockKey, true.ToString());
    db.StringSet(Key, "改寫後的");
    // 移除標示用Key
    db.KeyDelete(_lockKey);
}
Console.WriteLine(Key + ": " + db.StringGet(Key));
