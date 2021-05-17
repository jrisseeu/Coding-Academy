let lettersToUse = ["A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"];
let wordInfo:string ="";
let lettersUsed  = [];
let wordToUse = [];
let wordDisplay = [];
let lettersLeft:HTMLElement = (<HTMLElement> document.getElementById('lettersLeft'));
let ltrsUsed:HTMLElement = (<HTMLElement> document.getElementById('lettersUsed'));
let wrongGuessCount:number = 0;
const maxWrongGuess:number = 6;

eventListeners();

function eventListeners() {
 
    //Form Submission listener
    //document.querySelector('#form').addEventListener('submit', letterEntered);

    //Creates the click event for the Remove tasks from completed tasks section
    lettersLeft.addEventListener('click', loadLettersLeftArray);

}

function newGame() {
    wordToUse = [];
    wordDisplay = [];
    lettersUsed = [];
    wrongGuessCount = 0;
    wordInfo = "";
    document.getElementById("jsonResp").innerHTML = "";
    document.getElementById("hiddenWord").innerHTML = "";
    //document.getElementById("wordList").innerHTML =  "";
    document.getElementById("lettersLeft").innerHTML = "";
    document.getElementById("lettersUsed").innerHTML = "";
    startTheGame();
}

async function startTheGame() {
        
    wordToUse = [];
    wordDisplay = [];
    wordInfo = "";
    var apiUrl = "https://random-words-api.vercel.app/word";
    var response = await fetch(apiUrl);
    var myObj;

    if (response.status >= 200 && response.status <= 299) {
        myObj = await response.json();
    } else {
        alert("failed call" +response.status + " status text " + response.statusText);
        return false;
    } 

    
    var myObjStr = JSON.stringify(myObj);
    var prsed = JSON.parse(myObjStr);
  
    let theQuoteInfo;
    let wordLength;
    for (var para in prsed) {
        theQuoteInfo = createResponse(prsed[para].word.toUpperCase(), prsed[para].definition);
        wordLength = prsed[para].word.length;
        wordInfo = prsed[para].word;
       for (let index = 0; index < wordLength; index++) {
          wordToUse.push("_");
          wordDisplay.push(wordInfo[index].toUpperCase());
        }   
    }

    setupLettersAvailable();
    cleanUpHiddenWord();

    document.getElementById("lettersUsed").innerHTML = "";
    document.getElementById("jsonResp").innerHTML =  theQuoteInfo;
    
    return true;

}

function createResponse(theWord, theDefinition) {

    //var resp1 = "<p> <b>Word: </b>" + theWord +"</p>";
    var resp1 = "<p>" + theDefinition + "</p>";

    return resp1;
}

//setups the letters available section of the screen with the list of letters that can be used
function setupLettersAvailable() {

  //Create <li>
  let li:HTMLElement = (<HTMLElement> document.createElement('li'));
  li.textContent = "";

  //clear the LI when starting/restarting
  while(lettersLeft.firstChild){
    lettersLeft.removeChild(lettersLeft.firstChild);
  }

  //append the LI back onto the DOM
  lettersLeft.appendChild(li);

  for (let index = 0; index < lettersToUse.length; index++) {
    let checkBtn:HTMLElement = (<HTMLElement> document.createElement('a'));
    checkBtn.classList.add('letters-to-use');
    let letter:string = lettersToUse[index];
    checkBtn.textContent = ' ' + letter + ' ';
    li.appendChild(checkBtn);
  }  

 
  lettersLeft.classList.value ='lettersLeft';

}

function clearLiFromList() {
    //clear the LI when starting/restarting
  while(lettersLeft.firstChild){
    lettersLeft.removeChild(lettersLeft.firstChild);
  }

}

//builds the letters used section of the screen.
function doLetterUsedWork() {

    let ltrUsedDisplay = "";
    for (let index = 0; index < lettersUsed.length; index++) {
        ltrUsedDisplay += " " + lettersUsed[index];
    }  
    document.getElementById("lettersUsed").innerHTML = ltrUsedDisplay;
}

//Loops through the letters used list and letters available and creates a new list 
//of letters available to be used.
function updateLettersAvailableList() {

    let retVal = [];

    for (let index = 0; index < lettersToUse.length; index++) {
        let availLtr = lettersToUse[index];

        let found = false;
        for (let i = 0; i < lettersUsed.length; i++) {
            let sel:string = lettersUsed[i].trim();

            if (availLtr == sel) {
                found = true;
            }
        } 
        if (!found) {
            retVal.push(availLtr);
        }
    }
    return retVal;
}

//Function is called when the user clicks on the letter to play
function loadLettersLeftArray(elmnt) {

    let ltrToPlay:string = elmnt.target.textContent;  

    //add the letter the user just selected to the letters Used Array.
    lettersUsed.push(ltrToPlay);
    lettersUsed.sort();
  
    //Build the letters used section of the screen.
    doLetterUsedWork();

    //Remove the letters played from the Letters available to play
    let letters = updateLettersAvailableList();
    clearLiFromList();

    //Create the links for the available letters that the user can select.
    let li:HTMLElement = (<HTMLElement> document.createElement('li'));
    li.textContent = "";

    lettersLeft.appendChild(li);

    for (let index = 0; index < letters.length; index++) {
        let checkBtn:HTMLElement = (<HTMLElement> document.createElement('a'));
        checkBtn.classList.add('letters-to-use');
        let letter:string = letters[index];
        checkBtn.textContent = ' ' + letter + ' ';
        li.appendChild(checkBtn);
    }  

    lettersLeft.classList.value = letters.toString();

    isLetterInWord(ltrToPlay);

}

//Check to see if the selected letter is in the word being guessed
function isLetterInWord(playedLetter:string) {

    let playedFound = false;
    for (let index:number = 0; index < wordDisplay.length; index++) {
        let displayLetter = wordDisplay[index];
        let found:boolean = false;
        if (playedLetter.trim() == displayLetter) {
            found = true;
            playedFound = true;
        }
        if (found) {
            wordToUse[index] = playedLetter;
        }
    }
    if (!playedFound){
        wrongGuessCount++;
    }
    
    //Loop through the word to use and create a nice set of fields
    cleanUpHiddenWord();

    
    if (allLetterSlotsFilled()) {
        window.alert("Congratulations, you solved the word");
    }

    if (maxWrongGuess == wrongGuessCount) {
        window.alert("Sorry, max number of wrong guesses met for word > " +wordInfo);
    }

}

function cleanUpHiddenWord() {

    let displayed:string = "";
    for (let index:number = 0; index < wordToUse.length; index++) {

        displayed += wordToUse[index] + " ";
    }

    document.getElementById("hiddenWord").innerHTML = displayed;

}

function allLetterSlotsFilled():boolean {

    let winner = false;
    for (let index:number = 0; index < wordToUse.length; index++) {

        if(!validateLetters(wordToUse[index])){
            return false;
        } else {
            winner = true;
        }
        
    }

    return winner;

}

function validateLetters(x:string) {
    var str = x.trim();
    var pattern = /^[A-Za-z]+$/;
    return str.match(pattern);
}
