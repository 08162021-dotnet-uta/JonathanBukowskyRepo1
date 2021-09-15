

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

function MakeRemoveFromInventoryButton(storeId, product) {
    return `<button onclick="RemoveFromInventory(${storeId},${product.productId})">Remove</button>`;
}

function MakeAddToInventoryButton(storeId, product) {
    return `<button onclick="AddToInventory(${storeId},${product.productId})">Add</button>`
}

function RemoveFromInventory(storeId, productId) {
    console.log(`Remove ${productId} from inventory (${storeId})`)
    fetch(`/api/stores/${storeId}/products/remove`, {
        method: "POST",
        body: JSON.stringify({ productId }),
        headers: {
            'content-type': "application/json"
        }
    }).then(res => {
        return res.json();
    }).then(data => {
        console.log(data);
        let container = document.querySelector(".store-products-content");
        container.innerHTML = DisplayProductTable(data, storeId, MakeRemoveFromInventoryButton);
    })
}

function AddToInventory(storeId, productId) {
    fetch(`/api/stores/${storeId}/products/add`, {
        method: "POST",
        body: JSON.stringify({ productId }),
        headers: {
            'content-type': "application/json"
        }
    }).then(res => {
        return res.json();
    }).then(data => {
        console.log(data);
        let container = document.querySelector(".store-products-content");
        container.innerHTML = DisplayProductTable(data, storeId, MakeRemoveFromInventoryButton);
    })
}

function ViewInventory() {
    let homeDiv = document.querySelector(".home-content");
    let store = JSON.parse(sessionStorage.getItem("selectedStore"));
    console.log(`Manage Inventory for ${store.name}`);
    homeDiv.innerHTML = '<h2>Manage Inventory:</h2>'
        + '<div><h3>Inventory:</h3><div class="store-products-content"></div></div>'
        + '<div><h3>Products:</h3><div class="all-products-content"></div></div>';
    fetch(`/api/stores/${store.storeId}/products`)
        .then(res => {
            return res.json();
        }).then(data => {
            console.log(data);
            let container = document.querySelector(".store-products-content");
            container.innerHTML = DisplayProductTable(data, store.storeId, MakeRemoveFromInventoryButton);
        });
    fetch('/api/products')
        .then(res => {
            //console.log(res);
            return res.json();
        })
        .then(data => {
            //console.log(s);
            //data = JSON.parse(s);
            console.log(data);
            let container = document.querySelector(".all-products-content");
            /*
            let prodDisplay = "<table><thead><tr><th>Name</th><th>Price</th><th>Description</th><th></th></tr></thead><tbody>";
            if (data !== undefined) {
                data.forEach(product => {
                    prodDisplay += "<tr>";
                    prodDisplay += `<td>${product.name}</td>`;
                    prodDisplay += `<td>${product.price}</td>`;
                    prodDisplay += `<td>${product.description}</td>`;
                    prodDisplay += `<td><button onclick="AddToInventory(${store.storeId}, ${product.productId})">Add to inventory</button></td>`;
                    prodDisplay += "</tr>";
                });
            }
            prodDisplay += "</tbody></table>";
            */
            container.innerHTML = DisplayProductTable(data, store.storeId, MakeAddToInventoryButton);
        });
}

function ViewOrderHistory() {
    let homeDiv = document.querySelector(".home-content");
    console.log("View orders");
    homeDiv.innerHTML = "<h2>Order History:</h2>";
}


// TODO: write validation for session storage data

function GetAddToCartButtonFunc(customerId) {
    return (storeId, product) => `<button onclick="AddToCart(${customerId}, ${storeId}, ${product.productId})">Add</button>`;
}

function GetRemoveFromCartButtonFunc(customerId) {
    return (storeId, product) => `<button onclick="RemoveFromCart(${customerId}, ${storeId}, ${product.productId})">Remove</button>`;
}

function EditCart() {
    let homeDiv = document.querySelector(".home-content");
    console.log("Edit cart");
    homeDiv.innerHTML = '<h2>Cart:</h2><div class="cart-content"></div><div class="product-list"></div>';
    let cust = JSON.parse(sessionStorage.getItem("user"));
    let selectedStore = JSON.parse(sessionStorage.getItem("selectedStore"));
    fetch(`/api/customers/${cust.customerId}/cart`)
        .then(res => {
            return res.json()
        }).then(data => {
            console.log(data);
            let products = [];
            data.forEach(({ product, quantity }) => products.push({ ...product, quantity }));
            console.log("products: ", products);
            let container = document.querySelector(".cart-content");
            container.innerHTML = DisplayProductTable(products, selectedStore.storeId, GetRemoveFromCartButtonFunc(cust.customerId));
        }).catch(err => {
            console.log(err);
        });
    fetch(`/api/stores/${selectedStore.storeId}/products`)
        .then(res => {
            return res.json();
        }).then(data => {
            console.log(data);
            let container = document.querySelector(".product-list");
            container.innerHTML = DisplayProductTable(data, selectedStore.storeId, GetAddToCartButtonFunc(cust.customerId));
        });
}

function AddToCart(customerId, storeId, productId) {
    fetch(`/api/customers/${customerId}/cart/add`, {
        method: "POST",
        body: JSON.stringify({ storeId, productId }),
        headers: {
            'content-type': "application/json"
        }
    }).then(res => {
        return res.json();
    }).then(data => {
        console.log(data);
        let products = [];
        data.forEach(({ product, quantity }) => products.push({ ...product, quantity }));
        console.log("products: ", products);
        let container = document.querySelector(".cart-content");
        container.innerHTML = DisplayProductTable(products, storeId, GetRemoveFromCartButtonFunc(customerId));
    })
}

function RemoveFromCart(customerId, storeId, productId) {
    fetch(`/api/customers/${customerId}/cart/remove`, {
        method: "POST",
        body: JSON.stringify({ storeId, productId }),
        headers: {
            'content-type': "application/json"
        }
    }).then(res => {
        return res.json();
    }).then(data => {
        console.log(data);
        let products = [];
        //data.forEach(({ product, quantity }) => products.push(product));
        data.forEach(({ product, quantity }) => products.push({ ...product, quantity }));
        let container = document.querySelector(".cart-content");
        container.innerHTML = DisplayProductTable(products, storeId, GetRemoveFromCartButtonFunc(customerId));
    })
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
