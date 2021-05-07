function validateEntry() {
    var word = document.getElementById("theWord").value;
    var number = document.getElementById("theNumber").valueAsNumber;
    var caseSens = document.getElementById("byCase").checked;
    var origWord = word;
    if (!caseSens) {
        word = word.toLowerCase();
    }
    if (null == validateLetters(word)) {
        alert("Please enter a valid alphanumeric word");
        return false;
    }
    if (null == validateNumber(number)) {
        alert("Please enter either a 1 or 2");
        return false;
    }
    if (number == 1) {
        var result = isWordOnePalindrome(word);
        var table1 = document.getElementById("list1");
        table1.insertRow(table1.rows.length).innerHTML = origWord + ": " + result;
    }
    else {
        var result = isWordTwoPalindrome2(word);
        var table2 = document.getElementById("list2");
        table2.insertRow(table2.rows.length).innerHTML = origWord + ": " + result;
    }
    document.getElementById('theWord').value = '';
    document.getElementById('theNumber').value = '';
    document.getElementById("byCase").checked = true;
    return true;
}
//Split with "" tells to split between characters seperated by commas
//reverse - reverses the text
//Join wiht "" tells to join the string back with the commas being the separator
//alert(x.split(""));
//alert(x.split("").reverse());
//alert(x.split("").reverse().join(""));
function isWordOnePalindrome(x) {
    return doesTextMatch(x, x.split("").reverse().join(""));
}
function isWordTwoPalindrome2(x) {
    return doesTextMatch(x, reverseInputString(x));
}
function doesTextMatch(x, y) {
    if (x == y) {
        return true;
    }
    else {
        return false;
    }
}
// Loop through the string backwards from the end of the string 
//  !!!! NOTE: JS starts at zero so we need to subtract 1 from the length
//  otherwise you get an undefined for the first value 
function reverseInputString(str) {
    var returnVal = "";
    for (var i = str.length - 1; i >= 0; i--) {
        returnVal += str[i];
    }
    return returnVal;
}
function validateNumber(str) {
    var pattern = /[1-2]/g;
    return str.toString().match(pattern);
}
function validateLetters(str) {
    var pattern = /^[A-Za-z]+$/;
    return str.match(pattern);
}
function clearList1() {
    // clear the table of all rows
    document.getElementById('list1').innerHTML = "";
}
function clearList2() {
    // clear the table of all rows
    document.getElementById('list2').innerHTML = "";
}
