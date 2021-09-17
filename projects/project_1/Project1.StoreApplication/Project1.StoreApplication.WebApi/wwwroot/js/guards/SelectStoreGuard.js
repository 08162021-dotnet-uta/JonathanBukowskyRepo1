

function RedirectToStoreSelect() {
    window.location.href = "/html/stores.html";
}

function ValidateSelectedStore() {
    let storeJSON = sessionStorage.selectedStore;
    if (!storeJSON) {
        RedirectToStoreSelect();
    }
    let store;
    try {
        store = JSON.parse(storeJSON);
    } catch {
        RedirectToStoreSelect();
    }
    if (!store) {
        RedirectToStoreSelect();
    }
    if (!store.storeId) {
        RedirectToStoreSelect();
    }
}