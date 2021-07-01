const playerUrl = 'api/player';
let players = [];
const ssessionTeamId = sessionStorage.getItem("teamId");

  

function getPlayers() {

    fetch(playerUrl)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get players.', error));

}

function isEmpty(str) {
    return (!str || str.length === 0);
}

function addPlayer() {
    const firstName = document.getElementById('add-playerFname');
    const lastName = document.getElementById('add-playerLname');

    if (isEmpty(firstName.value)) {
        alert("Please provide a player first name");
        return false;
    } 

    if (isEmpty(lastName.value)) {
        alert("Please provide a player last name");
        return false;
    } 


    const player = {

        teamId: ssessionTeamId,
        playerFname: firstName.value.trim(),
        playerLname: lastName.value.trim(),

    };

    fetch(playerUrl, {
        method: 'post',
        headers: {
            'accept': 'application/json',
            'content-type': 'application/json'
        },
        body: JSON.stringify(player)
    })
        .then(response => response.json())
        .then(() => {
            getPlayers();
            firstName.value = '';
            lastName.value = '';
        })
        .catch(error => console.error('unable to add player.', error));

}


function getParents(id) {

    sessionStorage.setItem("playerId", id);
    window.open("parent1.html", "_blank");


}


function displayEditForm(playerId) {

    const player = players.find(player => player.playerId === playerId);

    document.getElementById('edit-playerId').value = player.playerId;
    document.getElementById('edit-teamId').value = player.teamId;
    document.getElementById('edit-firstNm').value = player.playerFname;
    document.getElementById('edit-lastNm').value = player.playerLname
    document.getElementById('editPlayerForm').style.display = 'block';
}

function _displayItems(data) {
    const tBody = document.getElementById('players');
    tBody.innerHTML = '';

    const button = document.createElement('button');

    data.forEach(player => {


        if (player.teamId == ssessionTeamId) {
            
            let editButton = button.cloneNode(false);
            editButton.innerText = 'Edit';
            editButton.setAttribute('onclick', `displayEditForm(${player.playerId})`);
            editButton.setAttribute('class', "btn btn-success btn-sm");

            let deleteButton = button.cloneNode(false);
            deleteButton.innerText = 'Delete';
            deleteButton.setAttribute('onclick', `deletePlayer(${player.playerId})`);
            deleteButton.setAttribute('class', "btn btn-danger btn-sm");

            let viewParents = button.cloneNode(false);
            viewParents.innerText = 'Add Parents';
            viewParents.setAttribute('onclick', `getParents(${player.playerId})`);
            viewParents.setAttribute('class', "btn btn-primary btn-sm");

            let tr = tBody.insertRow();

            let td3 = tr.insertCell(0);
            let textNode3 = document.createTextNode(player.playerFname);
            td3.appendChild(textNode3);

            let td4 = tr.insertCell(1);
            let textNode4 = document.createTextNode(player.playerLname);
            td4.appendChild(textNode4);

            let td5 = tr.insertCell(2);
            td5.appendChild(editButton);

            let td6 = tr.insertCell(3);
            td6.appendChild(deleteButton);

            let td7 = tr.insertCell(4);
            td7.appendChild(viewParents);
        }
    });


    players = data;
}



function updatePlayer() {
    const playerId = document.getElementById('edit-playerId').value;
    const teamId = document.getElementById('edit-teamId').value;
    const player = {
        playerId: parseInt(playerId, 10),
        teamId: parseInt(teamId, 10),
        playerFname: document.getElementById('edit-firstNm').value.trim(),
        playerLname: document.getElementById('edit-lastNm').value.trim(),
    };

    fetch(`${playerUrl}/${playerId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(player)
    })
        .then(() => getPlayers())
        .catch(error => console.error('Unable to update player.', error));

    closePlayerInput();

    return false;
}

function deletePlayer(id) {
    fetch(`${playerUrl}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getPlayers())
        .catch(error => console.error('Unable to delete player.', error));
}

function closePlayerInput() {
    document.getElementById('editPlayerForm').style.display = 'none';
}

function closePlayerWindow() {

    window.open('', '_self').close();

}