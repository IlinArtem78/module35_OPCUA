using Confluent.Kafka;

namespace Kafka_API;

public class WorkWithKafka
{
    // Настройки подключения
    public string? jsonToOPC { set; get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="BootstrapServers"></param>
    /// <param name="Topic"></param>
    /// <returns></returns>
    public async Task ProduceMessagesAsync(string BootstrapServers, string Topic, string Message)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        using (var producer = new ProducerBuilder<Null, string>(new ProducerConfig
        {
            BootstrapServers = BootstrapServers

        }).Build())
        {
            try
            {
                var message = new Message<Null, string>
                {
                    Value = Message
                };

                var result = await producer.ProduceAsync(Topic, message);
                Console.WriteLine($"Сообщение отправлено: {result.TopicPartitionOffset}");
                producer.Flush(TimeSpan.FromSeconds(10));
                producer.Dispose();
            }
            catch (ProduceException<string, string> e)
            {
                Console.WriteLine($"Ошибка при отправке: {e.Error.Reason}");
            }
        }
    }

    /// <summary>
    /// Получение данных из Кафки
    /// </summary>
    /// <returns></returns>
    public async Task ConsumeMessagesAsync(string BootstrapServers, string Topic)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = BootstrapServers,
            GroupId = "test_group",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
        {
            consumer.Subscribe(Topic);
        
            try
            {
               for(int i = 0; i<100; i++)
               {
                    var consumeResult = consumer.Consume(TimeSpan.FromSeconds(10));
                    if (consumeResult != null)
                    {
                        Console.WriteLine($"Received message: {consumeResult.Message.Value}");
                        jsonToOPC = consumeResult.Message.Value;
                    }
                    else
                    {
                        Console.WriteLine("No message received within the timeout period.");
                      //  jsonToOPC = "No message received within the timeout period.";
                        break;
                    }
                    
               }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
               
            }
            finally
            {
                consumer.Close();
            }
        }
    }
}
