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

//function taskDelegate(response) {
//    console.log("after response");
//    let tasksPoolList;

//    switch (userId)
//    {
//        //User1
//        case 1:
//            tasksPoolList = document.querySelector("#tasks-pool-list-user-one");
//            break;
//        //User2
//        case 2:
//            tasksPoolList = document.querySelector("#tasks-pool-list-user-two");
//            break;
//        //User3
//        case 3:
//            tasksPoolList = document.querySelector("#tasks-pool-list-user-three");
//            break;
//        default:
//            break;
//    }

//    for (const task of response) {

//        let container = document.createElement("li");
//        container.classList.add("tasks-pool-list-item");
//        let textNode = document.createTextNode(task.name);

//        container.appendChild(textNode);

//        tasksPoolList.appendChild(container);
//    }
//}

//function DelegateAssignments() {
    
//    let xhr = new XMLHttpRequest();

//    //GET / url / async
//    xhr.open("GET", "api/Users/", true);

//    xhr.addEventListener('load', function () {
//        console.log("delegate");
//        let response = [];

//        try {
//            response = JSON.parse(this.response);
//        } catch (e) {
//            console.error("Parsing JSON didn't work");
//        }
//        taskDelegate(response);

//    });

//    //send connection
//    xhr.send();
//}

//DelegateAssignments();

