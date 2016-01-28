/*
Based off the style switching technique discussed on A List Apart:
http://alistapart.com/stories/alternate/
Developed by the mad coder Paul Snowden - when he wrote the base .js for this :)  http://idontsmoke.co.uk/
He had help with writing the cookie function from ALA author Peter-Paul Koch

Modified 01/01/08
	1. Removed the window.onUnload event for setting the cookie to
		remember the style sheet. onUnload is not a very reliable
		event to use. Moved the onUload event into a new function
		called 'bakeCookie' - and now call cookie baking every time
		the user sets a new style sheet (placed event in the
		setActiveStyleSheet function.
*/
function setActiveStyleSheet(title) {
  var i, a, main;
  for(i=0; (a = document.getElementsByTagName("link")[i]); i++) {
    if(a.getAttribute("rel").indexOf("style") != -1 && a.getAttribute("title")) {
      a.disabled = true;
      if(a.getAttribute("title") == title) a.disabled = false;
    }
  }
  bakeCookie();
}

function getActiveStyleSheet() {
  var i, a;
  for(i=0; (a = document.getElementsByTagName("link")[i]); i++) {
    if(a.getAttribute("rel").indexOf("style") != -1 && a.getAttribute("title") && !a.disabled) return a.getAttribute("title");
  }
  return null;
}

function getPreferredStyleSheet() {
  var i, a;
  for(i=0; (a = document.getElementsByTagName("link")[i]); i++) {
    if(a.getAttribute("rel").indexOf("style") != -1
       && a.getAttribute("rel").indexOf("alt") == -1
       && a.getAttribute("title")
       ) return a.getAttribute("title");
  }
  return null;
}

function createCookie(name,value,days) {
  if (days) {
    var date = new Date();
    date.setTime(date.getTime()+(days*24*60*60*1000));
    var expires = "; expires="+date.toGMTString();
  }
  else expires = "";
  document.cookie = name+"="+value+expires+"; path=/";
}

function bakeCookie() {
  var title = getActiveStyleSheet();
  createCookie("style", title, 365);
}

function readCookie(name) {
  var nameEQ = name + "=";
  var ca = document.cookie.split(';');
  for(var i=0;i < ca.length;i++) {
    var c = ca[i];
    while (c.charAt(0)==' ') c = c.substring(1,c.length);
    if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);
  }
  return null;
}

/*
onload event moved to the loadem.js file
window.onload = function() {
  var cookie = readCookie("style");
  var title = cookie ? cookie : getPreferredStyleSheet();
  setActiveStyleSheet(title);
}
*/

/*
// the onUnload event is a poor way to do this - see change notes at top of page.
window.onunload = function(e) {
  var title = getActiveStyleSheet();
  createCookie("style", title, 365);
}
*/

var cookie = readCookie("style");
var title = cookie ? cookie : getPreferredStyleSheet();
setActiveStyleSheet(title);
