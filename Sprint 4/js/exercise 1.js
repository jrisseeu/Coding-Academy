async function findUserRepos() {
    var userID = document.getElementById("userID").value;
    
    var apiUrl = "https://api.github.com/users/" +userID + "/repos";
        
    var response = await fetch(apiUrl);
    var myObj;

    if (response.status >= 200 && response.status <= 299) {
        myObj = await response.json();

        if (myObj.message == "Not Found") {
            document.getElementById("userInfo").innerHTML =  "User ID <b> " +userID + " </b> could not be located at Github";
            return true;
        }

    } else {
        document.getElementById("userInfo").innerHTML =  "Invalid response received from Github: " +response.status + " Status text: " +response.statusText;
        return true;
    } 
    
    document.getElementById("userInfo").innerHTML =  userID;
    document.getElementById("repoInfo").innerHTML =  buildHTML(myObj);

    //clear the entry field
    document.getElementById("userID").value = '';    
    

    return true;

}

//Format the repository links using the json Object
function buildHTML(jsonObject) {
    var repoLinks = "";
    for (var theRepo in jsonObject) {
        repoLinks += "<p><a href=" + jsonObject[theRepo].html_url + ">" + jsonObject[theRepo].name +"</a></p>";
    }

    return repoLinks;
}



