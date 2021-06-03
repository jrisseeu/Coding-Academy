const parentUrl = 'api/Parent';
let parents = [];
const sessionPlayerId = sessionStorage.getItem("playerId");



function getParents() {
    
    fetch(parentUrl)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get parents.', error));

}

function isEmpty(str) {
    return (!str || str.length === 0);
}

function addParent() {
    const firstName = document.getElementById('add-parentFname');
    const lastName = document.getElementById('add-parentLname');

    if (isEmpty(firstName.value)) {
        alert("Please provide a parent first name");
        return false;
    } 

    if (isEmpty(lastName.value)) {
        alert("Please provide a parent last name");
        return false;
    } 



    const parent = {
        playerId: sessionPlayerId,
        parentFname: firstName.value.trim(),
        parentLname: lastName.value.trim(),

    };

    fetch(parentUrl, {
        method: 'post',
        headers: {
            'accept': 'application/json',
            'content-type': 'application/json'
        },
        body: JSON.stringify(parent)
    })
        .then(response => response.json())
        .then(() => {
            getParents();
            firstName.value = '';
            lastName.value = '';
        })
        .catch(error => console.error('unable to add parent.', error));

}

function displayEditForm(parentId) {

    const parent = parents.find(parent => parent.parentId === parentId);

    document.getElementById('edit-playerId').value = parent.playerId;
    document.getElementById('edit-parentId').value = parent.parentId;
    document.getElementById('edit-firstNm').value = parent.parentFname;
    document.getElementById('edit-lastNm').value = parent.parentLname
    document.getElementById('editParentForm').style.display = 'block';
}

function _displayItems(data) {
    const tBody = document.getElementById('parents');
    tBody.innerHTML = '';

    const button = document.createElement('button');

    data.forEach(parent => {


        if (parent.playerId == sessionPlayerId) {

            let editButton = button.cloneNode(false);
            editButton.innerText = 'Edit';
            editButton.setAttribute('onclick', `displayEditForm(${parent.parentId})`);
            editButton.setAttribute('class', "btn btn-success btn-sm");

            let deleteButton = button.cloneNode(false);
            deleteButton.innerText = 'Delete';
            deleteButton.setAttribute('onclick', `deletePlayer(${parent.parentId})`);
            deleteButton.setAttribute('class', "btn btn-danger btn-sm");
            
            let tr = tBody.insertRow();

          
            let td0 = tr.insertCell(0);
            let textNode0 = document.createTextNode(parent.parentFname);
            td0.appendChild(textNode0);

            let td1 = tr.insertCell(1);
            let textNode1 = document.createTextNode(parent.parentLname);
            td1.appendChild(textNode1);

            let td2 = tr.insertCell(2);
            td2.appendChild(editButton);

            let td3 = tr.insertCell(3);
            td3.appendChild(deleteButton);

        }
    });


    parents = data;
}

function updateParent() {
    const playerId = document.getElementById('edit-playerId').value;
    const parentId = document.getElementById('edit-parentId').value;
    const parent = {
        parentId: parseInt(parentId, 10),
        playerId: parseInt(playerId, 10),        
        parentFname: document.getElementById('edit-firstNm').value.trim(),
        parentLname: document.getElementById('edit-lastNm').value.trim(),
    };

    fetch(`${parentUrl}/${parentId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(parent)
    })
        .then(() => getParents())
        .catch(error => console.error('Unable to update parent.', error));

    closeParentInput();

    return false;
}

function deletePlayer(id) {
    fetch(`${parentUrl}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getParents())
        .catch(error => console.error('Unable to delete parent.', error));
}

function closeParentInput() {
    
    document.getElementById('editParentForm').style.display = 'none';
}

function closeParentWindow() {

    window.open('', '_self').close();
    
}
