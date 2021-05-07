export{}
async function getSpaceNews() {
      
    let newsType:string = (<HTMLInputElement>document.getElementById("newsType")).value;
    let getNbr:string = (<HTMLInputElement>document.getElementById("findVal")).value;
    let testProd = (<HTMLInputElement>document.getElementById("server")).value;
    let apiUrl:string;

    if (testProd === "prod") {
        apiUrl = "https://spaceflightnewsapi.net/api/v2/" + newsType + "?_limit=" +getNbr;
    } else {
        apiUrl = "https://test.spaceflightnewsapi.net/api/v2/" + newsType + "?_limit=" +getNbr;
    }
  
    let response:Response = await fetch(apiUrl);

    if (response.ok) {
        const jsonObject = await response.json();

        let headerData:string = createTableHeader();
        let tableData:string;
        for (let theRepo in jsonObject) {
            tableData += createTableData(
                jsonObject[theRepo].title,
                jsonObject[theRepo].url,
                jsonObject[theRepo].newsSite,
                jsonObject[theRepo].publishedAt,
                jsonObject[theRepo].summary,
                jsonObject[theRepo].imageUrl,
                );
        }

        document.getElementById("newsInfo").innerHTML =  headerData + tableData;
        return true;

    } else {
        alert("failed call" +response.status + " status text " + response.statusText);
        return false;
    }
}

//Creates the TR and TH tags for the HTML table header
function createTableHeader():string {
    return "<tr><th>Title</th><th>Reference Image</th><th>News Site</th><th>Summary</th><th>Published Date</th>";
}

//Creates the HTML table with the necessary TD and TR tages
function createTableData (title:string, url:string, site:string, pubDate:string, summary:string, imgString:string):string {
    
    let table:string = "<tr><td>" + formatExternalLink(url, truncateString(title,20)) +"</td>";
    table += "<td>" + formatImage(imgString) +"</td>";
    table += "<td>" + site +"</td>";
    table += "<td>" + summary +"</td>";
    table += "<td white-space: nowrap>" + truncateDate(pubDate) +"</td></tr>";

    return table;
}

//Formats the title / link for the user to click on and open a new browser tab
function formatExternalLink(url:string, title:string):string {
   return '<p><a href="' + url + '" target=_blank">"' + title +'"</a></p>';
}

//Formats the image so it can be clicked and open in a new tab
function formatImage(string:string):string {
    let link:string = '<a href="' + string +'" target=_blank">';
    link += '<img src=' + string  +' style="width:150px;">';
    return link;
}

//Truncates the string based on what is passed in.  
//If the string is shorter than the value, the string is passed back.
//If the string in longer than the value, the string is truncated and three ... are added to the end
function truncateString(str:string, num:number):string {
    if (str.length > num) {
      return str.slice(0, num) + "...";
    } else {
      return str;
    }
  }

//Removes the extra characters after the date
function truncateDate(date:string):string {
    return date.slice(0, 10);
  }

 //reset the user input fields
function startOver() {
    (<HTMLInputElement>document.getElementById("newsType")).value = "articles";
    (<HTMLInputElement>document.getElementById("findVal")).value = "1";
    (<HTMLInputElement>document.getElementById("server")).value = "prod";
    document.getElementById("newsInfo").innerHTML = "";
}