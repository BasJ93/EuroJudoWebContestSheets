import * as signalR from "@microsoft/signalr";
import IContestData, { IRoundRobinContestData } from "./ContestData";

class Sheet {
    Connection: signalR.HubConnection;
    Type: string;
    TournamentId: string;
    CategoryId: string;

    constructor() {
        this.Connection = null;
        this.Connected = this.Connected.bind(this);
        this.UpdateSheet = this.UpdateSheet.bind(this);
    }

    Connected(message) {
        console.log(message);
        this.Connection.invoke("AddToGroup", "t" + this.TournamentId + "c" + this.CategoryId).catch(function (err) {
            return console.error(err.toString());
        });
    }

    UpdateSheet(contestData: IContestData) {
        console.log(contestData);
        if (this.Type == "RoundRobin") {
            let data = (<IRoundRobinContestData>contestData);

            if (data.competitors.length >= 1) {
                document.getElementById("Competitor1").innerHTML = data.competitors[0].name;
                document.getElementById("WinComp1").innerHTML = data.competitors[0].won.toString();
                document.getElementById("PuntComp1").innerHTML = data.competitors[0].score.toString();
                if (data.competitors[0].position != 0) {
                    document.getElementById("ResComp1").innerHTML = data.competitors[0].position.toString();
                }
            }

            if (data.competitors.length >= 2) {
                document.getElementById("Competitor2").innerHTML = data.competitors[1].name;
                document.getElementById("WinComp2").innerHTML = data.competitors[1].won.toString();
                document.getElementById("PuntComp2").innerHTML = data.competitors[1].score.toString();
                if (data.competitors[1].position != 0) {
                    document.getElementById("ResComp2").innerHTML = data.competitors[1].position.toString();
                }
            }

            if (data.competitors.length >= 3) {
                document.getElementById("Competitor3").innerHTML = data.competitors[2].name;
                document.getElementById("WinComp3").innerHTML = data.competitors[2].won.toString();
                document.getElementById("PuntComp3").innerHTML = data.competitors[2].score.toString();
                if (data.competitors[2].position != 0) {
                    document.getElementById("ResComp3").innerHTML = data.competitors[2].position.toString();
                }
            }

            if (!!document.getElementById("Competitor4")) {
                if (data.competitors.length >= 4) {
                    document.getElementById("Competitor4").innerHTML = data.competitors[3].name;
                    document.getElementById("WinComp4").innerHTML = data.competitors[3].won.toString();
                    document.getElementById("PuntComp4").innerHTML = data.competitors[3].score.toString();
                    if (data.competitors[3].position != 0) {
                        document.getElementById("ResComp4").innerHTML = data.competitors[3].position.toString();
                    }
                }
            }

            if (!!document.getElementById("Competitor5")) {
                if (data.competitors.length >= 5) {
                    document.getElementById("Competitor5").innerHTML = data.competitors[4].name;
                    document.getElementById("WinComp5").innerHTML = data.competitors[4].won.toString();
                    document.getElementById("PuntComp5").innerHTML = data.competitors[4].score.toString();
                    if (data.competitors[4].position != 0) {
                        document.getElementById("ResComp5").innerHTML = data.competitors[4].position.toString();
                    }
                }
            }

            if (!!document.getElementById("Competitor6")) {
                if (data.competitors.length >= 6) {
                    document.getElementById("Competitor6").innerHTML = data.competitors[5].name;
                    document.getElementById("WinComp6").innerHTML = data.competitors[5].won.toString();
                    document.getElementById("PuntComp6").innerHTML = data.competitors[5].score.toString();
                    if (data.competitors[5].position != 0) {
                        document.getElementById("ResComp6").innerHTML = data.competitors[5].position.toString();
                    }
                }
            }

            document.getElementById(contestData.contest + 'W').innerHTML = this.CalculateScoreWhite(data).toString();
            document.getElementById(contestData.contest + 'B').innerHTML = this.CalculateScoreBlue(data).toString();
        } else {
            document.getElementById(contestData.contest + 'W').innerHTML = contestData.competitorWhite;
            document.getElementById(contestData.contest + 'B').innerHTML = contestData.competitorBlue;
        }
    }

    async Start() {
        this.TournamentId = (<any>window).tournamentID;
        this.CategoryId = (<any>window).categoryID;
        this.Type = (<any>window).contestType;

        // create the connection instance
        this.Connection = new signalR.HubConnectionBuilder()
            .withUrl("/tournamentHub", { transport: signalR.HttpTransportType.WebSockets | signalR.HttpTransportType.LongPolling })
            //.configureLogging(signalR.LogLevel.Trace)
            .build();

        this.Connection.on('connected', this.Connected);
        this.Connection.on('updateSheet', this.UpdateSheet);

        this.Connection.start()
            .then(() => console.info('SignalR Connected'))
            .catch(err => console.error('SignalR Connection Error: ', err));
    }

    CalculateScoreWhite(contest: IContestData): number {
        if (contest.iponWhite == 1 || contest.wazaariWhite == 2) {
            return 10;
        }
        if (contest.wazaariWhite == 1) {
            return 7;
        }
        return 0;
    }

    CalculateScoreBlue(contest: IContestData): number {
        if (contest.iponBlue == 1 || contest.wazaariBlue == 2) {
            return 10;
        }
        if (contest.wazaariBlue == 1) {
            return 7;
        }
        return 0;
    }
}

let sheet = new Sheet();

document.addEventListener("DOMContentLoaded", async () => {
    await sheet.Start();
});