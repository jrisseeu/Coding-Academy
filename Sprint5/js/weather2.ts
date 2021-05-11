export{}
async function getTheForecast() {


    let location:string = (<HTMLInputElement>document.getElementById("location")).value;
    const apiUrl:string = "https://api.weather.gov/gridpoints/" +location + "/25,45/forecast";
    
    let response:Response = await fetch(apiUrl.toString());

    if (response.ok) {
        const myObj = await response.json();
        let nbrDays:number = myObj.properties.periods.length;
        let headerData:string = createTableHeader();
        let tblInfo:string = "";
       
        for (let j:number = 0; j < nbrDays; j++) {
            tblInfo += createTableData(myObj.properties.periods[j].name,
                myObj.properties.periods[j].shortForecast,
                myObj.properties.periods[j].temperature,
                myObj.properties.periods[j].icon);
        }
    
        document.getElementById("forecast").innerHTML = headerData + tblInfo;
      
        return true;

    } else {
        alert("failed call" +response.status + " status text " + response.statusText);
        return true;
    } 
}

//Format the image string
function formatImage(string:string):string {
    
    return  "<img src=" + string  +">";
}

function createTableHeader():string {
    
    return "<tr><th>Visual Forecast</th><th>Day of the week</th><th>Weather</th><th>Temperature</th>";
    
}

function createTableData (days:string, weather:string, temp:string, image:string):string {
    
    let table:string = "<tr><td>" + formatImage(image) +"</td>";
    table += "<td>" + days +"</td>";
    table += "<td>" + weather +"</td>";
    table += "<td>" + temp +" Degrees Farenheit </td></tr>";

    return table;
}






