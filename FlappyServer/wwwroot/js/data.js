"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/dataHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("UserDead", function (user) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${user} up`;
});


connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});
document.getElementById("startButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("startGame", user).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("DeadStatus").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});