using Kafka_API; 
using AutoMapper;
using Confluent.Kafka;
using Kafka_web.Models;

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Authentication;
using System.Security.Claims;
using System.Runtime.CompilerServices;
using OPCUA_API;
using OPCUA_API.Repositoria;
using OPCUA_API.WorkWithServer;

namespace Kafka_web.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IKafkaAction _kafkaAction;
        private readonly IWorkerOPCUA _workerOPCUA;
        private readonly IRunOpcUA _runOpcUa; 

        public HomeController(ILogger<HomeController> logger, IKafkaAction kafka, IWorkerOPCUA workerOPCUA, IRunOpcUA runOpcUa)
        {
            _logger = logger;
            
            
            _kafkaAction = kafka;   
            _workerOPCUA = workerOPCUA;
            _runOpcUa = runOpcUa;
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Простая проверка для примера
            if (username == "admin" && password == "admin")
            {
               
                return Json(new { success = true });
                
            }
            return Json(new { success = false });
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string ServerURL, string Topic, string message)
        {
            
            Console.WriteLine($"ServerURL: {ServerURL}, Topic: {Topic}, message : {message}");
            var newMessToKafka = new AddnewKafkaRequest();
            newMessToKafka.BootstrapServers = ServerURL;
            newMessToKafka.Topic = Topic;
            newMessToKafka.Message = message;
            var AddToKafka = _kafkaAction.AddNewMess(newMessToKafka);
            return Json(new { message = "Данные успешно получены" });
             
        }


        [HttpPost]
        public  IActionResult InputKafka(string KafkaURL, string Topic)
        {
            
            var getAllMessages = new GetKafkaRespone();
            getAllMessages.Topic = Topic;
            getAllMessages.BootstrapServers = KafkaURL;
            var getAllFromKafka = _kafkaAction.GetAllMessages(getAllMessages);
            var message = _kafkaAction.jsonToOPC;
            _workerOPCUA.JsonMessage = message;
            var model = new { Message = message };
            return Json(model);
            


        }
        [HttpGet]
        public IActionResult InputKafka()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StartpServer()
        {
            _runOpcUa.StartWindowsFormsApp();
            return Json(new { success = true, message = "Сервер запущен" });
        }
        public IActionResult Registration()
        {
            
            return View();
        }

    

        [HttpPost]
        public IActionResult StopServer()
        {
            _runOpcUa.StopWindowsFormsApp();
            return Json(new { success = true, message = "Сервер остановлен" });
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
