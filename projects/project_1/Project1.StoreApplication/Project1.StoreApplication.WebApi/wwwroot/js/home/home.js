

function DisplayProduct(product) {
    // TODO:
    return `<p>Product: ${product.name} Price: ${product.price} Description: ${product.description}</p>`;
}

function DisplayProductTable(products, storeId, getButton) {
    let prodDisplay = "<table><thead><tr><th>Name</th><th>Price</th><th>Description</th><th>Quantity</th><th></th></tr></thead><tbody>";
    if (products !== undefined) {
        products.forEach(product => {
            prodDisplay += "<tr>";
            prodDisplay += `<td>${product.name}</td>`;
            prodDisplay += `<td>${product.price}</td>`;
            prodDisplay += `<td>${product.description}</td>`;
            prodDisplay += `<td>${product.quantity > 0 ? product.quantity : ""}</td>`;
            prodDisplay += `<td>${getButton(storeId, product)}</td>`;
            prodDisplay += "</tr>";
        });
    }
    prodDisplay += "</tbody></table>";
    return prodDisplay;
}


function ViewOrderHistory() {
    let homeDiv = document.querySelector(".home-content");
    console.log("View orders");
    homeDiv.innerHTML = "<h2>Order History:</h2>";
}


function ChangeStore() {
    sessionStorage.removeItem("selectedStore");
    window.location.href = "/html/stores.html";
}

function Logout() {
    sessionStorage.removeItem("selectedStore");
    sessionStorage.removeItem("user");
    window.location.href = "/index.html";
}
