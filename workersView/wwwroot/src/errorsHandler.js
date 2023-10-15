function errorsHandler(errorCode) {

    switch (errorCode) {
        case 400:
            information.innerHTML = "Не верный пароль"
            console.log(response.status, response.statusText)
            break
        case 401:
            document.getElementById("mainDiv").innerHTML = "Ошибка доступа. Вы не авторизованы"
            console.log(response.status, response.statusText)
            break
        case 404:
            information.innerHTML = "Ошибка. Клиент не правильно сформировал запрос"
            console.log(response.status, response.statusText)
            break
        case 500:
            information.innerHTML = "Произошла ошибка на сервере"
            console.log(response.status, response.statusText)
            break
        default:
            information.innerHTML = "Неизвестная ошибка"
            console.log(response.status, response.statusText)
            break
    }
   
}