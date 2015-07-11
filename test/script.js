
function result(){
	var form = document.forms[0];
	var count=0;
	var inPercent=0;
	if(form.elements.q1[2].checked){
		count++;
	}
	if(form.elements.q2[1].checked){
		count++;
	}
	if(form.elements.q3[1].checked){
		count++;
	}
	if(form.elements.q4[0].checked){
		count += 0.5;
	}
	if(form.elements.q4[2].checked){
		count += 0.5;
	}
	if(form.elements.q4[1].checked){
		count -= 0.5;
	}
	if(form.elements.q5[0].checked){
		count += 0.5;
	}
	if(form.elements.q5[1].checked){
		count += 0.5;
	}
	if(form.elements.q5[3].checked){
		count += 0.5;
	}
	if(form.elements.q5[2].checked){
		count -= 0.5;
	}
	if(form.elements.q6[2].checked){
		count++;
	}
	if(form.elements.q7[2].checked){
		count += 0.5;
	}
	if(form.elements.q7[0].checked){
		count -= 0.5;
	}
	if(form.elements.q7[1].checked){
		count -= 0.5;
	}
	if(form.elements.q7[3].checked){
		count -= 0.5;
	}
	if(form.elements.q8[1].checked){
		count++;
	}
	if(form.elements.q9[0].checked){
		count += 0.5;
	}
	if(form.elements.q9[1].checked){
		count += 0.5;
	}
	if(form.elements.q9[2].checked){
		count += 0.5;
	}
	if(form.elements.q9[3].checked){
		count += 0.5; 
	}
	if(form.elements.q10[0].checked){
		count++;
	}
	document.getElementById("display").value = count;
	
	inPercent = count*100/11;
	
	alert("Ваш процент правильных ответов составил: " + inPercent)
}



