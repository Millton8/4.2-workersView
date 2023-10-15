
const information = document.getElementById("information")
async function getStatus() {
    const token2 = sessionStorage.getItem("accessToken")
    const toGeneral = document.getElementById("toGeneral")
    toGeneral.addEventListener("click", async e => {
        e.preventDefault();
        window.location.replace(`/generalReport.html?${token2}`)
        
    }
    )
    const toWorkers = document.getElementById("toWorkers")
    toWorkers.addEventListener("click", async e => {
        e.preventDefault();
        window.location.replace(`/workerslist.html?${token2}`)
    }
    )
    const toDates = document.getElementById("toDates")
    toDates.addEventListener("click", async e => {
        e.preventDefault();
        window.location.replace(`/date.html`)
    }
    )
   
        const response = await fetch("/status", {
            method: "GET",
            headers: { "custom-header": "application/json", "Authorization": "Bearer " + token2 }

        })
        if (response.ok === true) {
            console.log("From status after resp")
            console.log(token2)


            const listWorkers = await response.json()
            renderStatus(listWorkers)

    }
        else
            errorsHandler(response.status)
        


}

async function renderStatus(listWorkers) {
    var workerOrderedNumber = 1
    var customObject = new Object()

    const rows = document.querySelector("tbody");
    for (const i in listWorkers) {

        const tr = document.createElement("tr");
        tr.setAttribute("data-rowid", 0);

        const number = document.createElement("td");
        number.append(workerOrderedNumber);
        tr.append(number);

        const uniq = document.createElement("td");
        uniq.append(listWorkers[i].uniq);
        tr.append(uniq);

        const name = document.createElement("td");
        name.append(listWorkers[i].name);
        tr.append(name);
        const project = document.createElement("td");
        project.append(listWorkers[i].project);
        tr.append(project);
        const satus = document.createElement("td");
        if (listWorkers[i].workerstatus == true) {
            satus.append("🟢");
            if (customObject.hasOwnProperty(listWorkers[i].project))
                customObject[listWorkers[i].project] += 1
            else
                customObject[listWorkers[i].project] = 1
        }
        else
            satus.append("🔴");
        tr.append(satus);
        rows.append(tr)
        workerOrderedNumber++
    }

    const workerCountTB = document.getElementById("online")
    if (Object.keys(customObject).length === 0) {
        workerCountTB.style.visibility = "hidden"
        information.innerHTML="Нет сотрудников на объектах"
        return
    }

    for (const key in customObject) {
        const trCount = document.createElement("tr");
        const projectCount = document.createElement("td");
        projectCount.append(key)
        trCount.append(projectCount)

        const prCount = document.createElement("td");
        prCount.append(customObject[key])
        trCount.append(prCount)


        workerCountTB.append(trCount)

    }

}
