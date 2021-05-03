async function weHaveTheMeat() {
    var numParas = document.getElementById("paras").value;
    var encrypt = document.getElementById("encrypt").value;
    var allMeat = document.getElementById("allmeat").checked;
    var meatAndFiller = document.getElementById("meatandfiller").checked;
  
    document.getElementById("formatJson").innerHTML = "";
    document.getElementById("encryptedJson").innerHTML = "";
    document.getElementById("jsonResp").innerHTML = "";

    if(!allMeat && !meatAndFiller) {
        alert("Please select a type of meat");
        return;
    }
    
    var type;
    if (allMeat) {
        type = "type=all-meat";

    } else {
        type = "type=meat-and-filler";
    }
    var apiUrl = "https://baconipsum.com/api/?" +type +"&paras=" +numParas;

    alert(apiUrl)    ;
    var response = await fetch(apiUrl);
    var myObj = await response.json();

    var jasonObj = JSON.stringify(myObj);
    
    //clear out the old..  seems to hold the prior.. not sure why
    document.getElementById("formatJson").innerHTML = "";
    document.getElementById("jsonResp").innerHTML = "";
    document.getElementById("encrypt").value = "1";
    document.getElementById("paras").value = "1";
    document.getElementById("allmeat").checked = false;
    document.getElementById("meatandfiller").checked = false;

    //populate the fields for showing on the screen
    document.getElementById("jsonResp").innerHTML = jasonObj;
        
    for (var para in myObj) {
        document.getElementById("formatJson").innerHTML +=  "<p>" + myObj[para] + "</p>";
    }

    var securedJASON;
    if (encrypt === "1") {
     securedJASON = cipher1(myObj);   // apply the first cipher algorithm
    } else {
      //securedJASON = cipher2(myObj); 
      securedJASON =  verySimpleCypher(myObj);
    }

    for (var paras in securedJASON) {
        document.getElementById("encryptedJson").innerHTML +=  "<p>" + securedJASON[paras] + "</p>";
    }
    
    return true;

}

function verySimpleCypher(myObj, shift) {
    var oldChar;
    var secureJASON = [];
    
    for (var para in myObj) {
        newPara = "";
        newChar = "";
        var charPos = 0;
        for (var chara in myObj[para]) {
            oldChar = myObj[para][chara];
            newChar = encrypteTheText(oldChar, shift);
            newPara += newChar;
        }
        secureJASON.push(newPara);
    }
    
    return secureJASON;
}

//
function encrypteTheText(char) {
    
    const alphabet = ['A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',".","-",","];
    const returnVal =['U','Y','T','P','Z','H','R','O','A','H','E','B','V','S','D','F','G','X','I','N','J','Q','K','M','C','L',"@","#","$"];
    
    var include = alphabet.includes(char.toUpperCase());
    
    //IF a letter.  otherwise keep the character
    if (include){      
        var position = alphabet.indexOf(char.toUpperCase());
        var newChar = returnVal[position];
        return newChar;
   } else   
     return char;
  }        

  function cipher1 (someJSON) {
    /* This simple Caesar's cipher algorithm will add 13 to the ASCII value of each character if the character
       is a letter.  It is circular so when adding 13 if it goes past z (or Z) it will go to a (or A) next. */

       var newChar;      // will contain the character being examined
       var newCharCode;  // will contain the ASCII code of the character being examined
       var newJSON=[];   // will contain the new JSON, initially an empty array

    // loop through the JSON object one paragraph at a time
    for (var para in someJSON) {     // for each paragraph in the object
      var newPara = "";              // initialize new paragraph to empty string, build it one character at a time
      for (var chara in someJSON[para]){          // for each character in the paragraph
        newChar = someJSON[para][chara];          //     get the character
        newCharCode = newChar.charCodeAt(0);      //     get the ASCII code of the character
        if ((newCharCode >= 65)&&(newCharCode <= 77))           // check for A-M
          newChar = String.fromCharCode(newCharCode+13)              // change the character
        else if ((newCharCode >= 78)&&(newCharCode <= 90))      // check for N-Z
          newChar = String.fromCharCode(newCharCode-13)              // change the character
        else if ((newCharCode >= 97)&&(newCharCode <= 109))     // check for a-m
          newChar = String.fromCharCode(newCharCode+13)              // change the character
        else if ((newCharCode >= 110)&&(newCharCode <= 122))    // check for n-z
          newChar = String.fromCharCode(newCharCode-13);             // change the character
        newPara += newChar;          // add the new character to the paragraph
      }  // end for each character

    newJSON.push(newPara);   // add the new encrypted paragraph array

    }  // end for each paragraph

  return newJSON;   // return the encrypted paragraphs
}

function cipher2 (someJSON) {
  /* This simple Caesar's cipher algorithm will simply add 1 to every character in an even position
     in a paragraph and subtract 1 from every character in an odd position in a paragraph. */

     var newChar;      // will contain the character being examined
     var newCharCode;  // will contain the ASCII code of the character being examined
     var newJSON=[];   // will contain the new JSON, initially an empty array

  // loop through the JSON object one paragraph at a time
  for (var para in someJSON) {     // for each paragraph in the object
    var newPara = "";              // initialize new paragraph to empty string, build it one character at a time
    var charPos = 0;               // this will keep track of even and odd positions and toggle with each character
    for (var chara in someJSON[para]){          // for each character in the paragraph
      newChar = someJSON[para][chara];          //     get the character
      newCharCode = newChar.charCodeAt(0);      //     get the ASCII code of the character
      if (charPos === 0){                        //     check if even or odd position
        newChar = String.fromCharCode(newCharCode+1)      //  it's even so add 1
        charPos = 1;                                      //  toggle to odd
      }       
      else{                        
        newChar = String.fromCharCode(newCharCode-1)      //  it's odd so subtract 1
        charPos = 0;                                      //  toggle to even
      }       
    newPara += newChar;          // add the new character to the paragraph
    }  // end for each character

  newJSON.push(newPara);   // add the new encrypted paragraph array

  }  // end for each paragraph

return newJSON;   // return the encrypted paragraphs
}

