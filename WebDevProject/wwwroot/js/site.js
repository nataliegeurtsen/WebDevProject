var originalTop = 0;

function parallax() {
	var s = document.getElementById("floater-slow");
	//if (originalTop == null) {
	//	console.log(s);
	//	originalTop = getComputedStyle(s).top;
	//	console.log(originalTop);
	//}

	//var s = document.getElementsByClassName("blob-image");
	//var yPos = 0 - window.pageYOffset / 4;
	//for (var i = 0; i < s.length; i++) {
	//	let elem = s[i];
	//	elem.style.top = 50 + yPos + "%";
 //   }

	
	var yPos = 0 - window.pageYOffset / 4;

	s.style.top = originalTop + yPos + "%";
}

window.addEventListener("scroll", function () {
	parallax();
});