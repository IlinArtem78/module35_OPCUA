Web-приложение для отправики и получения данных с Kafka. При получении данные преобразуются в формат Тэг для OPC UA Clienta (В приложении встроен OPC UA Server). 

Формат ввода:  (IP, Topic, Message)
192.168.101.189:9092
test-opcUA
Name: Tag4, Value: 12.5, DataType: real, Description: Температура;
Name: Tag5, Value: 17.5, DataType: real, Description: Температура; 
Name: Tag6, Value: 24, DataType: int, Description: Description3



Формат вывода  (IP, Topic)
192.168.101.189:9092
test-opcUA

В случае положительного сообщения в формате вывода (запускается через 3 секунды OPC UA Server). 

