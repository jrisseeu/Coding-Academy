
let taskList:HTMLElement = (<HTMLElement> document.getElementById('task-list'));
let checkList:HTMLElement = (<HTMLElement> document.getElementById('checked-list'));

//Start the Event Listeners when page is loaded
eventListeners();

function eventListeners() {

    //Form Submission listener
    document.querySelector('#form').addEventListener('submit', newTask);

    //Creates the click event listener for the Completed tasks in the TaskList
    taskList.addEventListener('click', completeTask);

    //Creates the click event for the Remove tasks from TaskList section
    taskList.addEventListener('click', removeTask);

    //Creates the click event for the Remove tasks from completed tasks section
    checkList.addEventListener('click', deleteCompleted);

}

//Add the new item to the tasks to do section
function newTask(e) {

    //get the Text value
    let task:string = (<HTMLInputElement> document.getElementById('addtask')).value;

    // IF the user does not enter anything and clicks add task or hits the enter key, 
    //do nothing, just return back to clean text area box and reset the area
    if ( task == '' || task == '\n') {
        this.reset();
        return;
    }

  //Create the checked button
  let checkBtn:HTMLElement = (<HTMLElement> document.createElement('a'));
  checkBtn.classList.add('checked-task');
  checkBtn.textContent = ' Done ';

  //Create the remove Button
  let removeBtn:HTMLElement =  (<HTMLElement> document.createElement('a'));
  removeBtn.classList.add('remove-task');
  removeBtn.textContent = ' Remove ';

  //Create <li>
  let li:HTMLElement = (<HTMLElement> document.createElement('li'));
  li.textContent = task;

  //add this button to each task
  li.appendChild(removeBtn);
  //add checked button to each task
  li.appendChild(checkBtn);

  //add to the list
  taskList.appendChild(li);

  this.reset();
}

function completeTask(e) {
  if (e.target.classList.contains('checked-task')) {
    let taskText:string = e.target.parentElement.textContent;
    let taskDone:string = taskText.substring(0, taskText.length - 14);
    
    //Create the remove Button
    let deleteBtn:HTMLElement = (<HTMLElement>document.createElement('a')); //anchor tag
    deleteBtn.classList.add('delete-task');
    deleteBtn.textContent = ' Delete ';

    //Create <li>
    let li:HTMLElement = (<HTMLElement> document.createElement('li'));
    li.textContent = taskDone;

    //add this button to each task
    li.appendChild(deleteBtn);

    //add to the list
    checkList.appendChild(li);
    checkList.classList.value ='checked-list';

    //remove from the tasks todo list
    e.target.parentElement.remove();

  }
}

//Remove the Tasks from the Tasks TO DO list when the Remove link is pressed
function removeTask(e) {
    if (e.target.classList.contains('remove-task')) {
      e.target.parentElement.remove();
    }
}
  
  //Removed the row from the completed task list when the delete link is pressed
function deleteCompleted(e) {
      if (e.target.classList.contains('delete-task')) {
        e.target.parentElement.remove();
      }
}
  