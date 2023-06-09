﻿"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chat").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;


function sendMsg() {
    var message = document.getElementById("messageInput").value;
    if (message == "") return;
    connection.invoke("SendMessage", message).catch(function (err) {
        return console.error(err.toString());
    });
    document.getElementById("messageInput").value = "";
    event.preventDefault();
}

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    li.textContent = `${user}: ${message}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    sendMsg();
});

document.getElementById("messageInput").addEventListener("keydown", function (event) {
    console.log(event.keyCode);
    if (event.keyCode == 13) {
        sendMsg();
    };
})