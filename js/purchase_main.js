
function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}


function MM_jumpMenu(targ,selObj,restore){ //v3.0
  eval(targ+".location='"+selObj.options[selObj.selectedIndex].value+"'");
  if (restore) selObj.selectedIndex=0;
}

function MM_jumpMenuGo(selName,targ,restore){ //v3.0
  var selObj = MM_findObj(selName); if (selObj) MM_jumpMenu(targ,selObj,restore);
}

// m3_jumpMenu & pmjumpMenuGo are modified versions of the MM functions above
// Added the ability to use many 'go' buttons at the same 
function pmjumpMenu(targ,selObj,restore,baseURL){ //v3.0
  eval(targ+".location='"+baseURL+selObj.options[selObj.selectedIndex].value+"'");
  if (restore) selObj.selectedIndex=0;
}
function pmjumpMenuGo(selName,targ,restore,baseURL){ //v3.0
	var selObj = MM_findObj(selName); if (selObj) pmjumpMenu(targ,selObj,restore,baseURL);
}


// pmshowHide ver1.2
function pmshowHide(theID) {
	if(!document.getElementById){return};
	var theElement = document.getElementById(theID);
	if (theElement.style.display == 'block') {
		theElement.style.display = 'none';
	} else {
		theElement.style.display = 'block';
	}
}

// pmswapClass ver1.2
function pmswapClass(theID,cssStyle,cssStyleOther) {
	if(!document.getElementById){return};
	var theElement = document.getElementById(theID);
	if (theElement.className == cssStyle) {
		theElement.className = cssStyleOther;
	} else {
		theElement.className = cssStyle;
	}
}


// pmchecker
// check out the old toad when you get a chance.
// killOnclick() added - calls the
function pmchecker(checkboxGroup){
	if(!checkboxGroup){return false;} // no checkboxes
	if(!checkboxGroup.length ){// it is not an Array
		return checkboxGroup.type=="checkbox"?checkboxGroup.checked:false
	}
	for(f=0;f<checkboxGroup.length;f++){
		if(checkboxGroup[f].checked){
			return true;
		}
	}
	return false;
}

function Lvl_P2P(u,c,d,w,h){ //ver1.0 4LevelWebs
	top.opener.location.href = u
	if (c == true)setTimeout('top.close()',d)
	if (w > 0){top.resizeTo(w,h)}
}

function Lvl_openWin(u,n,w,h,l,t,c,f) { //v1.0 4LevelWebs
	var ww=((screen.width-w)/2);if(c==1){l=ww;t=(screen.height-h)/2;}if(c==2){l=ww}
	f+=',top='+t+',left='+l;LvlWin = window.open(u,n,f);LvlWin.focus();
}

function GP_popupConfirmMsg(msg) { //v1.0
	document.MM_returnValue = confirm(msg);
}

function xhtmlExternalLinks() { 
	if (!document.getElementsByTagName) return; 
	var anchors = document.getElementsByTagName("a"); 
	for (var i=0; i<anchors.length; i++) { 
		var thisAnchor = anchors[i]; 
		if (thisAnchor.getAttribute("href") && thisAnchor.getAttribute("rel") == "external") thisAnchor.target = "_blank"; 
	} 
}

function killOnclick(e) {
	if(navigator.product) e.stopPropagation()
	else event.cancelBubble=true
}

function pmToggleMe(ImgID, First, Second, vis, Alt1, Alt2){
	if(!document.getElementById){return};
	var theImageAlt,arr=document.getElementsByTagName("DIV");
	var theImage=document.getElementById(ImgID);
	if(theImage.src.indexOf(First)!=-1){
		theImage.src=Second;
		theImageAlt=Alt1
	}
	else{
		theImage.src=First;
		theImageAlt=Alt2;
	}
	theImage.setAttribute("alt",theImageAlt);

	for(var i=0;i<arr.length;i++){
		var thisDiv=arr[i];
		if (thisDiv.getAttribute("lang") == "en"){
			var allDivs=arr[i].style.display;
			arr[i].style.display=(allDivs=="none")?allDivs="block":allDivs="none";
		}
	}
}


function pmround(number,X) {
// rounds number to X decimal places, defaults to 2
    X = (!X ? 2 : X);
    return Math.round(number*Math.pow(10,X))/Math.pow(10,X);
}

// pmcalcDiscount ver1.0 remove tax2
function pmcalcTotals(frmName,fldQty,fldAmt,fldDiscount,fldTax1,idSubTotal,idDiscount,idTax1,idTotal) {
	if (!document.getElementById) return;
	var theForm = document[frmName]
	var quantity = Number(theForm.elements[fldQty].value)
	var amount = Number(theForm.elements[fldAmt].value)
	var discount = Number(theForm.elements[fldDiscount].value)
	var tax1 = Number(theForm.elements[fldTax1].value)
	var daSubTotal = (quantity*amount)
	var daDiscount = ((daSubTotal)*(discount/100))
	var daTempTotal = daSubTotal-daDiscount
	var daTax1 = (daTempTotal)*(tax1/100)
	var daTotal = daTempTotal+daTax1

	document.getElementById(idSubTotal).innerHTML = pmround(daSubTotal,2)
	document.getElementById(idDiscount).innerHTML = pmround(daDiscount,2)
	document.getElementById(idTax1).innerHTML = pmround(daTax1,2)
	document.getElementById(idTotal).innerHTML = pmround(daTotal,2)
}

// pmcalcDiscount ver1.0
function pmcalcTotals99(frmName,fldQty,fldAmt,fldDiscount,fldTax1,fldTax2,idSubTotal,idDiscount,idTax1,idTax2,idTotal) {
	if (!document.getElementById) return;
	var theForm = document[frmName]
	var quantity = Number(theForm.elements[fldQty].value)
	var amount = Number(theForm.elements[fldAmt].value)
	var discount = Number(theForm.elements[fldDiscount].value)
	var tax1 = Number(theForm.elements[fldTax1].value)
	var tax2 = Number(theForm.elements[fldTax2].value)
	var daSubTotal = (quantity*amount)
	var daDiscount = ((daSubTotal)*(discount/100))
	var daTempTotal = daSubTotal-daDiscount
	var daTax1 = (daTempTotal)*(tax1/100)
	var daTax2 = (daTempTotal)*(tax2/100)
	var daTotal = daTempTotal+daTax1+daTax2

	document.getElementById(idSubTotal).innerHTML = pmround(daSubTotal,2)
	document.getElementById(idDiscount).innerHTML = pmround(daDiscount,2)
	document.getElementById(idTax1).innerHTML = pmround(daTax1,2)
	document.getElementById(idTax2).innerHTML = pmround(daTax2,2)
	document.getElementById(idTotal).innerHTML = pmround(daTotal,2)
}

