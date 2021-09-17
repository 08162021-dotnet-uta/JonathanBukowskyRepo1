
function RedirectToLogin() {
    window.location.href = "/index.html";
}

function ValidateLogin() {
    let userJSON = sessionStorage.user;
    if (!userJSON) {
        RedirectToLogin();
    }
    let user;
    try {
        user = JSON.parse()
    } catch {
        RedirectToLogin();
    }
    if (!user) {
        RedirectToLogin();
    }
    if (!user.customerId) {
        RedirectToLogin();
    }
}

// could wait for page load, but that's not necessary
ValidateLogin();
