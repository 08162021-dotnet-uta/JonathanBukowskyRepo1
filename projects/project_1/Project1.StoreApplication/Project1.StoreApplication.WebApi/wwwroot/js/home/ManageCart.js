
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
    fetch(`/api/customers/${cust.customerId}/cart/${selectedStore.storeId}`)
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
    fetch(`/api/customers/${customerId}/cart/${storeId}/add`, {
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
    fetch(`/api/customers/${customerId}/cart/${storeId}/remove`, {
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
