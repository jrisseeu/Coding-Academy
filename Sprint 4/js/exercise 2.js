async function getTheForecast() {


    var location = document.getElementById("location").value;
    

    var apiUrl = "https://api.weather.gov/gridpoints/" +location + "/25,45/forecast";
    
        
    var response = await fetch(apiUrl);
    var myObj;

    if (response.status >= 200 && response.status <= 299) {
        myObj = await response.json();
    } else {
        alert("failed call" +response.status + " status text " + response.statusText);
        return true;
    } 


    var nbrDays = myObj.properties.periods.length;
    var headerData = createTableHeader();
    
    var tblInfo = "";
   
    for (j = 0; j < nbrDays; j++) {
        tblInfo += createTableData(myObj.properties.periods[j].name,
            myObj.properties.periods[j].shortForecast,
            myObj.properties.periods[j].temperature,
            myObj.properties.periods[j].icon);
    }

    document.getElementById("forecast").innerHTML = headerData + tblInfo;
  

    return true;

}

//Format the repository links using the json Object
function formatImage(string) {
    
    return  "<img src=" + string  +">";
}

function createTableHeader() {
    
    return "<tr><th>Visual Forecast</th><th>Day of the week</th><th>Weather</th><th>Temperature</th>";
    
}

function createTableData (days, weather, temp, image) {
    
    var table = "<tr><td>" + formatImage(image) +"</td>";
    table += "<td>" + days +"</td>";
    table += "<td>" + weather +"</td>";
    table += "<td>" + temp +" Degrees Farenheit </td></tr>";

    return table;
}






