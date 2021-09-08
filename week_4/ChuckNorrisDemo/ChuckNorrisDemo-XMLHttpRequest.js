
(function RequestWithXML() {
    let xhr = new XMLHttpRequest();

    xhr.open("GET", "http://api.icndb.com/jokes/random/5");

    xhr.onload = function () {
        if (xhr.status >= 200 && xhr.status < 300) {
            console.log(xhr.responseText);
            let result = JSON.parse(xhr.responseText);
            let jokes = result.value;
            let paragraphs = document.querySelectorAll("p");
            for (let i = 0; i < jokes.length; i++) {
                paragraphs[i].innerHTML = jokes[i].joke;
            }
        }
    }

    xhr.send();
})();
