const teamUrl = 'api/team';
const parentUrl = 'api/Parent';
const playerUrl = 'api/player';
const ssessionTeamId = sessionStorage.getItem("teamId");

let teams = [];



function getTeams() {

    fetch(teamUrl)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));

}

function getPlayers() {

    fetch(playerUrl)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get players.', error));

}

function getParents() {
    closeParentInput();
    fetch(parentUrl)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get parents.', error));

}



function _displayItems(data) {
    const tBody = document.getElementById('roster');
    tBody.innerHTML = '';

    const button = document.createElement('button');

    data.forEach(team => {

        if (team.teamId == ssessionTeamId) {

            let editButton = button.cloneNode(false);
            editButton.innerText = 'Edit';
            editButton.setAttribute('onclick', `displayEditForm(${team.teamId})`);

            let deleteButton = button.cloneNode(false);
            deleteButton.innerText = 'Delete';
            deleteButton.setAttribute('onclick', `deleteTeam(${team.teamId})`);

            let viewPlayers = button.cloneNode(false);
            viewPlayers.innerText = 'Add Players';
            viewPlayers.setAttribute('onclick', `getPlayers(${team.teamId})`);

            let tr = tBody.insertRow();

            let td2 = tr.insertCell(0);
            let textNode2 = document.createTextNode(team.teamName);
            td2.appendChild(textNode2);
        }
       
    });

    teams = data;
}
