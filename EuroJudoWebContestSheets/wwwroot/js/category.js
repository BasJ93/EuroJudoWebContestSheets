"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/tournamentHub", { transport: signalR.HttpTransportType.WebSockets | signalR.HttpTransportType.LongPolling })
    //.configureLogging(signalR.LogLevel.Trace)
    .build();

connection.on("updateSheet", function (contestData) {
    console.log(contestData);
    $('#' + contestData.contest + 'W').text(contestData.compeditorWhite);
    $('#' + contestData.contest + 'B').text(contestData.compeditorBlue);
});

connection.on("connected", function (data) {
    connection.invoke("AddToGroup", "t" + tournamentID + "c" + categoryID).catch(function (err) {
        return console.error(err.toString());
    });
});

async function start() {
    try {
        await connection.start();
        console.log('connected');
    } catch (err) {
        console.log(err);
        setTimeout(() => start(), 5000);
    }
};

connection.onclose(async () => {
    await start();
});

/*connection.start().catch(function (err) {
    return console.error(err.toString());
});*/

document.addEventListener("DOMContentLoaded", async () => {
    await start();
});