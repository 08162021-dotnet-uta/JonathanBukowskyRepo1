

function login(e) {
    console.log("Logging in...");
    e.preventDefault();

    let form = e.target.parentElement;
    let username = form[0].value;
    let password = form[1].value;
    let reqObj =
    {
        username,
        password
    }
    fetch("/api/login", {
        method: "POST",
        body: JSON.stringify(reqObj)
    }).then(res => res.json)
        .then(data => {
            if (data.success) {
                sessionStorage.setItem("customerId", data.customerId);
                window.location.href = "/stores.html";
            }
            else {
                // TODO: add validation feedback
            }
        });
}

document.addEventListener("DOMContentLoaded", function (event) {
    document.getElementById("login_button")
        .addEventListener("click", login);
});
