function validateEntry() {
    var word = document.getElementById("theWord").value;
    var number = document.getElementById("theNumber").value;
    
    if (null == validateLetters(word)) {
        alert("Please enter a valid alphanumeric word");
        return false;
    } 

    if (null == validateNumber(number)) {
        alert("Please enter either a 1 or 2");
        return false;
    } 

    if (number == 1) {
        var table1 = document.getElementById("list1");
        table1.insertRow(table1.rows.length).innerHTML = word;
        
    } else {
        var table2 = document.getElementById("list2");
        table2.insertRow(table2.rows.length).innerHTML = word;
        
    }
    
    document.getElementById('theWord').value = '';
    document.getElementById('theNumber').value = '';
    
    return true;

}

function validateNumber(x) {
    var str = x;
    var pattern = /[1-2]/g;
    var result = str.match(pattern);
    return result;
}

function validateLetters(x) {
    var str = x;
    var pattern = /^[A-Za-z]+$/;
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
