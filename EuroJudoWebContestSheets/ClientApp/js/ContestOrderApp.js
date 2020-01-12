//https://blog.hellojs.org/fetching-api-data-with-react-js-460fe8bbf8f2
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
//https://stackoverflow.com/questions/46190574/how-to-import-signalr-in-react-component
import React from 'react';
import ContestOrderList from './ContestOrderList';
var ContestOrderApp = /** @class */ (function (_super) {
    __extends(ContestOrderApp, _super);
    function ContestOrderApp(props) {
        var _this = _super.call(this, props) || this;
        _this.state = {
            ContestOrders: []
        };
        _this.connection = null;
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
                _this.generateLists(contestOrder);
            }
        });
    };
    ContestOrderApp.prototype.componentDidMount = function () {
        // create the connection instance
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl("/contestOrderHub", { transport: signalR.HttpTransportType.WebSockets | signalR.HttpTransportType.LongPolling })
            .configureLogging(signalR.LogLevel.Trace)
            .build();
        this.connection.on('connected', this.connected);
        this.connection.on('updateContestOrder', this.updateContestOrder);
        this.connection.start()
            .then(function () { return console.info('SignalR Connected'); })
            .catch(function (err) { return console.error('SignalR Connection Error: ', err); });
    };
    ContestOrderApp.prototype.componentWillUnmount = function () {
        this.connection.stop();
    };
    ContestOrderApp.prototype.connected = function (message) {
        console.log(message);
    };
    ContestOrderApp.prototype.updateContestOrder = function (contestOrder) {
        console.log("Received new contest data");
        this.generateLists(contestOrder);
    };
    ContestOrderApp.prototype.generateLists = function (contestOrder) {
        var lists = contestOrder.map(function (list) {
            return (React.createElement(ContestOrderList, { key: list.tatami.toString(), tatami: list.tatami, contests: list.contests }));
        });
        this.setState({ ContestOrders: lists });
    };
    ContestOrderApp.prototype.render = function () {
        return this.state.ContestOrders;
    };
    return ContestOrderApp;
}(React.Component));
export default ContestOrderApp;
