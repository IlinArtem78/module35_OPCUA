using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kafka_API
{
    public interface IKafkaAction
    {
       Task AddNewMess(AddnewKafkaRequest request);
       Task GetAllMessages(GetKafkaRespone respone);
       public string jsonToOPC { get; }
      
    }
}
