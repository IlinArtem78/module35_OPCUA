using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafka_API.Repositories
{
    public class KafkaRepositoria : IKafkaAction
    { 
        private WorkWithKafka _workWithKafka; 

        public KafkaRepositoria(WorkWithKafka workWithKafka)
        {
            _workWithKafka = workWithKafka;
        }

        

        string IKafkaAction.jsonToOPC
        {
            get => _workWithKafka.jsonToOPC;
            
        }
      

        public Task AddNewMess(AddnewKafkaRequest request)
        {
            return _workWithKafka.ProduceMessagesAsync(request.BootstrapServers, request.Topic, request.Message); 
        }

        public Task GetAllMessages(GetKafkaRespone respone)
        {
            return _workWithKafka.ConsumeMessagesAsync(respone.BootstrapServers, respone.Topic);
        }



    }
}
