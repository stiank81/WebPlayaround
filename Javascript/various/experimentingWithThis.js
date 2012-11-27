
var Calculator = function (a, b) {
	this.numberA = a; 
	this.numberB = b; 
}; 

Calculator.prototype = function () {
	
	var applyAdd = function () {
		return this.numberA + this.numberB; 
	};
	
	var add = function () {
		return this.applyAdd(); 
	};
	
	return {
		add: add, 
		applyAdd: applyAdd
	};
}();
