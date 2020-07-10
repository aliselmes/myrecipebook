function Post(url, data, callback) {
    var xhr = new XMLHttpRequest();
    xhr.open("POST", url)
    xhr.setRequestHeader("Content-Type", "application/json")
    xhr.setRequestHeader("Accept", "application/json")

    var xsrfToken = document.querySelector("[name=__RequestVerificationToken]").value;
    xhr.setRequestHeader("XSRF-TOKEN", xsrfToken)
    xhr.onload = function (data) {
        
        callback(this.response);
    }
    xhr.send(JSON.stringify(data));
}


function Get(url, callback) {
    var xhr = new XMLHttpRequest();
    xhr.open("GET", url)
    xhr.setRequestHeader("Content-Type", "application/json")
    xhr.setRequestHeader("Accept", "application/json")

    xhr.onload = function () {
        callback(this.response);
    }
    xhr.send();
}
