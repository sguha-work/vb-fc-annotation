

window.onload = function() {
	var cookie = readCookie("style");
	var title = cookie ? cookie : getPreferredStyleSheet();
	setActiveStyleSheet(title);

	/*startTimer();*/
	xhtmlExternalLinks();
}
