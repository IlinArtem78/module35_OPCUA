$(document).ready(function () {
    // Обработчик нажатия кнопки "Войти"
    $('#sendData').click(function () {
        // Получаем значения полей ввода
        var username = $('.input_login').val();
        var password = $('.input_passw').val();

        // Проверяем введенные данные
        if (username === 'admin' && password === 'admin') {
            // Отправляем данные на сервер
            $.ajax({
                url: '/Home/Login',
                type: 'POST',
                data: {
                    username: username,
                    password: password
                },
                success: function (response) {
                    if (response.success) {
                        // Переходим на главную страницу
                        window.location.href = '/Home/Index';
                    } else {
                        alert('Ошибка авторизации');
                    }
                },
                error: function () {
                    alert('Произошла ошибка');
                }
            });
        } else {
            alert('Неверный логин или пароль');
        }
    });
});