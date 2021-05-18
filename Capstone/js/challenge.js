var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
var lettersToUse = ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"];
var wordInfo = "";
var lettersUsed = [];
var wordToUse = [];
var wordDisplay = [];
var lettersLeft = document.getElementById('lettersLeft');
var ltrsUsed = document.getElementById('lettersUsed');
var wrongGuessCount = 0;
var maxWrongGuess = 10;
eventListeners();
function eventListeners() {
    //Creates the click event for the Remove tasks from completed tasks section
    lettersLeft.addEventListener('click', loadLettersLeftArray);
}
function newGame() {
    wordToUse = [];
    wordDisplay = [];
    lettersUsed = [];
    wrongGuessCount = 0;
    wordInfo = "";
    document.getElementById("hiddenWord").innerHTML = "";
    document.getElementById("lettersLeft").innerHTML = "";
    document.getElementById("lettersUsed").innerHTML = "";
    startTheGame();
}
function startTheGame() {
    return __awaiter(this, void 0, void 0, function () {
        var wordCategory, apiUrl, response, myObj, myObjStr, prsed, theWord, wordLength, index;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    wordToUse = [];
                    wordDisplay = [];
                    wordInfo = "";
                    wordCategory = document.getElementById('standard-select').value;
                    if (wordCategory == "Noun") {
                        apiUrl = "https://random-word-form.herokuapp.com/random/noun";
                    }
                    else if (wordCategory == "Adjective") {
                        apiUrl = "https://random-word-form.herokuapp.com/random/adjective";
                    }
                    else if (wordCategory == "Animal") {
                        apiUrl = "https://random-word-form.herokuapp.com/random/animal";
                    }
                    else {
                        window.alert("Select a category");
                        return [2 /*return*/];
                    }
                    return [4 /*yield*/, fetch(apiUrl)];
                case 1:
                    response = _a.sent();
                    if (!(response.status >= 200 && response.status <= 299)) return [3 /*break*/, 3];
                    return [4 /*yield*/, response.json()];
                case 2:
                    myObj = _a.sent();
                    return [3 /*break*/, 4];
                case 3:
                    alert("failed call" + response.status + " status text " + response.statusText);
                    return [2 /*return*/, false];
                case 4:
                    myObjStr = JSON.stringify(myObj);
                    prsed = JSON.parse(myObjStr);
                    theWord = prsed.toString().toUpperCase();
                    wordLength = prsed.toString().length;
                    wordInfo = theWord;
                    for (index = 0; index < wordLength; index++) {
                        wordToUse.push("_");
                        wordDisplay.push(theWord[index]);
                    }
                    getWordDefinition(theWord);
                    setupLettersAvailable();
                    cleanUpHiddenWord();
                    document.getElementById("lettersUsed").innerHTML = "";
                    document.getElementById("hangman").innerHTML = formatImage("../images/0.jpg");
                    return [2 /*return*/, true];
            }
        });
    });
}
//setups the letters available section of the screen with the list of letters that can be used
function setupLettersAvailable() {
    //Create <li>
    var li = document.createElement('li');
    li.textContent = "";
    //clear the LI when starting/restarting
    clearLiFromList();
    //append the LI back onto the DOM
    lettersLeft.appendChild(li);
    for (var index = 0; index < lettersToUse.length; index++) {
        var checkBtn = document.createElement('a');
        checkBtn.classList.add('letters-to-use');
        var letter = lettersToUse[index];
        checkBtn.textContent = ' ' + letter + ' ';
        li.appendChild(checkBtn);
    }
    lettersLeft.classList.value = 'lettersLeft';
}
//clear the LI when starting/restarting
function clearLiFromList() {
    while (lettersLeft.firstChild) {
        lettersLeft.removeChild(lettersLeft.firstChild);
    }
}
//builds the letters used section of the screen.
function doLetterUsedWork() {
    var ltrUsedDisplay = "";
    for (var index = 0; index < lettersUsed.length; index++) {
        ltrUsedDisplay += " " + lettersUsed[index];
    }
    document.getElementById("lettersUsed").innerHTML = ltrUsedDisplay;
}
//Loops through the letters used list and letters available and creates a new list 
//of letters available to be used.
function updateLettersAvailableList() {
    var retVal = [];
    for (var index = 0; index < lettersToUse.length; index++) {
        var availLtr = lettersToUse[index];
        var found = false;
        for (var i = 0; i < lettersUsed.length; i++) {
            var sel = lettersUsed[i].trim();
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
    var ltrToPlay = elmnt.target.textContent;
    //add the letter the user just selected to the letters Used Array.
    lettersUsed.push(ltrToPlay);
    lettersUsed.sort();
    //Build the letters used section of the screen.
    doLetterUsedWork();
    //Remove the letters played from the Letters available to play
    var letters = updateLettersAvailableList();
    clearLiFromList();
    //Create the links for the available letters that the user can select.
    var li = document.createElement('li');
    li.textContent = "";
    lettersLeft.appendChild(li);
    for (var index = 0; index < letters.length; index++) {
        var checkBtn = document.createElement('a');
        checkBtn.classList.add('letters-to-use');
        var letter = letters[index];
        checkBtn.textContent = ' ' + letter + ' ';
        li.appendChild(checkBtn);
    }
    lettersLeft.classList.value = letters.toString();
    isLetterInWord(ltrToPlay);
}
//Check to see if the selected letter is in the word being guessed
function isLetterInWord(playedLetter) {
    var playedFound = false;
    for (var index = 0; index < wordDisplay.length; index++) {
        var displayLetter = wordDisplay[index];
        var found = false;
        if (playedLetter.trim() == displayLetter) {
            found = true;
            playedFound = true;
        }
        if (found) {
            wordToUse[index] = playedLetter;
        }
    }
    if (!playedFound) {
        wrongGuessCount++;
    }
    //Loop through the word to use and create a nice set of fields
    cleanUpHiddenWord();
    var imgLink = "../images/" + wrongGuessCount + ".jpg";
    document.getElementById("hangman").innerHTML = formatImage(imgLink);
    if (allLetterSlotsFilled()) {
        window.alert("Congratulations, you solved the word");
        //newGame();
    }
    if (maxWrongGuess == wrongGuessCount) {
        window.alert("Sorry, max number of wrong guesses met for word > " + wordInfo);
        //newGame();
    }
}
function formatImage(string) {
    var link = '<img src=' + string + ' style="width:150px;">';
    link += '<br> <br> ' + wrongGuessCount + ' of ' + maxWrongGuess + ' wrong tries';
    return link;
}
function cleanUpHiddenWord() {
    var displayed = "";
    for (var index = 0; index < wordToUse.length; index++) {
        displayed += wordToUse[index] + " ";
    }
    document.getElementById("hiddenWord").innerHTML = displayed;
}
function allLetterSlotsFilled() {
    var winner = false;
    for (var index = 0; index < wordToUse.length; index++) {
        if (!validateLetters(wordToUse[index])) {
            return false;
        }
        else {
            winner = true;
        }
    }
    return winner;
}
function validateLetters(x) {
    var str = x.trim();
    var pattern = /^[A-Za-z]+$/;
    return str.match(pattern);
}
function getWordDefinition(theWord) {
    return __awaiter(this, void 0, void 0, function () {
        var apiURL2, defResponse, defObj, theDef, defObString, prsed, para, theQuoteInfo;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    apiURL2 = "https://api.datamuse.com/words?sp=" + theWord + "&md=d";
                    return [4 /*yield*/, fetch(apiURL2)];
                case 1:
                    defResponse = _a.sent();
                    theDef = "";
                    if (!(defResponse.status >= 200 && defResponse.status <= 299)) return [3 /*break*/, 3];
                    return [4 /*yield*/, defResponse.json()];
                case 2:
                    defObj = _a.sent();
                    return [3 /*break*/, 4];
                case 3:
                    alert("failed call" + defObj.status + " status text " + defObj.statusText);
                    return [2 /*return*/, ""];
                case 4:
                    defObString = JSON.stringify(defObj);
                    prsed = JSON.parse(defObString);
                    for (para in prsed) {
                        theDef = prsed[para].defs;
                        try {
                            theDef = theDef.toString().replace(/(\r\n|\n|\r|\,n)/gm, " ");
                        }
                        catch (error) {
                            theDef = "";
                        }
                        break;
                    }
                    if (theDef == "") {
                        theDef = "No definition found";
                        document.getElementById("definition").innerHTML = theDef;
                    }
                    else {
                        theQuoteInfo = createResponse(theWord, theDef);
                        document.getElementById("definition").innerHTML = theQuoteInfo;
                    }
                    return [2 /*return*/, theDef];
            }
        });
    });
}
function createResponse(theWord, theDefinition) {
    var theDef = "";
    for (var index = 2; index < theDefinition.length; index++) {
        theDef += theDefinition[index];
    }
    //var resp1 = "<p> <b>Word: </b>" + theWord +"</p>";
    var resp1 = "<p>" + theDef + "</p>";
    return resp1;
}
