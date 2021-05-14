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
var maxWrongGuess = 6;
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
function startTheGame() {
    return __awaiter(this, void 0, void 0, function () {
        var apiUrl, response, myObj, myObjStr, prsed, theQuoteInfo, wordLength, para, index;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    wordToUse = [];
                    wordDisplay = [];
                    wordInfo = "";
                    apiUrl = "https://random-words-api.vercel.app/word";
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
                    for (para in prsed) {
                        theQuoteInfo = createResponse(prsed[para].word.toUpperCase(), prsed[para].definition);
                        wordLength = prsed[para].word.length;
                        wordInfo = prsed[para].word;
                        for (index = 0; index < wordLength; index++) {
                            wordToUse.push("_");
                            wordDisplay.push(wordInfo[index].toUpperCase());
                        }
                    }
                    setupLettersAvailable();
                    cleanUpHiddenWord();
                    document.getElementById("lettersUsed").innerHTML = "";
                    document.getElementById("jsonResp").innerHTML = theQuoteInfo;
                    return [2 /*return*/, true];
            }
        });
    });
}
function createResponse(theWord, theDefinition) {
    var resp1 = "<p> <b>Word: </b>" + theWord + "</p>";
    resp1 += "<p>" + theDefinition + "</p>";
    return resp1;
}
//setups the letters available section of the screen with the list of letters that can be used
function setupLettersAvailable() {
    //Create <li>
    var li = document.createElement('li');
    li.textContent = "";
    //clear the LI when starting/restarting
    while (lettersLeft.firstChild) {
        lettersLeft.removeChild(lettersLeft.firstChild);
    }
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
function clearLiFromList() {
    //clear the LI when starting/restarting
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
    if (allLetterSlotsFilled()) {
        window.alert("Congratulations, you solved the word");
    }
    if (maxWrongGuess == wrongGuessCount) {
        window.alert("Sorry, max number of wrong guesses met for word > " + wordInfo);
    }
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
