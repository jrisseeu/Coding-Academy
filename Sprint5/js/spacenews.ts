async function getSpaceNews() {
      
    var newsType = document.getElementById("newsType").value;
    var getNbr = document.getElementById("findVal").value;
    var testProd = document.getElementById("server").value;
    var apiUrl;

    if (testProd === "prod") {
        apiUrl = "https://spaceflightnewsapi.net/api/v2/" + newsType + "?_limit=" +getNbr;
    } else {
        apiUrl = "https://test.spaceflightnewsapi.net/api/v2/" + newsType + "?_limit=" +getNbr;
    }

    //https://spaceflightnewsapi.net/api/v2/articles?_limit=1
    //https://test.spaceflightnewsapi.net/api/v2/blogs?_limit=10

    //var apiUrl = "https://spaceflightnewsapi.net/api/v2/" + newsType + "?_limit=" +getNbr;
    //var apiUrl = "https://test.spaceflightnewsapi.net/api/v2/" + newsType + "?_limit=" +getNbr;

  
    var response = await fetch(apiUrl);
    var jsonObject;

    if (response.status >= 200 && response.status <= 299) {
        jsonObject = await response.json();
    } else {
        alert("failed call" +response.status + " status text " + response.statusText);
        return true;
    } 

    
    var headerData = createTableHeader();
    var tableData = buildHTML(jsonObject);

    document.getElementById("newsInfo").innerHTML =  headerData + tableData;

    return true;

}

function buildHTML(jsonObject) {

    var repoLinks = "";
    for (var theRepo in jsonObject) {
        repoLinks += createTableData(
            jsonObject[theRepo].title,
            jsonObject[theRepo].url,
            jsonObject[theRepo].newsSite,
            jsonObject[theRepo].publishedAt,
            jsonObject[theRepo].summary,
            jsonObject[theRepo].imageUrl,
            );
    }

    return repoLinks;
}

//Creates the TR and TH tags for the HTML table header
function createTableHeader() {
    return "<tr><th>Title</th><th>Reference Image</th><th>News Site</th><th>Summary</th><th>Published Date</th>";
}

//Creates the HTML table with the necessary TD and TR tages
function createTableData (title, url, site, pubDate, summary, imgString) {
    
    var table = "<tr><td>" + formatExternalLink(url, truncateString(title,20)) +"</td>";
    table += "<td>" + formatImage(imgString) +"</td>";
    table += "<td>" + site +"</td>";
    table += "<td>" + summary +"</td>";
    table += "<td white-space: nowrap>" + truncateDate(pubDate) +"</td></tr>";

    return table;
}

//Formats the title / link for the user to click on and open a new browser tab
function formatExternalLink(url, title) {
   return '<p><a href="' + url + '" target=_blank">"' + title +'"</a></p>';
}

//Formats the image so it can be clicked and open in a new tab
function formatImage(string) {
    var link = '<a href="' + string +'" target=_blank">';
    link += '<img src=' + string  +' style="width:150px;">';
    return link;
}

//Truncates the string based on what is passed in.  
//If the string is shorter than the value, the string is passed back.
//If the string in longer than the value, the string is truncated and three ... are added to the end
function truncateString(str, num) {
    if (str.length > num) {
      return str.slice(0, num) + "...";
    } else {
      return str;
    }
  }

//Removes the extra characters after the date
function truncateDate(date) {
    return date.slice(0, 10);
  }

 //reset the user input fields
function startOver() {
    var newsType = document.getElementById("newsType").value = "articles";
    var getNbr = document.getElementById("findVal").value = "1";
    var testProd = document.getElementById("server").value = "prod";

    document.getElementById("newsInfo").innerHTML = "";
}