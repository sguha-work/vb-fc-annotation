
// Show Date Time
var year, month, date, hour, minute, second, today;

function convert(input) {
    var output="0" + input;
    return (output.substring(output.length-2,output.length));
}

function now() {
    dt = new Date();
    year = dt.getFullYear();
    month = dt.getMonth()+1;
    date = dt.getDate();
    hour = dt.getHours();
    minute = dt.getMinutes();
    second = dt.getSeconds();
    
    today = convert(date) + "/" + convert(month) + "/" + year + " " 
            + convert(hour) + ":" + convert(minute) + ":" + convert(second);

    document.getElementById('dDate').value = today;
    setTimeout("now()",1000);
}
   