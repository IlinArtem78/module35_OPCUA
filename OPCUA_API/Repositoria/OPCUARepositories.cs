
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using Opc.Ua.Configuration; 
using OPCUA_API;
using Opc.Ua;
using OPCUA_API.ModelTags;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
namespace OPCUA_API.Repositoria

{
    public class OPCUARepositories : IWorkerOPCUA
    {
        public List<FormatGet> _formatGet { get; set; } = new List<FormatGet>();
       

        public string JsonMessage
        {
             get ;
             set ;
         }
        

        public void ConverToClass()
        {
            // Разбиваем строку на отдельные записи
            string[] records = JsonMessage.Split(';');
            var state = records.Length;
            Console.WriteLine(state); 
            foreach (string record in records)
            {
                // Разбиваем запись на части
                string[] parts = record.Split(',');

                // Создаём новый объект FormatGet и заполняем его поля
                FormatGet formatGet = new FormatGet();
                foreach (string part in parts)
                {
                    string[] keyValue = part.Split(':');
                    switch (keyValue[0].Trim())
                    {
                        case "Name":
                            formatGet.Name = keyValue[1].Trim();
                            break;
                        case "Value":
                            formatGet.Value = keyValue[1].Trim();
                            break;
                        case "DataType":
                            formatGet.DataType = keyValue[1].Trim();
                            break;
                        case "Description":
                            formatGet.Description = keyValue[1].Trim();
                            break;
                    }
                }
                // Проверяем, есть ли уже объект с таким же именем в списке
                /*
                bool isUpdated = false;
                for (int i = 0; i < _formatGet.Count; i++)
                {
                    if (_formatGet[i].Name == formatGet.Name)
                    {
                        // Если объект с таким же именем уже существует, обновляем его значения
                        _formatGet[i] = formatGet;
                        isUpdated = true;
                        break;
                    }
                }

                // Если объекта с таким именем не было, добавляем новый объект в список
                if (!isUpdated)
                {
                    _formatGet.Add(formatGet);
                }
                */
                int i = _formatGet.Count;
                Console.WriteLine("Количество иттераций {0}", i);   
                _formatGet.Add(formatGet);
                foreach (var format  in _formatGet)
                { 
                    
                    // Дополнительные отладочные сообщения
                    Console.WriteLine($"Added to list: Name: {format.Name}, Value: {format.Value}, DataType: {format.DataType}, Description: {format.Description}");
              
                }
            }
        }

        public NodeId ConverType(FormatGet format)
        {
           switch (format.DataType)
            {
                        case "bool":

                            return DataTypeIds.Boolean;
                            break;
                        case "string":
                            
                            return DataTypeIds.String;
                            break;
                        case "int":
                            
                            return  DataTypeIds.Int32;

                            break;
                        case "real":
                           
                            return DataTypeIds.Float;
                            break;
                        case "time":
                            NodeId t;
                            return t = DataTypeIds.DateTime;
                            break;
                        case "byte":
                            NodeId bt;
                            return bt = DataTypeIds.Byte;
                            break;
                        case "double":
                            NodeId d;
                            return d = DataTypeIds.Double;
                            break;
                    }
            return null;
            
        }

        public Type ConverTypeName(FormatGet format)
        {
            switch (format.DataType)
            {
                case "real":
                    return typeof(System.Single);
                    
                    
                case "bool":
                    return typeof(System.Boolean);
                case "string":
                    return typeof(System.String);
                case "int":
                    return typeof(System.Int32);
                case "time":
                    return typeof(System.DateTime);
                case "byte":
                    return typeof(System.Byte);
                case "double":
                    return typeof(System.Double);
                default:
                    throw new Exception("Неизвестный тип данных");
            }

                 
            }

        public object ConvertStringToType(string value, FormatGet format)
        {
            Type targetType = ConverTypeName(format);
            try
            {
                return Convert.ChangeType(value, targetType);
            }
            catch (InvalidCastException)
            {
                throw new Exception($"Невозможно преобразовать строку '{value}' в тип {targetType.Name}");
            }
        }







    }






      



    }
     

