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
// Function called whenever user tab on any box

let gameState: string[] = ["", "", "", "", "", "", "", "", ""];
var keepPlaying = true;
document.getElementById('print').innerHTML = "Player X Turn";

function myfunc(clickedCellEvent) {

    let keepPlaying:boolean = true;
    var clickedCell = clickedCellEvent.target;
    var clickedCellIndex = parseInt(clickedCell.getAttribute('index'));

    let player:string;
    if (flag == 1) {
        gameState[clickedCellIndex] = "X";
        flag = 0;
    } else {
        gameState[clickedCellIndex] = "O";
        flag = 1;
    }
    
    for (var i:number = 0; i <= 8; i++) {

        (<HTMLInputElement>document.getElementById(i.toString())).value = gameState[i];
        if (gameState[i] !== ''){
            (<HTMLInputElement>document.getElementById(i.toString())).disabled = true;
        } else {
            (<HTMLInputElement>document.getElementById(i.toString())).disabled = false;
        }

    }


    for (var j:number = 0; j <= 7; j++) {
        let winner = winningConditions[j];
        let a:string = gameState[winner[0]];
        let b:string = gameState[winner[1]];
        let c:string = gameState[winner[2]];

      
        if (a === 'X' && b === 'X' && c ==='X')  {
            //window.alert("WINNER 1"); 
            keepPlaying = false;
            document.getElementById('print').innerHTML = "Player 1 is the winner";
            return;
        } else if (a === 'O' && b === 'O' && c ==='O') {
            //window.alert("WINNER 2"); 
            document.getElementById('print').innerHTML = "Player 2 is the winner";    
            keepPlaying = false;
            return;
        } 
    }
    
    let roundDraw:number = 0;
    if (keepPlaying) {
        for (let a:number = 0; a < 9; a++){
            if ((gameState[a] == "X") || (gameState[a] == "O"))
               roundDraw++;
         }
    }
        
    if (roundDraw == 9) {
        document.getElementById('print').innerHTML = "Match Tie";
        //window.alert('Match Tie');
        return;
    }


    if (flag == 1) {
        document.getElementById('print').innerHTML = "Player X Turn";
    }
    else {
        document.getElementById('print').innerHTML = "Player 0 Turn";
    }

    return;
 }
  
// Function to reset game
function myfunc_2() {
    location.reload();
    for (var i:number = 0; i <= 8; i++) {

        (<HTMLInputElement>document.getElementById(i.toString())).value = '';  
        (<HTMLInputElement>document.getElementById(i.toString())).disabled = false;
    }

    document.getElementById('print').innerHTML = "Player X Turn";
}
  
// Here onwards, functions check turn of the player 
// and put accordingly value X or 0
 let flag:number = 1;
document.querySelectorAll('.cell').forEach(function (cell) { return cell.addEventListener('click', myfunc); });
