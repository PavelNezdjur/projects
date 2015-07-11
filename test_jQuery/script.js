
function result(){
	
	var count=0;
	var inPercent=0;
	if($("input:radio[name=q1]").eq(2).prop("checked")){
		count++;
	}
	if($("input:radio[name=q2]").eq(1).prop("checked")){
		count++;
	}
	if($("input:radio[name=q3]").eq(1).prop("checked")){
		count++;
	}
	if($("input:checkbox[name=q4]").eq(0).prop("checked")){
		count += 0.5;
	}
	if($("input:checkbox[name=q4]").eq(2).prop("checked")){
		count += 0.5;
	}
	if($("input:checkbox[name=q4]").eq(1).prop("checked")){
		count -= 0.5;
	}
	if($("input:checkbox[name=q5]").eq(0).prop("checked")){
		count += 0.5;
	}
	if($("input:checkbox[name=q5]").eq(1).prop("checked")){
		count += 0.5;
	}
	if($("input:checkbox[name=q5]").eq(3).prop("checked")){
		count += 0.5;
	}
	if($("input:checkbox[name=q5]").eq(2).prop("checked")){
		count -= 0.5;
	}
	if($("input:radio[name=q6]").eq(2).prop("checked")){
		count++;
	}
	if($("input:checkbox[name=q7]").eq(2).prop("checked")){
		count += 0.5;
	}
	if($("input:checkbox[name=q7]").eq(0).prop("checked")){
		count -= 0.5;
	}
	if($("input:checkbox[name=q7]").eq(1).prop("checked")){
		count -= 0.5;
	}
	if($("input:checkbox[name=q7]").eq(3).prop("checked")){
		count -= 0.5;
	}
	if($("input:radio[name=q8]").eq(1).prop("checked")){
		count++;
	}
	if($("input:checkbox[name=q9]").eq(0).prop("checked")){
		count += 0.5;
	}
	if($("input:checkbox[name=q9]").eq(1).prop("checked")){
		count += 0.5;
	}
	if($("input:checkbox[name=q9]").eq(2).prop("checked")){
		count += 0.5;
	}
	if($("input:checkbox[name=q9]").eq(3).prop("checked")){
		count += 0.5; 
	}
	if($("input:radio[name=q10]").eq(0).prop("checked")){
		count++;
	}
	$("#display").val(count);
	
	inPercent = count*100/11;
	
	alert("Ваш процент правильных ответов составил: " + inPercent);
}



