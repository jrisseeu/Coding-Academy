var winningConditions = [
    [0, 1, 2],
    [3, 4, 5],
    [6, 7, 8],
    [0, 3, 6],
    [1, 4, 7],
    [2, 5, 8],
    [0, 4, 8],
    [2, 4, 6]
];

let gameState: string[] = ["", "", "", "", "", "", "", "", ""];
document.getElementById('print').innerHTML = "Player 1 (X) Turn";

function myfunc(clickedCellEvent) {

    let keepPlaying:boolean = true;
    var clickedCell = clickedCellEvent.target;
    let clickedCellIndex:number = parseInt(clickedCell.getAttribute('index'));

    if (flag == 1) {
        gameState[clickedCellIndex] = "X";
        flag = 0;
    } else {
        gameState[clickedCellIndex] = "O";
        flag = 1;
    }
    
    for (let i:number = 0; i <= 8; i++) {

        (<HTMLInputElement>document.getElementById(i.toString())).value = gameState[i];
        if (gameState[i] !== ''){
            (<HTMLInputElement>document.getElementById(i.toString())).disabled = true;
        } else {
            (<HTMLInputElement>document.getElementById(i.toString())).disabled = false;
        }

    }

    let roundDraw:number = 0;
    if (!checkForWinner()) {
        for (let a:number = 0; a < 9; a++){
            if ((gameState[a] == "X") || (gameState[a] == "O"))
               roundDraw++;
         }
    } else {
        return;
    }
        
    if (roundDraw == 9) {
        document.getElementById('print').innerHTML = "Match is a Tie";
        return;
    }


    if (flag == 1) {
        document.getElementById('print').innerHTML = "Player 1 (X) Turn";
    }
    else {
        document.getElementById('print').innerHTML = "Player 2 (O) Turn";
    }

    return;
 }

 //loop through the game state to see if the player has all the winning slots filled
 function checkForWinner() {

    for (let j:number = 0; j <= 7; j++) {
        let winner = winningConditions[j];
        let a:string = gameState[winner[0]];
        let b:string = gameState[winner[1]];
        let c:string = gameState[winner[2]];
      
        if (a === 'X' && b === 'X' && c ==='X')  {
            //window.alert("WINNER 1"); 
            document.getElementById('print').innerHTML = "Player 1 is the winner";
            return true;
        } else if (a === 'O' && b === 'O' && c ==='O') {
            //window.alert("WINNER 2"); 
            document.getElementById('print').innerHTML = "Player 2 is the winner";    
            return true;
        } 
    }
    return false;
 }
  
// Function to reset game
function myfunc_2() {
    location.reload();
    for (let i:number = 0; i <= 8; i++) {

        (<HTMLInputElement>document.getElementById(i.toString())).value = '';  
        (<HTMLInputElement>document.getElementById(i.toString())).disabled = false;
    }

    document.getElementById('print').innerHTML = "Player 1 (X) Turn";
}
  

let flag:number = 1;
document.querySelectorAll('.cell').forEach(function (cell) { return cell.addEventListener('click', myfunc); });
