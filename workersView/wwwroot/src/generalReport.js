const token2 = sessionStorage.getItem("accessToken")

filters()

async function filters() {


    var report = await getReport()
    const fName = document.getElementById("fName")
    const fProject = document.getElementById("fProject")
    const fTBegin = document.getElementById("fTBegin")
    const fTEnd = document.getElementById("fTEnd")

    fName.addEventListener("input", event => {
        var { value } = event.target
        if (value === "")
            render(report)
        else
            render(report.filter((x) => { return x.name === value }))
        console.log(value, typeof value)
    })

    fProject.addEventListener("input", event => {
        var { value } = event.target
        if (value === "")
            render(report)
        else
            render(report.filter((x) => { return x.project === value }))
        console.log(value, typeof value)
    })

    fTBegin.addEventListener("input", event => {
        var { value } = event.target
        if (value === "")
            render(report)
        else
            render(report.filter((x) => {
                console.log(typeof x.tBegin)
                value = new Date(value)
                return x.tBegin >= value
            }))
        console.log(value, typeof value)
    })

    fTEnd.addEventListener("input", event => {
        var { value } = event.target
        if (value === "")
            render(report)
        else
            render(report.filter((x) => {
                console.log(typeof x.tBegin)
                value = new Date(value)
                return x.tBegin < value
            }))
        console.log(value, typeof value)
    })
    console.log("====")

}


async function getReport() {
    var t = document.getElementById("textfield")

    const response = await fetch(`/list`, {
        method: "GET",
        headers: { "custom-header": "application/json", "Authorization": "Bearer " + token2 }

    })
    if (response.ok === true) {

        const report = await response.json()

        for (const keys of report) {
            keys.tBegin = new Date(keys.tBegin)
            keys.tEnd = new Date(keys.tEnd)
        }

        render(report)
        return report
    }
    else
        errorsHandler(response.status)

}


function render(report) {
    var sumSalary = 0
    var sumTime = 0
    var projectsCount = 0
    var customObject = new Object()

    const rows = document.querySelector("tbody");
    rows.innerHTML = ""
    for (const i in report) {

        const tr = document.createElement("tr");
        tr.setAttribute("data-rowid", report[i].id);

        const uniqTd = document.createElement("td");
        uniqTd.append(report[i].uniq);
        tr.append(uniqTd);

        const nameTd = document.createElement("td");
        nameTd.append(report[i].name);
        tr.append(nameTd);

        const projectTd = document.createElement("td");
        projectTd.append(report[i].project);
        tr.append(projectTd);
        customObject[report[i].project] = 1


        const tbeginTd = document.createElement("td");
        tbeginTd.append(report[i].tBegin.toLocaleString("ru-RU", { year: "2-digit" } + { month: "2-digit" }));
        tr.append(tbeginTd);

        const tendTd = document.createElement("td");
        tendTd.append(report[i].tEnd.toLocaleString("ru-RU", { year: "2-digit" } + { month: "2-digit" }));
        tr.append(tendTd);

        const timeOfWorkTd = document.createElement("td");
        timeOfWorkTd.append(report[i].timeOfWork);
        tr.append(timeOfWorkTd);
        sumTime += report[i].timeOfWork

        const priceTd = document.createElement("td");
        priceTd.append(report[i].price);
        tr.append(priceTd);

        const salaryTd = document.createElement("td");
        salaryTd.append(report[i].salary);
        tr.append(salaryTd);
        sumSalary += report[i].salary

        rows.append(tr)
    }


    for (var key in customObject) {
        projectsCount++;
    }
    const lowTB = document.getElementById("lowTable")
    lowTB.innerHTML = ""
    const trCount = document.createElement("tr");
    trCount.style = "background:#f6f4a6;font-size: large;"
    const timeSumTd = document.createElement("td");

    timeSumTd.append(sumTime)
    trCount.append(timeSumTd)

    const salarySumTd = document.createElement("td");
    salarySumTd.append(sumSalary)
    trCount.append(salarySumTd)

    const projectsCountTd = document.createElement("td");
    projectsCountTd.append(projectsCount)
    trCount.append(projectsCountTd)


    lowTB.append(trCount)
}