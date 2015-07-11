
var first;
var operation;

function pushNum(Num) {
	var push = document.getElementById("editWide");
	push.value += Num;
}
function clearAll (){
	document.getElementById("editWide").value = "";
}
function plus() {
	first = document.getElementById("editWide").value;
	document.getElementById("editWide").value = "";
	operation = "needPlus";
}
function minus() {
	first = document.getElementById("editWide").value;
	document.getElementById("editWide").value = "";
	operation = "needMinus";
}
function multiply() {
	first = document.getElementById("editWide").value;
	document.getElementById("editWide").value = "";
	operation = "needMultiply";
}
function divide() {
	first = document.getElementById("editWide").value;
	document.getElementById("editWide").value = "";
	operation = "needDivide";
}
function calculate() {
	switch (operation) {
		case "needPlus":
			document.getElementById("editWide").value = +first + +document.getElementById("editWide").value;
			break;
		case "needMinus": 
			document.getElementById("editWide").value = first - document.getElementById("editWide").value;
			break;
		case "needMultiply":	
			document.getElementById("editWide").value = first * document.getElementById("editWide").value;
			break;
		case	"needDivide": 
			if (document.getElementById("editWide").value == 0) {
				alert ("Деление на 0 запрещено!");
			}
			else {
			document.getElementById("editWide").value = first / document.getElementById("editWide").value;
			}
	}
}
function neg() {
	document.getElementById("editWide").value = document.getElementById("editWide").value * -1;
}
function level2(){
	document.getElementById("editWide").value = document.getElementById("editWide").value * document.getElementById("editWide").value;
}
function level3(){
	document.getElementById("editWide").value = document.getElementById("editWide").value * document.getElementById("editWide").value* document.getElementById("editWide").value;
}
function percent() {
	document.getElementById("editWide").value = (first / 100) * document.getElementById("editWide").value;
}
function sqrt(){
	document.getElementById("editWide").value = Math.sqrt(document.getElementById("editWide").value)
}
function exit(){
	var thisWindow = window.open("calchard.html",'_self');
	var exit = confirm("Хотите выключить калькулятор?");
	if (exit){
		thisWindow.close();
	}
}
      
