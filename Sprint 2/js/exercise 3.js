function validateEntry() {
    var min = document.getElementById("minNumber").value;
    var max = document.getElementById("maxNumber").value;
    var theNumber = document.getElementById("theNumber").value;
   
          
    if (!validateNumber(min)) {
        alert("Please enter a starting number thta is > 0");
        return false;
    } 


    if (!validateNumber(max)) {
        alert("Please enter a maximum number that is >");
        return false;
    } 

    if (Number(theNumber) <= Number(min)) {
         alert("Number entered has has to be > " + min );
         return false;
    } 

    if (Number(theNumber) >= Number(max)) {
        alert("Number entered has has to be < " +max);
        return false;
   } 

    var table1 = document.getElementById("list1");
    table1.insertRow(table1.rows.length).innerHTML = theNumber;
    
   

    document.getElementById("mean").innerHTML = getMean(table1);
    document.getElementById("median").innerHTML = getMedian(table1);
    document.getElementById("modes").innerHTML = simpleMode(table1);

    //Clear the number they enter for the next entry
    document.getElementById('theNumber').value = '';

    return true;
   
}

function getMode(x) {

    if (x.rows.length == 1) {
        return parseInt((x.rows[0]).innerHTML);
    }

    var numsCnt = x.rows.length;
    var array = [];
    for (i=0; i < numsCnt; i++) {
     array.push((x.rows[i]).innerHTML);
    }

}

function simpleMode(array) { 

    return 1222;
}


function getMedian(x) {

    if (x.rows.length == 1) {
        return parseInt((x.rows[0]).innerHTML);
    }
    
    var numsCnt = x.rows.length;
    var array = [];
    for (i=0; i < numsCnt; i++) {
     array.push((x.rows[i]).innerHTML);
    }

    array.sort(function(a, b){return a - b});
    
    //Round the length down to the closest number 
    //and divide in half to get the midpoint of the array
    var half = Math.floor(array.length/2);
    
    //If the array length is divisible by 2, get the value from the half way point
    if(array.length % 2) {
        return array[half];
    } else {
        var val1 = array[half-1];
        var val2 = array[half];
        return ((Number(val1) + Number(val2)) / 2); 
    }
}

function getMean(x) {
    var numsCnt = x.rows.length;
    var sum = 0;

    for (i=0; i < numsCnt; i++) {
     sum += parseInt((x.rows[i]).innerHTML);
    }

    var mean = (sum / numsCnt);
    return mean;
}

function validateNumber(x) {
    var str = x;
    var pattern = /[1-9999999999]/g;
    var result = str.match(pattern);
    return result;
}


function clearList1() {
    // clear the table of all rows
    var tableRef = document.getElementById("list1");
    tableRef.innerHTML = " ";
  }

  function clearList2() {
    // clear the table of all rows
    var tableRef = document.getElementById("list2");
    tableRef.innerHTML = " ";
  }
