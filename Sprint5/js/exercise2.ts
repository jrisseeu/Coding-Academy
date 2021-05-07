function validateEntry() {
    let word:string = (<HTMLInputElement>document.getElementById("theWord")).value;
    let number:number = (<HTMLInputElement>document.getElementById("theNumber")).valueAsNumber;
    let caseSens:boolean = (<HTMLInputElement>document.getElementById("byCase")).checked;
    let origWord:string = word;
    
    if (!caseSens) {
        word = word.toLowerCase();
    } 

    if (null == validateLetters(word)) {
        alert("Please enter a valid alphanumeric word");
        return false;
    } 

    if (null == validateNumber(number)) {
        alert("Please enter either a 1 or 2");
        return false;
    } 
    
    if (number == 1) {
        let result:boolean = isWordOnePalindrome(word);
        let table1:HTMLTableElement = (<HTMLTableElement >document.getElementById("list1"));
        table1.insertRow(table1.rows.length).innerHTML = origWord + ": " + result;
        
    } else {
        let result:boolean = isWordTwoPalindrome2(word);
        let table2:HTMLTableElement   = (<HTMLTableElement>document.getElementById("list2"));
        table2.insertRow(table2.rows.length).innerHTML  = origWord + ": " + result;
        
    }
    
    (<HTMLInputElement>document.getElementById('theWord')).value = '';
    (<HTMLInputElement>document.getElementById('theNumber')).value = '';
    (<HTMLInputElement>document.getElementById("byCase")).checked = true;
   
    return true;
}

//Split with "" tells to split between characters seperated by commas
//reverse - reverses the text
//Join wiht "" tells to join the string back with the commas being the separator
    //alert(x.split(""));
    //alert(x.split("").reverse());
    //alert(x.split("").reverse().join(""));
function isWordOnePalindrome(x:string) :boolean {
    return doesTextMatch(x,x.split("").reverse().join(""));
}

function isWordTwoPalindrome2(x:string) :boolean {
    return doesTextMatch(x,reverseInputString(x));
}

function doesTextMatch(x:string,y:string):boolean {
    if (x == y) {
        return true;
     } else {
       return false;
     }
}

// Loop through the string backwards from the end of the string 
//  !!!! NOTE: JS starts at zero so we need to subtract 1 from the length
//  otherwise you get an undefined for the first value 
function reverseInputString(str: string):string {
    let returnVal:string = "";
    for (var i: number = str.length - 1 ; i >= 0; i--) { 
        returnVal += str[i]; 
        
    }
    return returnVal; 
}

function validateNumber(str:number) {
    const pattern = /[1-2]/g;
    return str.toString().match(pattern);
}

function validateLetters(str:string) {
    const pattern = /^[A-Za-z]+$/;
    return str.match(pattern);
}

function clearList1() {
    // clear the table of all rows
    document.getElementById('list1').innerHTML = "";
  }

  function clearList2() {
    // clear the table of all rows
    document.getElementById('list2').innerHTML = "";
  }
