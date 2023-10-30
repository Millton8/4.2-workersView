const token2 = sessionStorage.getItem("accessToken")
async function OnLoad() {
    var id = window.location.href.split("?")[1];
    const information = document.getElementById("information")


    const response = await fetch(`/get/${id}`, {
        method: "GET",
        headers: { "custom-header": "application/json", "Authorization": "Bearer " + token2 }

    })

    if (response.ok === true) {

        const worker = await response.json()
        document.getElementById("id").value = worker.id
        document.getElementById("uniq").value = worker.uniq
        document.getElementById("name").value = worker.name
        document.getElementById("price").value = worker.price
        document.getElementById("workerstatus").value = worker.workerstatus

    }
    else
        errorsHandler(response.status)


}

async function Update() {
    const information = document.getElementById("information")
    const id = document.getElementById("id").value
    const uniq = document.getElementById("uniq").value
    const name = document.getElementById("name").value
    var price = document.getElementById("price").value
    var workerstatus = document.getElementById("workerstatus").value

    workerstatus = Boolean(workerstatus)
    const worker = { id, uniq, name, price, workerstatus }
    const z = JSON.stringify(worker)


    const response = await fetch(`/update`, {
        method: "PUT",
        headers: { "custom-header": "application/json", "Content-Type": "application/json", "Authorization": "Bearer " + token2 },
        body: JSON.stringify(worker)

    });
    if (response.ok === true) {

        information.innerHTML = "Данные успешно изменены"

        console.log("OK")

    }
    else
        errorsHandler(response.status)

}