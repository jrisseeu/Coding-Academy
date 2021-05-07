function validateEntry() {
    var min = document.getElementById("minNumber").valueAsNumber;
    var max = document.getElementById("maxNumber").valueAsNumber;
    var theNumber = document.getElementById("theNumber").valueAsNumber;
    if (!validateNumber(min)) {
        alert("Please enter a starting number that is > 0");
        return false;
    }
    if (!validateNumber(max)) {
        alert("Please enter a maximum number that is > 0");
        return false;
    }
    if (theNumber < min) {
        alert("Number entered has to be >= minimum number of: " + min);
        return false;
    }
    if (theNumber > max) {
        alert("Number entered has to be <= maximum number of: " + max);
        return false;
    }
    //disable the buttons so the user cannot enter any changes
    document.getElementById("minNumber").disabled = true;
    document.getElementById("maxNumber").disabled = true;
    var table1 = document.getElementById("list1");
    table1.insertRow(table1.rows.length).innerHTML = theNumber.toString();
    document.getElementById("mean").innerHTML = getMean(table1);
    document.getElementById("median").innerHTML = getMedian(table1).toString();
    document.getElementById("modes").innerHTML = getTheMode(table1);
    //Clear the number they enter for the next entry
    document.getElementById('theNumber').value = '';
    return true;
}
function getTheMode(x) {
    if (x.rows.length == 1) {
        return (x.rows[0]).innerHTML;
    }
    var array = [];
    var a = 0;
    for (a = 0; a < x.rows.length; a++) {
        array.push(x.rows[a].innerHTML);
    }
    var frequency = {}; // array of frequency.
    var maxFreq = 0; // holds the max frequency.
    var modes = [];
    for (var i in array) {
        frequency[array[i]] = (frequency[array[i]] || 0) + 1; // increment frequency.
        if (frequency[array[i]] > maxFreq) { // is this frequency > max so far ?
            maxFreq = frequency[array[i]]; // update max.
        }
    }
    for (var k in frequency) {
        if (frequency[k] == maxFreq) {
            modes.push(k);
        }
    }
    return modes.toString();
}
function getMedian(x) {
    if (x.rows.length == 1) {
        return parseInt((x.rows[0]).innerHTML);
    }
    var numsCnt = x.rows.length;
    var array = [];
    var i = 0;
    for (i = 0; i < numsCnt; i++) {
        array.push((x.rows[i]).innerHTML);
    }
    //Not sure how this works, but W3 used this to sort numerically
    array.sort(function (a, b) { return a - b; });
    //Round the length down to the closest number 
    //and divide in half to get the midpoint of the array
    var half = Math.floor(array.length / 2);
    //If the array length is divisible by 2, get the value from the half way point
    if (array.length % 2) {
        return array[half];
    }
    else {
        var val1 = array[half - 1];
        var val2 = array[half];
        return ((Number(val1) + Number(val2)) / 2);
    }
}
function getMean(x) {
    var numsCnt = x.rows.length;
    var sum = 0;
    var i;
    for (i = 0; i < numsCnt; i++) {
        sum += parseInt((x.rows[i]).innerHTML);
    }
    var mean = (Number(sum) / Number(numsCnt));
    return mean.toString();
}
function validateNumber(str) {
    var pattern = /[1-9999999999]/g;
    return str.toString().match(pattern);
}
function clearEveryThing() {
    // clear the table of all rows
    document.getElementById('list1').innerHTML = "";
    document.getElementById("minNumber").disabled = false;
    document.getElementById("maxNumber").disabled = false;
    document.getElementById("minNumber").value = '';
    document.getElementById('maxNumber').value = '';
    document.getElementById('theNumber').value = '';
    document.getElementById("mean").value = 'tbd';
    document.getElementById("median").value = 'tbd';
    document.getElementById("modes").value = 'tbd';
}
