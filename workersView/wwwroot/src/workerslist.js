async function getReport() {
    const token2 = sessionStorage.getItem("accessToken")
    const information = document.getElementById("information")



    const response = await fetch(`/listworkers`, {
        method: "GET",
        headers: { "custom-header": "application/json", "Authorization": "Bearer " + token2 }

    })
    if (response.ok === true) {

        const report = await response.json()
        if (report.length === 0) {
            information.innerHTML = "Нет данных за этот период"
            return
        }
        else
            information.innerHTML = ""


        const workersTable = document.getElementById("workersTable")
        workersTable.innerHTML = ""
        const cells = document.querySelectorAll('tr');
        cells.style = "background:rgb(251, 255, 1);font-size: large;"
        for (const i in report) {

            const trCount = document.createElement("tr");
            trCount.setAttribute("data-rowid", 0);

            const uniqTd = document.createElement("td");
            uniqTd.append(report[i].uniq)
            trCount.append(uniqTd)

            const nameTd = document.createElement("td");
            nameTd.append(report[i].name)
            trCount.append(nameTd)

            const priceTd = document.createElement("td");
            priceTd.append(report[i].price)
            trCount.append(priceTd)
            const editTd = document.createElement("td");
            editTd.innerHTML = "✏️"
            editTd.addEventListener("click", async e => {
                e.preventDefault();
                window.location.replace(`/edit.html?${report[i].id}?${token2}`)
            }
            )

            trCount.append(editTd)


            workersTable.append(trCount)
        }


    }
    else
        errorsHandler(response.status)
}