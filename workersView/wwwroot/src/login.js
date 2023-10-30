var tokenKey = "accessToken";

document.getElementById("submitLogin").addEventListener("click", async e => {
    e.preventDefault();

    var pass = document.getElementById("password").value
    const response = await fetch("/login", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(pass

        )
    });

    if (response.ok === true) {

        const access_token = await response.json();
        sessionStorage.setItem(tokenKey, access_token);

        const token1 = sessionStorage.getItem("accessToken")

        window.location.replace(`/status.html?${access_token}`)

    }
    else
        errorsHandler(response.status)

});