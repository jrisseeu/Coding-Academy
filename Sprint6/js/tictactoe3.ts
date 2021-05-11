export{}
// Function called whenever user tab on any box
function myfunc() {
  
    // Setting DOM to all boxes or input field
    
    let b1:string = (<HTMLInputElement>document.getElementById("b1")).value;
    let b2:string = (<HTMLInputElement>document.getElementById("b2")).value;
    let b3:string = (<HTMLInputElement>document.getElementById("b3")).value;
    let b4:string = (<HTMLInputElement>document.getElementById("b4")).value;
    let b5:string = (<HTMLInputElement>document.getElementById("b5")).value;
    let b6:string = (<HTMLInputElement>document.getElementById("b6")).value;
    let b7:string = (<HTMLInputElement>document.getElementById("b7")).value;
    let b8:string = (<HTMLInputElement>document.getElementById("b8")).value;
    let b9:string = (<HTMLInputElement>document.getElementById("b9")).value;
  
    // Checking if Player X won or not and after 
    // that disabled all the other fields
    if ((b1 == 'X') && (b2 == 'X') && (b3 == 'X')) {
            document.getElementById('print').innerHTML = "Player X won";
            (<HTMLInputElement>document.getElementById("b4")).disabled = true;
            (<HTMLInputElement>document.getElementById("b4")).disabled = true;
            (<HTMLInputElement>document.getElementById("b5")).disabled = true;
            (<HTMLInputElement>document.getElementById("b6")).disabled = true;
            (<HTMLInputElement>document.getElementById("b7")).disabled = true;
            (<HTMLInputElement>document.getElementById("b8")).disabled = true;
            (<HTMLInputElement>document.getElementById("b9")).disabled = true;
        window.alert('Player X won');
    }
    else if ((b1 == 'X') && (b4 == 'X') && (b7 == 'X')) {
        document.getElementById('print').innerHTML = "Player X won";
        (<HTMLInputElement>document.getElementById("b2")).disabled = true;
        (<HTMLInputElement>document.getElementById("b3")).disabled = true;
        (<HTMLInputElement>document.getElementById("b5")).disabled = true;
        (<HTMLInputElement>document.getElementById("b6")).disabled = true;
        (<HTMLInputElement>document.getElementById("b8")).disabled = true;
        (<HTMLInputElement>document.getElementById("b9")).disabled = true;
  
        window.alert('Player X won');
    }
    else if ((b7 == 'X') && (b8 == 'X') && (b9 == 'X')) {
        document.getElementById('print').innerHTML = "Player X won";
        (<HTMLInputElement>document.getElementById("b1")).disabled = true;
        (<HTMLInputElement>document.getElementById("b2")).disabled = true;
        (<HTMLInputElement>document.getElementById("b3")).disabled = true;
        (<HTMLInputElement>document.getElementById("b4")).disabled = true;
        (<HTMLInputElement>document.getElementById("b5")).disabled = true;
        (<HTMLInputElement>document.getElementById("b6")).disabled = true;
        window.alert('Player X won');
    }
    else if ((b3 == 'X') && (b6 == 'X') && (b9 == 'X')) {
        document.getElementById('print').innerHTML = "Player X won";
        (<HTMLInputElement>document.getElementById("b1")).disabled = true;
        (<HTMLInputElement>document.getElementById("b2")).disabled = true;
        (<HTMLInputElement>document.getElementById("b4")).disabled = true;
        (<HTMLInputElement>document.getElementById("b5")).disabled = true;
        (<HTMLInputElement>document.getElementById("b7")).disabled = true;
        (<HTMLInputElement>document.getElementById("b8")).disabled = true;
        window.alert('Player X won');
    }
    else if ((b1 == 'X') && (b5 == 'X') && (b9 == 'X')) {
        document.getElementById('print').innerHTML = "Player X won";
        (<HTMLInputElement>document.getElementById("b2")).disabled = true;
        (<HTMLInputElement>document.getElementById("b3")).disabled = true;
        (<HTMLInputElement>document.getElementById("b4")).disabled = true;
        (<HTMLInputElement>document.getElementById("b6")).disabled = true;
        (<HTMLInputElement>document.getElementById("b7")).disabled = true;
        (<HTMLInputElement>document.getElementById("b8")).disabled = true;
        window.alert('Player X won');
    }
    else if ((b3 == 'X') && (b5 == 'X') && (b7 == 'X')) {
        document.getElementById('print').innerHTML = "Player X won";
        (<HTMLInputElement>document.getElementById("b1")).disabled = true;
        (<HTMLInputElement>document.getElementById("b2")).disabled = true;
        (<HTMLInputElement>document.getElementById("b4")).disabled = true;
        (<HTMLInputElement>document.getElementById("b6")).disabled = true;
        (<HTMLInputElement>document.getElementById("b8")).disabled = true;
        (<HTMLInputElement>document.getElementById("b9")).disabled = true;
        window.alert('Player X won');
    }
    else if ((b2 == 'X') && (b5 == 'X') && (b8 == 'X')) {
        document.getElementById('print').innerHTML = "Player X won";
            (<HTMLInputElement>document.getElementById("b1")).disabled = true;
            (<HTMLInputElement>document.getElementById("b3")).disabled = true;
            (<HTMLInputElement>document.getElementById("b4")).disabled = true;
            (<HTMLInputElement>document.getElementById("b6")).disabled = true;
            (<HTMLInputElement>document.getElementById("b7")).disabled = true;
            (<HTMLInputElement>document.getElementById("b9")).disabled = true;
        window.alert('Player X won');
    }
    else if ((b4 == 'X') && (b5 == 'X') && (b6 == 'X')) {
        document.getElementById('print').innerHTML = "Player X won";
            (<HTMLInputElement>document.getElementById("b1")).disabled = true;
            (<HTMLInputElement>document.getElementById("b2")).disabled = true;
            (<HTMLInputElement>document.getElementById("b3")).disabled = true;
            (<HTMLInputElement>document.getElementById("b7")).disabled = true;
            (<HTMLInputElement>document.getElementById("b8")).disabled = true;
            (<HTMLInputElement>document.getElementById("b9")).disabled = true;
        window.alert('Player X won');
    }
  
    // Checking of Player X finsh
    // Checking for Player 0 starts, Is player 0 won or
    // not and after that disabled all the other fields
    else if ((b1 == 'O' ) && (b2 == 'O' ) && (b3 == 'O' )) {
        document.getElementById('print').innerHTML = "Player 0 won";
            (<HTMLInputElement>document.getElementById("b4")).disabled = true;
            (<HTMLInputElement>document.getElementById("b5")).disabled = true;
            (<HTMLInputElement>document.getElementById("b6")).disabled = true;
            (<HTMLInputElement>document.getElementById("b7")).disabled = true;
            (<HTMLInputElement>document.getElementById("b8")).disabled = true;
            (<HTMLInputElement>document.getElementById("b9")).disabled = true;
        window.alert('Player 0 won');
    }
    else if ((b1 == 'O') && (b4 == 'O' ) && (b7 == 'O' )) {
            (<HTMLInputElement>document.getElementById("b2")).disabled = true;
            (<HTMLInputElement>document.getElementById("b3")).disabled = true;
            (<HTMLInputElement>document.getElementById("b5")).disabled = true;
            (<HTMLInputElement>document.getElementById("b6")).disabled = true;
            (<HTMLInputElement>document.getElementById("b8")).disabled = true;
            (<HTMLInputElement>document.getElementById("b9")).disabled = true;
            document.getElementById('print').innerHTML = "Player 0 won";
            window.alert('Player 0 won');
    }
    else if ((b7 == 'O') && (b8 == 'O' ) && (b9 == 'O' )) {
        
            (<HTMLInputElement>document.getElementById("b1")).disabled = true;
            (<HTMLInputElement>document.getElementById("b2")).disabled = true;
            (<HTMLInputElement>document.getElementById("b3")).disabled = true;
            (<HTMLInputElement>document.getElementById("b4")).disabled = true;
            (<HTMLInputElement>document.getElementById("b5")).disabled = true;
            (<HTMLInputElement>document.getElementById("b6")).disabled = true;
        document.getElementById('print').innerHTML = "Player 0 won";
        window.alert('Player 0 won');
    }
    else if ((b3 == 'O' ) && (b6 == 'O' ) && (b9 == 'O' )) {
            (<HTMLInputElement>document.getElementById("b1")).disabled = true;
            (<HTMLInputElement>document.getElementById("b2")).disabled = true;
            (<HTMLInputElement>document.getElementById("b4")).disabled = true;
            (<HTMLInputElement>document.getElementById("b5")).disabled = true;
            (<HTMLInputElement>document.getElementById("b7")).disabled = true;
            (<HTMLInputElement>document.getElementById("b8")).disabled = true;
        document.getElementById('print').innerHTML = "Player 0 won";
        window.alert('Player 0 won');
    }
    else if ((b1 == 'O' ) && (b5 == 'O') && (b9 == 'O' )) {
        document.getElementById('print').innerHTML = "Player 0 won";
            (<HTMLInputElement>document.getElementById("b2")).disabled = true;
            (<HTMLInputElement>document.getElementById("b3")).disabled = true;
            (<HTMLInputElement>document.getElementById("b4")).disabled = true;
            (<HTMLInputElement>document.getElementById("b6")).disabled = true;
            (<HTMLInputElement>document.getElementById("b7")).disabled = true;
            (<HTMLInputElement>document.getElementById("b8")).disabled = true;
        window.alert('Player 0 won');
    }
    else if ((b3 == 'O' ) && (b5 == 'O' ) && (b7 == 'O' )) {
        document.getElementById('print').innerHTML = "Player 0 won";
            (<HTMLInputElement>document.getElementById("b1")).disabled = true;
            (<HTMLInputElement>document.getElementById("b2")).disabled = true;
            (<HTMLInputElement>document.getElementById("b4")).disabled = true;
            (<HTMLInputElement>document.getElementById("b6")).disabled = true;
            (<HTMLInputElement>document.getElementById("b8")).disabled = true;
            (<HTMLInputElement>document.getElementById("b9")).disabled = true;
        window.alert('Player 0 won');
    }
    else if ((b2 == 'O' ) && (b5 == 'O' ) && (b8 == 'O')) {
        document.getElementById('print').innerHTML = "Player 0 won";
            (<HTMLInputElement>document.getElementById("b1")).disabled = true;
            (<HTMLInputElement>document.getElementById("b3")).disabled = true;
            (<HTMLInputElement>document.getElementById("b4")).disabled = true;
            (<HTMLInputElement>document.getElementById("b6")).disabled = true;
            (<HTMLInputElement>document.getElementById("b7")).disabled = true;
            (<HTMLInputElement>document.getElementById("b9")).disabled = true;
        window.alert('Player 0 won');
    }
    else if ((b4 == 'O' ) && (b5 == 'O' ) && (b6 == 'O' )) {
        document.getElementById('print').innerHTML = "Player 0 won";
            (<HTMLInputElement>document.getElementById("b1")).disabled = true;
            (<HTMLInputElement>document.getElementById("b2")).disabled = true;
            (<HTMLInputElement>document.getElementById("b3")).disabled = true;
            (<HTMLInputElement>document.getElementById("b7")).disabled = true;
            (<HTMLInputElement>document.getElementById("b8")).disabled = true;
            (<HTMLInputElement>document.getElementById("b9")).disabled = true;
        window.alert('Player 0 won');
    }
  
    // Checking of Player 0 finsh
    // Here, Checking about Tie
    else if ((b1 == 'X' || b1 == 'O') && (b2 == 'X' || b2 == 'O') && (b3 == 'X' || b3 == 'O') && 
             (b4 == 'X' || b4 == 'O') && (b5 == 'X' || b5 == 'O') && (b6 == 'X' || b6 == 'O') && 
             (b7 == 'X' || b7 == 'O') && (b8 == 'X' || b8 == 'O') && (b9 == 'X' || b9 == 'O')) {
                 
            document.getElementById('print').innerHTML = "Match Tie";
            window.alert('Match Tie');
    }
    else {
  
        // Here, Printing Result
        if (flag == 1) {
            document.getElementById('print').innerHTML = "Player X Turn";
        }
        else {
            document.getElementById('print').innerHTML = "Player 0 Turn";
        }
    }
}
  
// Function to reset game
function myfunc_2() {
    location.reload();
    (<HTMLInputElement>document.getElementById('b1')).value = '';
    (<HTMLInputElement>document.getElementById("b2")).value = '';
    (<HTMLInputElement>document.getElementById("b3")).value = '';
    (<HTMLInputElement>document.getElementById("b4")).value = '';
    (<HTMLInputElement>document.getElementById("b5")).value = '';
    (<HTMLInputElement>document.getElementById("b6")).value = '';
    (<HTMLInputElement>document.getElementById("b7")).value = '';
    (<HTMLInputElement>document.getElementById("b8")).value = '';
    (<HTMLInputElement>document.getElementById("b9")).value = '';
  
}
  
// Here onwards, functions check turn of the player 
// and put accordingly value X or 0
 let flag:number = 1;
function myfunc_3() {
    if (flag == 1) {
        (<HTMLInputElement>document.getElementById("b1")).value = "X";
        (<HTMLInputElement>document.getElementById("b1")).disabled = true;
        flag = 0;
    }
    else {
        (<HTMLInputElement>document.getElementById("b1")).value = "O";
        (<HTMLInputElement>document.getElementById("b1")).disabled = true;
        flag = 1;
    }
}
  
function myfunc_4() {
    if (flag == 1) {
        (<HTMLInputElement>document.getElementById("b2")).value = "X";
        (<HTMLInputElement>document.getElementById("b2")).disabled = true;
        flag = 0;
    }
    else {
        (<HTMLInputElement>document.getElementById("b2")).value = "O";
        (<HTMLInputElement>document.getElementById("b2")).disabled = true;
        flag = 1;
    }
}
  
function myfunc_5() {
    if (flag == 1) {
        (<HTMLInputElement>document.getElementById("b3")).value = "X";
        (<HTMLInputElement>document.getElementById("b3")).disabled = true;
        flag = 0;
    }
    else {
        (<HTMLInputElement>document.getElementById("b3")).value = "O";
        (<HTMLInputElement>document.getElementById("b3")).disabled = true;
        flag = 1;
    }
}
  
function myfunc_6() {
    if (flag == 1) {
        (<HTMLInputElement>document.getElementById("b4")).value = "X";
        (<HTMLInputElement>document.getElementById("b4")).disabled = true;
        flag = 0;
    }
    else {
        (<HTMLInputElement>document.getElementById("b4")).value = "O";
        (<HTMLInputElement>document.getElementById("b4")).disabled = true;
        flag = 1;
    }
}
  
function myfunc_7() {
    if (flag == 1) {
        (<HTMLInputElement>document.getElementById("b5")).value = "X";
        (<HTMLInputElement>document.getElementById("b5")).disabled = true;
        flag = 0;
    }
    else {
        (<HTMLInputElement>document.getElementById("b5")).value = "O";
        (<HTMLInputElement>document.getElementById("b5")).disabled = true;
        flag = 1;
    }
}
  
function myfunc_8() {
    if (flag == 1) {
        (<HTMLInputElement>document.getElementById("b6")).value = "X";
        (<HTMLInputElement>document.getElementById("b6")).disabled = true;
        flag = 0;
    }
    else {
        (<HTMLInputElement>document.getElementById("b6")).value = "O";
        (<HTMLInputElement>document.getElementById("b6")).disabled = true;
        flag = 1;
    }
}
  
function myfunc_9() {
    if (flag == 1) {
        (<HTMLInputElement>document.getElementById("b7")).value = "X";
        (<HTMLInputElement>document.getElementById("b7")).disabled = true;
        flag = 0;
    }
    else {
        (<HTMLInputElement>document.getElementById("b7")).value = "O";
        (<HTMLInputElement>document.getElementById("b7")).disabled = true;
        flag = 1;
    }
}
  
function myfunc_10() {
    if (flag == 1) {
        (<HTMLInputElement>document.getElementById("b8")).value = "X";
        (<HTMLInputElement>document.getElementById("b8")).disabled = true;
        flag = 0;
    }
    else {
        (<HTMLInputElement>document.getElementById("b8")).value = "O";
        (<HTMLInputElement>document.getElementById("b8")).disabled = true;
        flag = 1;
    }
}
  
function myfunc_11() {
    if (flag == 1) {
        (<HTMLInputElement>document.getElementById("b9")).value = "X";
        (<HTMLInputElement>document.getElementById("b9")).disabled = true;
        flag = 0;
    }
    else {
        (<HTMLInputElement>document.getElementById("b9")).value = "O";
        (<HTMLInputElement>document.getElementById("b9")).disabled = true;
        flag = 1;
    }
}