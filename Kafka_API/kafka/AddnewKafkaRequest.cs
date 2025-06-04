using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafka_API
{
    public class AddnewKafkaRequest
    {
        public string BootstrapServers { set; get; } //= "192.168.101.189:9092";
        public string Topic { set; get; }// = "test-opcUA";
        public string Message { set; get; } 
    }
}
