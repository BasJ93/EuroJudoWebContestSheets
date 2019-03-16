"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/tournamentHub", { transport: signalR.HttpTransportType.WebSockets | signalR.HttpTransportType.LongPolling })
    .configureLogging(signalR.LogLevel.Trace)
    .build();

connection.on("updateSheet", function (contestData) {
    $('#' + contestData.contest + 'W').text(contestData.compeditorWhite);
    $('#' + contestData.contest + 'B').text(contestData.compeditorBlue);
});

connection.on("connected", function (data) {
    connection.invoke("AddToGroup", "t" + tournamentID + "c" + categoryID).catch(function (err) {
        return console.error(err.toString());
    });
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});