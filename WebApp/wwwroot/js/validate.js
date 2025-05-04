const validate = (e) => {
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


	let errMsg = document.querySelector(`span[class*="${field} field-validation"]`);

	if (e.target.value.trim() === "") {
		errMsg.innerHTML = "Required field";
	}
	else if (field === "ConfirmPassword" && (pswrd.value !== confirmPswrd.value) && (pswrd.value.length > 0)) {
		errMsg.innerHTML = "Passwords don't match";
		confirmPswrd.addEventListener("focus", validate);

	}
	else if (patterns[field] && !patterns[field].test(e.target.value)) {
		errMsg.innerHTML = messages[field];
		if (field === "Password") {
			pswrd.removeEventListener("focusout", validate);
			pswrd.addEventListener("input", validate);
		}
	}
	else {
		errMsg.innerHTML = "";
	}
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