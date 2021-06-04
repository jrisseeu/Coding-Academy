var teamUrl = 'api/team';
var teams = [];
function getTeams() {
    fetch(teamUrl)
        .then(function (response) { return response.json(); })
        .then(function (data) { return _displayTeamItems(data); })["catch"](function (error) { return console.error('Unable to get items.', error); });
}
function isEmpty(str) {
    return (!str || str.length === 0);
}
function addTeam() {
    var teamName = document.getElementById('add-team');
    var sport = document.getElementById('add-sport');
    var season = document.getElementById('add-season');
    if (isEmpty(teamName.value)) {
        alert("Please provide a team name");
        return false;
    }
    var team = {
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
        .then(function (response) { return response.json(); })
        .then(function () {
        getTeams();
        teamName.value = '';
        sport.value = 'Football';
        season.value = 'Fall';
    })["catch"](function (error) { return console.error('Unable to add team.', error); });
}
function displayTeamEditForm(teamId) {
    var team = teams.find(function (team) { return team.teamId === teamId; });
    document.getElementById('edit-teamId').value = team.teamId;
    document.getElementById('edit-teamName').value = team.teamName;
    document.getElementById('edit-sportName').value = team.sportName;
    document.getElementById('edit-season').value = team.season;
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
    var tBody = document.getElementById('teams');
    tBody.innerHTML = '';
    var button = document.createElement('button');
    data.forEach(function (team) {
        var editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', "displayTeamEditForm(" + team.teamId + ")");
        editButton.setAttribute('class', "btn btn-success btn-sm");
        var deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', "deleteTeam(" + team.teamId + ")");
        deleteButton.setAttribute('class', "btn btn-danger btn-sm");
        var viewPlayers = button.cloneNode(false);
        viewPlayers.innerText = 'Add Players';
        viewPlayers.setAttribute('onclick', "getPlayers(" + team.teamId + ")");
        viewPlayers.setAttribute('class', "btn btn-primary btn-sm");
        var printRoster = button.cloneNode(false);
        printRoster.innerText = 'Print Roster';
        printRoster.setAttribute('onclick', "printRoster(" + team.teamId + ")");
        printRoster.setAttribute('class', "btn btn-info btn-sm");
        var tr = tBody.insertRow();
        var td2 = tr.insertCell(0);
        var textNode2 = document.createTextNode(team.teamName);
        td2.appendChild(textNode2);
        var td3 = tr.insertCell(1);
        var textNode3 = document.createTextNode(team.sportName);
        td3.appendChild(textNode3);
        var td4 = tr.insertCell(2);
        var textNode4 = document.createTextNode(team.season);
        td4.appendChild(textNode4);
        var td5 = tr.insertCell(3);
        td5.appendChild(editButton);
        var td6 = tr.insertCell(4);
        td6.appendChild(deleteButton);
        var td7 = tr.insertCell(5);
        td7.appendChild(viewPlayers);
        var td8 = tr.insertCell(6);
        td8.appendChild(printRoster);
    });
    teams = data;
}
function updateTeam() {
    var teamId = document.getElementById('edit-teamId').value;
    var team = {
        teamId: parseInt(teamId, 10),
        teamName: document.getElementById('edit-teamName').value.trim(),
        sportName: document.getElementById('edit-sportName').value.trim(),
        season: document.getElementById('edit-season').value.trim()
    };
    fetch(teamUrl + "/" + teamId, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(team)
    })
        .then(function () { return getTeams(); })["catch"](function (error) { return console.error('Unable to update team.', error); });
    closeTeamInput();
    return false;
}
function deleteTeam(id) {
    fetch(teamUrl + "/" + id, {
        method: 'DELETE'
    })
        .then(function () { return getTeams(); })["catch"](function (error) { return console.error('Unable to delete team.', error); });
}
function closeTeamInput() {
    document.getElementById('editForm').style.display = 'none';
}
