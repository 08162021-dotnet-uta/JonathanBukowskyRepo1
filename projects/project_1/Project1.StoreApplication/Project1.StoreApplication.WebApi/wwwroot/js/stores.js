
let htmlBeginContent = '<table><thead><tr><th>Name</th><th></th></tr></thead><tbody>';
let htmlEndContent = '</tbody></table>';

function PopulateStores() {
    let storeDiv = document.getElementById("storeList");
    console.log(storeDiv);
    fetch("/api/stores")
        .then(res => res.json())
        .then(data => {
            console.log(data)
            let htmlContent = "";
            data.forEach((store) => {
                htmlContent += DisplayStore(store);
            });
            storeDiv.innerHTML = `${htmlBeginContent}${htmlContent}${htmlEndContent}`;
        });

}

function chooseStore(storeId) {
    console.log(`Selecting store ${storeId}`);
    fetch(`/api/stores/select/${storeId}`, { method: "POST" })
        .then(res => res.json())
        .then(data => {
            if (data.success) {
                sessionStorage.setItem("selectedStore", JSON.stringify(data.store));
                console.log(JSON.parse(sessionStorage.getItem("selectedStore")));
                window.location.href = "/html/home.html";
            } else {
                throw new Exception("Error selecting store");
            }
        }).catch(err => {
            console.log(err)
        });
}

function getButtonHTML(store, selectedId) {
    let disabledText = '';
    if (store.storeId == selectedId) {
        disabledText = 'disabled';
    }
    return `<button ${disabledText} onclick="chooseStore(${store.storeId})">Select</button>`;
}

function DisplayStore(store) {
    return `<tr><td>${store.name}</td><td>${getButtonHTML(store)}</td></tr>`;
}

document.addEventListener("DOMContentLoaded", function (event) {
    PopulateStores();
});