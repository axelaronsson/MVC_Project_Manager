const validate = (e) => {
	console.log(validate);
	const field = e.target.name;

	const patterns = {
		FullName: new RegExp("^[a-ö]([-']?[a-ö]+)*( [a-ö]([-']?[a-ö]+)*)+$", "i"),
		Email: new RegExp("^\\S+@\\S+\\.\\S+$"),
		Password: new RegExp("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9 -]).{8,}$")
	};

	const messages = {
		FullName: "Invalid name",
		Email: "Invalid email",
		Password: "Password must be at least 8 characters and contain one: digit, lowercase and uppercase letter, non alphanumeric."
	};


	const jsSpan = document.getElementsByClassName('js-validation ' + field)[0];
	const aspSpan = document.getElementsByClassName(field + " field-validation-error")[0];
	let errMsg = jsSpan;

	if (aspSpan)
		errMsg = aspSpan;

	if (e.target.value.trim() === "") {
		console.log("cond 1");
		errMsg.innerHTML = "Required field";
		errMsg.style.display = "block";
	}
	else if (field === "ConfirmPassword" && (pswrd.value !== confirmPswrd.value) && (pswrd.value.length > 0)) {
		console.log("cond 2");
			errMsg.innerHTML = "Passwords don't match";
			errMsg.style.display = "block";
	}
	else if (patterns[field] && !patterns[field].test(e.target.value)) {
		console.log("cond 3");
		//errMsg.innerHTML = "Invalid " + field.replace("Name", " Name");
		errMsg.innerHTML = messages[field];
		errMsg.style.display = "block";
		if (field === "Password") {
			console.log("field", field)
			pswrd.removeEventListener("focusout", validate);
			pswrd.addEventListener("input", validate);
		}
	}
	else {
		console.log("else");
		errMsg.innerHTML = "";
		//errMsg.style.display = "none";
	}
	//errMsg.previousElementSibling.display = "none";
}

const debounce = (mainFunction, delay) => {
	let timer;

	return function (...args) {
		clearTimeout(timer);

		timer = setTimeout(() => {
			mainFunction(...args);
		}, delay);
	};
};

const checkPasswords = debounce(validate, 1000);

const fullName = document.querySelector('input[name="FullName"]');
const mail = document.querySelector('input[name="Email"]');
const pswrd = document.querySelector('input[name="Password"]');
const confirmPswrd = document.querySelector('input[name="ConfirmPassword"]');

fullName.addEventListener("focusout", validate);
mail.addEventListener("focusout", validate);
pswrd.addEventListener("focusout", validate);
confirmPswrd.addEventListener("input", checkPasswords);
confirmPswrd.addEventListener("focusout", validate);