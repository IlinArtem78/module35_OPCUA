
// Обработчик клика по кнопке
document.getElementById('giveData').addEventListener('click', function () {
    // Получаем значения из полей ввода
    var serverUrl = $('.input_address').val();
    var tagName = $('.input_topic').val();

    // Отправляем данные на сервер с помощью AJAX
    $.ajax({
        url: '/Home/InputKafka', // URL вашего контроллера и действия
        type: 'POST',
        data: {
            KafkaURL: serverUrl,
            Topic: tagName
        },
        success: function (response) {
            console.log('Данные успешно отправлены:', response);
           
            document.getElementById('message').innerHTML = response.message;
        },
    error: function (error) {
        console.error('Ошибка при отправке данных:', error);
    }
    });
});

function startServer() {
    // Отправка POST запроса на сервер для запуска сервера
    $.ajax({
        url: '/home/startserver',
        type: 'POST',
        success: function (response) {
            console.log('Сервер запущен:', response);
        },
        error: function (error) {
            console.error('Ошибка при запуске сервера:', error);
        }
    });
}

function stopServer() {
    // Отправка POST запроса на сервер для остановки сервера
    $.ajax({
        url: '/home/stopserver',
        type: 'POST',
        success: function (response) {
            console.log('Сервер остановлен:', response);
        },
        error: function (error) {
            console.error('Ошибка при остановке сервера:', error);
        }
    });
}
