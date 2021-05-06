function validateEntry() {
    let min:string = (<HTMLInputElement>document.getElementById("minNumber")).value;
    let max:string = (<HTMLInputElement>document.getElementById("maxNumber")).value;
    var theNumber = (<HTMLInputElement>document.getElementById("theNumber")).value;
   
          
    if (!validateNumber(min)) {
        alert("Please enter a starting number that is > 0");
        return false;
    } 

    if (!validateNumber(max)) {
        alert("Please enter a maximum number that is > 0" );
        return false;
    } 

    if (parseInt(theNumber) < parseInt(min)) {
      alert("Number entered has to be >= minimum number of: " + min);
      return false;
    } 

    if (Number(theNumber) > Number(max)) {
       alert("Number entered has to be <= maximum number of: " + max);
       return false;
   } 

   //disable the buttons so the user cannot enter any changes
   (<HTMLInputElement>document.getElementById("minNumber")).disabled = true;
   (<HTMLInputElement>document.getElementById("maxNumber")).disabled = true;

    let table1:any = (<HTMLInputElement>document.getElementById("list1"));
    table1.insertRow(table1.rows.length).innerHTML = theNumber;
    
    document.getElementById("mean").innerHTML = getMean(table1);
    document.getElementById("median").innerHTML = getMedian(table1).toString();
    document.getElementById("modes").innerHTML = getTheMode(table1);

    //Clear the number they enter for the next entry
    (<HTMLInputElement>document.getElementById('theNumber')).value = '';

    return true;  
}

function getTheMode(x:any):string {
    if (x.rows.length == 1) {
        return (x.rows[0]).innerHTML;
    }

    let array = [];
    let a:number = 0;
    for (a=0; a < x.rows.length; a++) {
     array.push(x.rows[a].innerHTML);
    }

    let frequency = {}; // array of frequency.
    let maxFreq = 0; // holds the max frequency.
    let modes = [];
  
    for (var i in array) {
      frequency[array[i]] = (frequency[array[i]] || 0) + 1; // increment frequency.
      if (frequency[array[i]] > maxFreq) { // is this frequency > max so far ?
        maxFreq = frequency[array[i]]; // update max.
      }
    }
  
    for (var k in frequency) {
      if (frequency[k] == maxFreq) {
        modes.push(k);
      }
    }
  
    return modes.toString();
  }

function getMedian(x:any):number {

    if (x.rows.length == 1) {
        return parseInt((x.rows[0]).innerHTML);
    }
    
    let numsCnt:number = x.rows.length;
    let array = [];
    let i:number = 0;

    for (i=0; i < numsCnt; i++) {
     array.push((x.rows[i]).innerHTML);
    }

    //Not sure how this works, but W3 used this to sort numerically
    array.sort(function(a, b){return a - b});
    
    //Round the length down to the closest number 
    //and divide in half to get the midpoint of the array
    let half:number = Math.floor(array.length/2);
    
    //If the array length is divisible by 2, get the value from the half way point
    if(array.length % 2) {
        return array[half];
    } else {
        let val1:number = array[half-1];
        let val2:number = array[half];
        return ((Number(val1) + Number(val2)) / 2); 
    }
}

function getMean(x:any):string {
    let numsCnt:number = x.rows.length;
    let sum:number = 0;
    let i:number;

    for (i = 0 ; i < numsCnt; i++) {
     sum += parseInt((x.rows[i]).innerHTML);
    }

    let mean:number = (Number(sum) / Number(numsCnt));
    return mean.toString();
}

function validateNumber(str: string) {
    const pattern = /[1-9999999999]/g;
    return str.match(pattern);     
}


function clearEveryThing() {
    // clear the table of all rows
    
    document.getElementById('list1').innerHTML = "";
    (<HTMLInputElement>document.getElementById("minNumber")).disabled = false;
    (<HTMLInputElement>document.getElementById("maxNumber")).disabled = false;
    (<HTMLInputElement>document.getElementById("minNumber")).value = '';
    (<HTMLInputElement>document.getElementById('maxNumber')).value = '';
    (<HTMLInputElement>document.getElementById('theNumber')).value = '';
    (<HTMLInputElement>document.getElementById("mean")).value = 'tbd';
    (<HTMLInputElement>document.getElementById("median")).value = 'tbd';
    (<HTMLInputElement>document.getElementById("modes")).value = 'tbd';
    
  }

