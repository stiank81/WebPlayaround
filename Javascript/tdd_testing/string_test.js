
testCase("String trim test", {
	"test trim should remove leading white-space": 
	function () {
		assert("should remove leading white-space", 
		       "a string" === "    a.string".trim());
	}
}); 