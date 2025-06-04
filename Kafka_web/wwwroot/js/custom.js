
// Обработчик клика по кнопке
document.getElementById('sendData').addEventListener('click', function () {
    // Получаем значения из полей ввода
    var serverUrl = $('.input_address').val();
    var tagName = $('.input_tom').val();
    var messToKafka = $('.input_message').val();
    // Отправляем данные на сервер с помощью AJAX
    $.ajax({
        url: '/Home/Index', // URL вашего контроллера и действия
        type: 'POST',
        data: {
            ServerURL: serverUrl,
            Topic: tagName,
            message: messToKafka

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





/*
const opcUaData = {
    "root": {
        "children": [
            {
                "name": "Node1",
                "children": [
                    { "name": "SubNode1" },
                    { "name": "SubNode2" }
                ]
            },
            {
                "name": "Node2",
                "children": [
                    { "name": "SubNode3" },
                    { "name": "SubNode4" }
                ]
            }
        ]
    }
};

// Функция для создания дерева
function createTree(data, container) {
    const ul = document.createElement('ul');
    ul.classList.add('tree');

    data.children.forEach(child => {
        const li = document.createElement('li');
        li.textContent = child.name;

        if (child.children) {
            createTree(child, li);
        }

        ul.appendChild(li);
    });

    container.appendChild(ul);
}

// Получение контейнера и создание дерева
const treeContainer = document.getElementById('treeContainer');
createTree(opcUaData.root, treeContainer);
*/