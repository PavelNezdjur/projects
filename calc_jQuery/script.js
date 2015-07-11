
var first;
var operation;

function pushNum(Num) {
	var push = $("#editWide")[0];
	push.value += Num;
}
function clearAll (){
	$("#editWide").val("");
}
function plus() {
	first = $("#editWide").val();
	$("#editWide").val("");
	operation = "needPlus";
}
function minus() {
	first = $("#editWide").val();
	$("#editWide").val("");
	operation = "needMinus";
}
function multiply() {
	first = $("#editWide").val();
	$("#editWide").val("");
	operation = "needMultiply";
}
function divide() {
	first = $("#editWide").val();
	$("#editWide").val("");
	operation = "needDivide";
}
function calculate() {
	switch (operation) {
		case "needPlus":
			$("#editWide").val(+$("#editWide").val() + +first);
			break;
		case "needMinus": 
			$("#editWide").val(first - $("#editWide").val());
			break;
		case "needMultiply":	
			$("#editWide").val(first * $("#editWide").val());
			break;
		case	"needDivide": 
			if ($("#editWide").val()==0) {
				alert ("Деление на 0 запрещено!");
			}
			else {
			$("#editWide").val(first / $("#editWide").val());
			}
	}
}
function neg() {
	$("#editWide").val($("#editWide").val() * -1);
}
function level2(){
	$("#editWide").val($("#editWide").val() * $("#editWide").val());
}
function level3(){
	$("#editWide").val($("#editWide").val() * $("#editWide").val()* $("#editWide").val());
}
function percent() {
	$("#editWide").val((first / 100) * $("#editWide").val());
}
function sqrt(){
	$("#editWide").val(Math.sqrt($("#editWide").val()));
}
function exit(){
	var thisWindow = window.open("calchard.html",'_self');
	var exit = confirm("Хотите выключить калькулятор?");
	if (exit){
		thisWindow.close();
	}
}
      
