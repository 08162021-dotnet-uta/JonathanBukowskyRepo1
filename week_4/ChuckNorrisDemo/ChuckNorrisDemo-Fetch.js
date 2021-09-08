
(function RequestWithFetch() {

    fetch("http://api.icndb.com/jokes/random/5")
        .then(res => {
            if (!res.ok) {
                throw new Error("Error loading jokes");
            }
            return res.json();
        })
        .then(data => {
            let jokes = data.value;
            let paragraphs = document.querySelectorAll("p");
            for (let i = 0; i < jokes.length; i++) {
                paragraphs[i].innerHTML = jokes[i].joke;
            }
        })
        .catch(err => console.log(`Error loading jokes: ${err}`));
})();
