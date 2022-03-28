//https://blog.hellojs.org/fetching-api-data-with-react-js-460fe8bbf8f2
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
//https://stackoverflow.com/questions/46190574/how-to-import-signalr-in-react-component
import * as React from 'react';
import { ContestOrderList } from './ContestOrderList';
import * as signalR from "@microsoft/signalr";
var ContestOrderApp = /** @class */ (function (_super) {
    __extends(ContestOrderApp, _super);
    function ContestOrderApp(props) {
        var _this = _super.call(this, props) || this;
        _this.state = {
            ContestOrders: []
        };
        _this.Connection = null;
        _this.connected = _this.connected.bind(_this);
        _this.updateContestOrder = _this.updateContestOrder.bind(_this);
        return _this;
    }
    ContestOrderApp.prototype.componentWillMount = function () {
        var _this = this;
        fetch('/ContestOrder/ContestOrderLists')
            .then(function (results) {
            return results.json();
        })
            .then(function (data) {
            if (data.length > 0) {
                _this.generateLists(data);
            }
        });
    };
    ContestOrderApp.prototype.componentDidMount = function () {
        // create the connection instance
        this.Connection = new signalR.HubConnectionBuilder()
            .withUrl("/contestOrderHub", { transport: signalR.HttpTransportType.WebSockets | signalR.HttpTransportType.LongPolling })
            .withAutomaticReconnect([0, 500, 1000, 5000])
            //.configureLogging(signalR.LogLevel.Trace)
            .build();
        this.Connection.on('connected', this.connected);
        this.Connection.on('updateContestOrder', this.updateContestOrder);
        this.Connection.onreconnecting(function (error) {
            document.getElementById('overlay').style.visibility = "visible";
            document.getElementById('reconnect-indicator').style.visibility = "visible";
        });
        this.Connection.onreconnected(function (connectionId) {
            document.getElementById('overlay').style.visibility = "hidden";
            document.getElementById('reconnect-indicator').style.visibility = "hidden";
        });
        this.Connection.onclose(function (error) {
            document.getElementById('disconnected-indicator').style.visibility = "visible";
            document.getElementById('overlay').style.visibility = "hidden";
        });
        this.Connection.start()
            .then(function () { return console.info('SignalR Connected'); })
            .catch(function (err) { return console.error('SignalR Connection Error: ', err); });
    };
    ContestOrderApp.prototype.componentWillUnmount = function () {
        this.Connection.stop();
    };
    ContestOrderApp.prototype.connected = function (message) {
        console.log(message);
        document.getElementById('overlay').style.visibility = "hidden";
    };
    ContestOrderApp.prototype.updateContestOrder = function (contestOrder) {
        console.log("Received new contest data");
        this.generateLists(contestOrder);
    };
    ContestOrderApp.prototype.generateLists = function (contestOrder) {
        var lists = contestOrder.map(function (list) {
            return (React.createElement(ContestOrderList, { key: list.tatami.toString(), Tatami: list.tatami, Contests: list.contests }));
        });
        this.setState({ ContestOrders: lists });
    };
    ContestOrderApp.prototype.render = function () {
        return this.state.ContestOrders;
    };
    return ContestOrderApp;
}(React.Component));
export default ContestOrderApp;
