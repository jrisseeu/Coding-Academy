const teamUrl = 'api/team';
const parentUrl = 'api/Parent';
const playerUrl = 'api/player';
const sessionTeamId = sessionStorage.getItem("teamId");


let teams = [];
let players = [];
let playerIds = [];


function getTeams() {

    fetch(teamUrl)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));

}

function getPlayers() {

    fetch(playerUrl)
        .then(response => response.json())
        .then(data => _displayPlayers(data))
        .catch(error => console.error('Unable to get players.', error));

}

function getParents() {
    
    fetch(parentUrl)
        .then(response => response.json())
        .then(data => _displayParents(data))
        .catch(error => console.error('Unable to get parents.', error));

}



function _displayItems(data) {
    const tBody = document.getElementById('roster');
    tBody.innerHTML = '';

    

    const button = document.createElement('button');

    data.forEach(team => {

        if (team.teamId == sessionTeamId) {

            let tr = tBody.insertRow();

            let td0 = tr.insertCell(0);
            let textNode = document.createTextNode(team.season + " " + team.teamName + " - " + team.sportName);
            td0.appendChild(textNode);

        }

        getPlayers();
       
       

       
    });

    teams = data;
}


function _displayPlayers(theData) {

    const tBody = document.getElementById('players');
    tBody.innerHTML = '';
   

    theData.forEach(player => {

        if (player.teamId == sessionTeamId) {

            if (playerIds.indexOf(player.playerId) < 0) {
                playerIds.push(player.playerId);
            }

            let tr = tBody.insertRow();

            let td0 = tr.insertCell(0);
            let textNode = document.createTextNode(player.playerFname + " " + player.playerLname);
            td0.appendChild(textNode);


                       
        }
    });

    players = theData;

    getParents();
    
}

function _displayParents(data) {
    
    const tBody = document.getElementById('parents');
    tBody.innerHTML = '';

    const button = document.createElement('button');

    data.forEach(parent => {


        for (index = 0; index < playerIds.length; index++) {
            
            if (parent.playerId == playerIds[index]) {

                
                let tr = tBody.insertRow();


                let td0 = tr.insertCell(0);
                let textNode0 = document.createTextNode(parent.parentFname + " " + parent.parentLname);
                td0.appendChild(textNode0);

            }

        }
    });


    parents = data;
}
