var tokenKey = "accessToken";

// при нажатии на кнопку отправки формы идет запрос к /login для получения токена
document.getElementById("submitLogin").addEventListener("click", async e => {
    e.preventDefault();
    // отправляет запрос и получаем ответ
    var pass = document.getElementById("password").value
    const response = await fetch("/login", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(pass

        )
    });
    // если запрос прошел нормально
    if (response.ok === true) {
        // получаем данные
        const access_token = await response.json();
        sessionStorage.setItem(tokenKey, access_token);

        const token1 = sessionStorage.getItem("accessToken")

        window.location.replace(`/status.html?${access_token}`)

    }
    else
        errorsHandler(response.status)

});