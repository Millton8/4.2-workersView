const salaryTable = document.getElementById("salaryTable")

if (salaryTable.ariaColCount === null)
    salaryTable.style.visibility = "hidden"


async function getReport() {
    const token2 = sessionStorage.getItem("accessToken")

    var dateDo = document.getElementById("dateDo").value
    var datePosle = document.getElementById("datePosle").value
    if (dateDo === "")
        dateDo = "01.01.23"
    if (datePosle === "")
        datePosle = "01.01.2300"
    const information = document.getElementById("information")

    const response = await fetch(`/date/${dateDo}/${datePosle}`, {
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
        salaryTable.style.visibility = "visible"
        const salaryTableBody = document.getElementById("salaryTableBody")
        salaryTableBody.innerHTML = ""
        for (const i in report) {
            const trCount = document.createElement("tr");
            trCount.setAttribute("data-rowid", 0);

            const uniqTd = document.createElement("td");
            uniqTd.append(report[i].uniq)
            trCount.append(uniqTd)

            const nameTd = document.createElement("td");
            nameTd.append(report[i].name)
            trCount.append(nameTd)

            const salaryTd = document.createElement("td");
            salaryTd.append(report[i].sum)
            trCount.append(salaryTd)

            salaryTableBody.append(trCount)
        }


    }
    else
        errorsHandler(response.status)
}