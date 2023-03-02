var originalTop = 0;

function parallax() {
	console.log("parallax");

	const scroll = document.getElementsByTagName("header")[0].getBoundingClientRect().y;
	//tekst
	let s = document.getElementById("floater-slow");
	//var yPos = 0 - window.pageYOffset / 4;
	//s.style.top = originalTop + yPos + "%";
	let yPos = scroll - (scroll / 8);
	s.style.top = 0 + yPos + "px";

	//blobs
	s = document.getElementsByClassName("blob-image");
	/*console.log(s);*/
	yPos = scroll - (scroll / 2);
	for (var i = 0; i < s.length; i++) {
		let elem = s[i];
		/*console.log(elem);*/

		// We need to calculate the original top css property, in order to correctly
		// offset the top for parallax scrolling.
		if (elem.originalTop == null) {
			elem.originalTop = getComputedStyle(s[i]).top; // Returns something like "100px"
			// Remove the -px suffix, and convert to a number
			elem.originalTop = parseInt(elem.originalTop.substring(0, elem.originalTop.length - 2));
		}

		let newTop = elem.originalTop + yPos + "px";
		elem.style.top = newTop;
    }

	
}

document.body.addEventListener("scroll", function () {
	parallax();
});

/*setInterval(parallax, 10);*/
