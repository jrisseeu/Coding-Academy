async function findTheQuote() {
    var qLength = document.getElementById("qLength").value;
    
    document.getElementById("jsonResp").innerHTML = "";

    var short = "minLength=1&maxLength=100";
    var medium = "minLength=100&maxLength=250";
    var large = "minLength=250";

    var addToAPI;

    if (qLength == "Short") {
        addToAPI = "?" + short;
    } else if (qLength == "Medium") {
        addToAPI = "?" + medium;
    } else {
        addToAPI = "?" + large;
    }

    var apiUrl = "https://api.quotable.io/random" +addToAPI;
    alert(apiUrl);
        
    var response = await fetch(apiUrl);
    var myObj = await response.json();
    
    //clear out the old..
    document.getElementById("jsonResp").innerHTML = "";
    document.getElementById("quoteArea").innerHTML = "";
    
    //populate the fields for showing on the screen
    var theQuoteInfo =  createResponse(myObj.content, myObj.author);

    document.getElementById("jsonResp").innerHTML =  theQuoteInfo;
    return true;

}

function createResponse(quote, author) {

    var resp1 = "<p> <b>Quote: </b>" + quote +"</p>";
    resp1 += "<p> <b>Author: </b>" + author + "</p>";

    return resp1;
}


