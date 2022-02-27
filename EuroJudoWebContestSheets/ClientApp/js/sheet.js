var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
import * as signalR from "@microsoft/signalr";
var Sheet = /** @class */ (function () {
    function Sheet() {
        this.Connection = null;
        this.Connected = this.Connected.bind(this);
        this.UpdateSheet = this.UpdateSheet.bind(this);
    }
    Sheet.prototype.Connected = function (message) {
        console.log(message);
        this.Connection.invoke("AddToGroup", "t" + this.TournamentId + "c" + this.CategoryId).catch(function (err) {
            return console.error(err.toString());
        });
    };
    Sheet.prototype.UpdateSheet = function (contestData) {
        console.log(contestData);
        if (this.Type == "RoundRobin") {
            var data = contestData;
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
        }
        else {
            document.getElementById(contestData.contest + 'W').innerHTML = contestData.competitorWhite;
            document.getElementById(contestData.contest + 'B').innerHTML = contestData.competitorBlue;
        }
    };
    Sheet.prototype.Start = function () {
        return __awaiter(this, void 0, void 0, function () {
            return __generator(this, function (_a) {
                this.TournamentId = window.tournamentID;
                this.CategoryId = window.categoryID;
                this.Type = window.contestType;
                // create the connection instance
                this.Connection = new signalR.HubConnectionBuilder()
                    .withUrl("/tournamentHub", { transport: signalR.HttpTransportType.WebSockets | signalR.HttpTransportType.LongPolling })
                    //.configureLogging(signalR.LogLevel.Trace)
                    .build();
                this.Connection.on('connected', this.Connected);
                this.Connection.on('updateSheet', this.UpdateSheet);
                this.Connection.start()
                    .then(function () { return console.info('SignalR Connected'); })
                    .catch(function (err) { return console.error('SignalR Connection Error: ', err); });
                return [2 /*return*/];
            });
        });
    };
    Sheet.prototype.CalculateScoreWhite = function (contest) {
        if (contest.iponWhite == 1 || contest.wazaariWhite == 2) {
            return 10;
        }
        if (contest.wazaariWhite == 1) {
            return 7;
        }
        return 0;
    };
    Sheet.prototype.CalculateScoreBlue = function (contest) {
        if (contest.iponBlue == 1 || contest.wazaariBlue == 2) {
            return 10;
        }
        if (contest.wazaariBlue == 1) {
            return 7;
        }
        return 0;
    };
    return Sheet;
}());
var sheet = new Sheet();
document.addEventListener("DOMContentLoaded", function () { return __awaiter(void 0, void 0, void 0, function () {
    return __generator(this, function (_a) {
        switch (_a.label) {
            case 0: return [4 /*yield*/, sheet.Start()];
            case 1:
                _a.sent();
                return [2 /*return*/];
        }
    });
}); });
