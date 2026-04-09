function validateRequired(controlId, invalidValues = [], message) {
    let ctrl = $("#" + controlId);

    // Remove previous error
    ctrl.removeClass("input-error");
    ctrl.next(".error-text").remove();

    let val = ctrl.val().trim();

    if (val === "" || val === "-1") {

        // Add red border
        ctrl.addClass("input-error");

        // Focus
        ctrl.focus();

        // Add inline message
        ctrl.after(`<div class="error-text">${message}</div>`);

        return false;
    }

    return true;
}

function validateEmail(controlId, requiredMessage, invalidMessage) {
    let ctrl = $("#" + controlId);

    ctrl.removeClass("input-error");
    ctrl.next(".error-text").remove();

    let val = ctrl.val().trim();

    if (val === "") {
        ctrl.addClass("input-error");
        ctrl.focus();
        ctrl.after(`<div class="error-text">${requiredMessage}</div>`);
        return false;
    }

    let regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    if (!regex.test(val)) {
        ctrl.addClass("input-error");
        ctrl.focus();
        ctrl.after(`<div class="error-text">${invalidMessage}</div>`);
        return false;
    }

    return true;
}
function validateContactNumber(controlId, requiredMessage, invalidMessage) {
    let ctrl = $("#" + controlId);

    // Clear previous errors
    ctrl.removeClass("input-error");
    ctrl.next(".error-text").remove();

    let val = ctrl.val().trim();

    // 1️⃣ Required check
    if (val === "") {
        ctrl.addClass("input-error");
        ctrl.focus();
        ctrl.after(`<div class="error-text">${requiredMessage}</div>`);
        return false;
    }

    // 2️⃣ Regex check: optional +, digits only, length 7–15
    let regex = /^\+?[0-9]{7,15}$/;

    if (!regex.test(val)) {
        ctrl.addClass("input-error");
        ctrl.focus();
        ctrl.after(`<div class="error-text">${invalidMessage}</div>`);
        return false;
    }

    return true;
}

// Allow only numbers dynamically
$(document).on("keypress", ".only-number", function (e) {
    var charCode = e.which ? e.which : e.keyCode;

    // Allow backspace, delete
    if (charCode === 8 || charCode === 46) return true;

    // Allow only digits
    if (charCode < 48 || charCode > 57) {
        e.preventDefault();
        return false;
    }
});

// Prevent paste of non-numeric characters
$(document).on("paste", ".only-number", function (e) {
    let pastedData = (e.originalEvent || e).clipboardData.getData('text');
    if (!/^\d+$/.test(pastedData)) {
        e.preventDefault();
    }
});

// Enforce max length dynamically
$(document).on("input", ".only-number", function () {
    let maxLength = $(this).data("maxlength");
    if (maxLength && this.value.length > maxLength) {
        this.value = this.value.slice(0, maxLength);
    }
});


function formatDateForInput(dateStr) {
    if (!dateStr) return "";
    const d = new Date(dateStr);
    const month = (d.getMonth() + 1).toString().padStart(2, '0');
    const day = d.getDate().toString().padStart(2, '0');
    const year = d.getFullYear();
    return `${year}-${month}-${day}`;
}


//For Optional Validation
function isValidFax(value) {
    let faxRegex = /^[0-9+\-\s]+$/;
    return faxRegex.test(value);
}

function isValidEmail(value) {
    let emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(value);
} 
function validateOptional(controlId, validatorFn, errorMsg) {
    let ctrl = $("#" + controlId);

    // Clear previous errors
    ctrl.removeClass("input-error");
    ctrl.next(".error-text").remove();

    let value = ctrl.val().trim();

    // Optional → allow empty
    if (value === "") return true;

    // Validate only if value entered
    if (!validatorFn(value)) {
        ctrl.addClass("input-error");
        ctrl.focus();
        ctrl.after(`<div class="error-text">${errorMsg}</div>`);
        return false;
    }

    return true;
}



