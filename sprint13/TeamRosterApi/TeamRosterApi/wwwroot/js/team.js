const teamUrl = 'api/team';

let teams = [];



function getTeams() {


    fetch(teamUrl)
        .then(response => response.json())
        .then(data => _displayTeamItems(data))
        .catch(error => console.error('Unable to get items.', error));

}

function isEmpty(str) {
    return (!str || str.length === 0);
}

function addTeam() {
    const teamName = document.getElementById('add-team');
    const sport = document.getElementById('add-sport');
    const season = document.getElementById('add-season');

    if (isEmpty(teamName.value)) {
        alert("Please provide a team name" );
        return false;
    } 

    const team = {
        teamName: teamName.value.trim(),
        sportName: sport.value.trim(),
        season: season.value.trim()
    };

    fetch(teamUrl, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(team)
    })
        .then(response => response.json())
        .then(() => {
            getTeams();
            teamName.value = '';
            sport.value = 'Football';
            season.value = 'Fall';
        })
        .catch(error => console.error('Unable to add team.', error));

}

function displayTeamEditForm(teamId) {

    const team = teams.find(team => team.teamId === teamId);

    document.getElementById('edit-teamId').value = team.teamId;
    document.getElementById('edit-teamName').value = team.teamName;
    document.getElementById('edit-sportName').value = team.sportName;
    document.getElementById('edit-season').value = team.season
    document.getElementById('editForm').style.display = 'block';
}

function getPlayers(id) {

    sessionStorage.setItem("teamId", id);
    window.open("player1.html", "_blank");
    

}


function printRoster(id) {

    sessionStorage.setItem("teamId", id);
    window.open("roster.html", "_blank");

}

function _displayTeamItems(data) {
    const tBody = document.getElementById('teams');
    tBody.innerHTML = '';

    const button = document.createElement('button');

    data.forEach(team => {

        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayTeamEditForm(${team.teamId})`);
        editButton.setAttribute('class', "btn btn-success btn-sm");

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteTeam(${team.teamId})`);
        deleteButton.setAttribute('class', "btn btn-danger btn-sm");

        let viewPlayers = button.cloneNode(false);
        viewPlayers.innerText = 'Add Players';
        viewPlayers.setAttribute('onclick', `getPlayers(${team.teamId})`);
        viewPlayers.setAttribute('class', "btn btn-primary btn-sm");

        let printRoster = button.cloneNode(false);
        printRoster.innerText = 'Print Roster';
        printRoster.setAttribute('onclick', `printRoster(${team.teamId})`);
        printRoster.setAttribute('class', "btn btn-link");


        let tr = tBody.insertRow();

        let td2 = tr.insertCell(0);
        let textNode2 = document.createTextNode(team.teamName);
        td2.appendChild(textNode2);

        let td3 = tr.insertCell(1);
        let textNode3 = document.createTextNode(team.sportName);
        td3.appendChild(textNode3);

        let td4 = tr.insertCell(2);
        let textNode4 = document.createTextNode(team.season);
        td4.appendChild(textNode4);

        let td5 = tr.insertCell(3);
        td5.appendChild(editButton);

        let td6 = tr.insertCell(4);
        td6.appendChild(deleteButton);

        let td7 = tr.insertCell(5);
        td7.appendChild(viewPlayers);

        //let td8 = tr.insertCell(6);
        //td8.appendChild(printRoster);
    });

    teams = data;
}

function updateTeam() {
    const teamId = document.getElementById('edit-teamId').value;
    const team = {
        teamId: parseInt(teamId, 10),
        teamName: document.getElementById('edit-teamName').value.trim(),
        sportName: document.getElementById('edit-sportName').value.trim(),
        season: document.getElementById('edit-season').value.trim()
    };

    fetch(`${teamUrl}/${teamId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(team)
    })
        .then(() => getTeams())
        .catch(error => console.error('Unable to update team.', error));

    closeTeamInput();

    return false;
}

function deleteTeam(id) {
    fetch(`${teamUrl}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getTeams())
        .catch(error => console.error('Unable to delete team.', error));
}

function closeTeamInput() {
    document.getElementById('editForm').style.display = 'none';
}


function ShowAndHide() {
    let x = document.getElementById('PlayerSection');
    if (x.style.display == 'none') {
        x.style.display = 'block';
    } else {
        x.style.display = 'none';
    }
}

