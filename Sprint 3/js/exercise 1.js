async function weHaveTheMeat() {
    var numParas = document.getElementById("paras").value;
    
    document.getElementById("formatJson").innerHTML = "";
    document.getElementById("jsonResp").innerHTML = "";

    var apiUrl = "https://baconipsum.com/api/?type=meat&paras=" + numParas;
    
    var response = await fetch(apiUrl);
    var myObj = await response.json();

    var jasonObj = JSON.stringify(myObj);

    //clear out the old..  seems to hold the prior.. not sure why
    document.getElementById("formatJson").innerHTML = "";
    document.getElementById("jsonResp").innerHTML = "";

    //populate the fields for showing on the screen
    document.getElementById("jsonResp").innerHTML = jasonObj;
        
    for (var para in myObj) {
        document.getElementById("formatJson").innerHTML +=  "<p>" + myObj[para] + "</p>";
    }

        
    return true;

}


