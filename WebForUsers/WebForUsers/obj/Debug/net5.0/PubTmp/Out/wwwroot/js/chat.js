"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.on("ReceiveMessage", function (user, topic) {
    //if (confirm(`${user} send message with the topic ${topic}. Do you want to see new message list ?`)) {
    //    window.location.href = "/Message/Index";
    //}
    alert(`${user} send message with the topic ${topic}`);
    window.location.href = "/Message/Index";
});

connection.on("notification", function (message) {
    document.getElementById("notification").textContent = `${message}`;
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var topic = document.getElementById("topicInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, topic, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});