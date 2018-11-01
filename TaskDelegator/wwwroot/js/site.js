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


function DelegateAssignments() {
    
    let xhr = new XMLHttpRequest();

    //GET / url / async
    xhr.open("GET", "api/Users/", true);

    xhr.addEventListener('load', function () {
        console.log("delegate");
        let response = [];

        try {
            response = JSON.parse(this.response);
        } catch (e) {
            console.error("Parsing JSON didn't work");
        }
        taskDelegate(response);

    });

    //send connection
    xhr.send();
}

DelegateAssignments();

//Function is creating list elements for each task assigned for particular user
function taskDelegate(response)
{

    for (const user of response) {

        switch (user.id)
        {
            case 1:
                for (const task of user.assignments)
                {
                    let tasksPoolList = document.querySelector("#tasks-pool-list-user-one");
                    createListElement(tasksPoolList, task);
                }
                break;
            case 2:
                for (const task of user.assignments)
                {
                    let tasksPoolList = document.querySelector("#tasks-pool-list-user-two");
                    createListElement(tasksPoolList, task);
                }
                break;
            case 3:
                for (const task of user.assignments)
                {
                    let tasksPoolList = document.querySelector("#tasks-pool-list-user-three");
                    createListElement(tasksPoolList, task);
                }
                break;
            default:
                break;
        }
    }
}

//Helper function for taskDelegate() creating DOM structure
function createListElement(tasksPoolList, task)
{
    let container = document.createElement("li");
    container.classList.add("tasks-pool-list-item");
    let textNode = document.createTextNode(task.name);
    container.appendChild(textNode);
    tasksPoolList.appendChild(container);
}