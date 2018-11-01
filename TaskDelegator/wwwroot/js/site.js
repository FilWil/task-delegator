function tasksBuilder(response) {

    let tasksPoolList = document.querySelector("#tasks-pool-list");

    for (const task of response) {

        let container = document.createElement("li");
        container.classList.add("tasks-pool-list-item");
        let textNode = document.createTextNode(task.name);

        container.appendChild(textNode);

        tasksPoolList.appendChild(container);
    }
}


(function () {
    let xhr = new XMLHttpRequest();

    //GET / url / async
    xhr.open("GET", "api/Assignments/", true);

    xhr.addEventListener('load', function () {

        let response = [];

        try {
            response = JSON.parse(this.response);
        } catch (e) {
            console.error("Parsing JSON didn't work");
        }

        tasksBuilder(response);

    });

    //send connection
    xhr.send();
}());
