

function DisplayProduct(product) {
    // TODO:
    return `<p>Product: ${product.name} Price: ${product.price} Description: ${product.description}</p>`;
}

function ViewProducts() {
    let homeDiv = document.querySelector(".home-content");
    console.log("View products");
    homeDiv.innerHTML = "<h2>Products:</h2>";
}

function ViewOrderHistory() {
    let homeDiv = document.querySelector(".home-content");
    console.log("View orders");
    homeDiv.innerHTML = "<h2>Order History:</h2>";
}

function EditCart() {
    let homeDiv = document.querySelector(".home-content");
    console.log("Edit cart");
    homeDiv.innerHTML = "<h2>Cart:</h2>";
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
