//https://blog.hellojs.org/fetching-api-data-with-react-js-460fe8bbf8f2
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    }
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
import React from 'react';
import ContestOrderList from './ContestOrderList';
var ContestOrderApp = /** @class */ (function (_super) {
    __extends(ContestOrderApp, _super);
    function ContestOrderApp() {
        var _this = _super.call(this) || this;
        _this.state = {
            ContestOrders: []
        };
        return _this;
    }
    ContestOrderApp.prototype.componentWillMount = function () {
        var _this = this;
        fetch('/ContestOrder/ContestOrderLists')
            .then(function (results) {
            return results.json();
        })
            .then(function (data) {
            //let width = { Math.floor(12.0 / data.lenght()) };
            var width = "col-lg-2";
            var lists = data.map(function (list) {
                return (React.createElement(ContestOrderList, { columnWidth: width, tatami: list.tatami, contests: list.contests }));
            });
            _this.setState({ ContestOrders: lists });
        });
    };
    ContestOrderApp.prototype.render = function () {
        return this.state.ContestOrders;
    };
    return ContestOrderApp;
}(React.Component));
export default ContestOrderApp;
76;
