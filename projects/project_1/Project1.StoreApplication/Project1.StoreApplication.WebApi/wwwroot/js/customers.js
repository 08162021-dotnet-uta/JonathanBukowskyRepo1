

function LoadCustomers() {
    let container = document.querySelector('.customer-list');
    let template = document.querySelector('.template-customer');
    fetch('/api/customers')
        .then(res => {
            return res.json();
        }).then(data => {
            Models.RemoveGeneratedElements(container, 'generated-customer');
            data.forEach(cust => {
                console.log(cust);
                let customer = new Models.Customer(cust);
                let custElm = customer.CreateElementFromTemplate(template);
                container.appendChild(custElm);
            });
        });
}

window.addEventListener('load', function () {
    LoadCustomers();
});