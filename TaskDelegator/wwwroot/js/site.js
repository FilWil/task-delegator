function tasksBuilder(response) {

    let tasksPoolList = document.querySelector("#tasks-pool");

    for (const task of response) {

        let container = document.createElement("div");
        container.classList.add("tasks-pool-list-item");
        container.id = task.id;
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
                    let tasksPoolList = document.querySelector("#user-tasks-one");
                    createListElement(tasksPoolList, task);
                }
                break;
            case 2:
                for (const task of user.assignments)
                {
                    let tasksPoolList = document.querySelector("#user-tasks-two");
                    createListElement(tasksPoolList, task);
                }
                break;
            case 3:
                for (const task of user.assignments)
                {
                    let tasksPoolList = document.querySelector("#user-tasks-three");
                    createListElement(tasksPoolList, task);
                }
                break;
            default:
                break;
        }
    }
}

//Helper function for taskDelegate() creating DOM structure
function createListElement(tasksPoolList, task, userId)
{
    let container = document.createElement("div");
    container.classList.add("tasks-pool-list-item");
    let textNode = document.createTextNode(task.name);
    container.appendChild(textNode);
    container.id = task.id;
    //container.dataset.userId = userId;
    tasksPoolList.appendChild(container);
}

//Options for dragula library
let dragulaOptions = {
    isContainer: function (el) {
        return false; // only elements in drake.containers will be taken into account
    },
    moves: function (el, source, handle, sibling) {
        return true; // elements are always draggable by default
    },
    accepts: function (el, target, source, sibling) {
        return true; // elements can be dropped in any of the `containers` by default
    },
    invalid: function (el, handle) {
        return false; // don't prevent any drags from initiating by default
    },
    direction: 'vertical',             // Y axis is considered when determining where an element would be dropped
    copy: false,                       // elements are moved by default, not copied
    copySortSource: false,             // elements in copy-source containers can be reordered
    revertOnSpill: true,              // spilling will put the element back where it was dragged from, if this is true
    removeOnSpill: false,              // spilling will `.remove` the element, if this is true
    mirrorContainer: document.body,    // set the element that gets mirror elements appended
    ignoreInputTextSelection: true     // allows users to select input text, see details below
};

//Containers for dragula (drag and drop library) which allows dragging items between them
var drake = dragula([
    document.querySelector('#tasks-pool'),
    document.querySelector('#user-tasks-one'),
    document.querySelector('#user-tasks-two'),
    document.querySelector('#user-tasks-three')],
    dragulaOptions
);

//event that gets triggered on element drop into the container ---> it updates assingment in db
drake.on('drop', (e) => {
    let userId = e.parentNode.dataset.containerId;
    UpdateAssingments(e.id, userId);
});

//event triggers function highlighting item for 200ms
drake.on('dragend', (e) =>
    $(function () {
            $(e).addClass('task-highlighted');
            setTimeout(function () {
                $(e).removeClass('task-highlighted');
        }, 200);
}));

//highlight container under drag and drop element
drake.on('over', (el, container, source) => {
    container.classList.add('possible-target-container');
});

//remove highlighting from container under drag and drop element
drake.on('out', (el, container, source) => {
    container.classList.remove('possible-target-container');
});

function UpdateAssingments(id, userId) {

    let xhr = new XMLHttpRequest();

    //PUT / url / async
    if (userId >= 1) {
        xhr.open("PUT", `api/Assignments/${id}?_id=${userId}`, true);
    } else {
        xhr.open("PUT", `api/Assignments/${id}`, true);
    }

    //send connection
    xhr.send();
}