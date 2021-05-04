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
    
    var repoLinks = "";
    for (var theRepo in myObj) {
        repoLinks += "<p><a href=" + myObj[theRepo].html_url + ">" + myObj[theRepo].name +"</a></p>";
    }

    document.getElementById("userInfo").innerHTML =  userID;
    document.getElementById("repoInfo").innerHTML =  repoLinks;

    //clear the entry field
    document.getElementById("userID").value = '';    
    

    return true;

}



