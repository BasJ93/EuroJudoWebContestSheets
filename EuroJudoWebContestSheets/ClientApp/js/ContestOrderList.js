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
var ConstestOrderList = /** @class */ (function (_super) {
    __extends(ConstestOrderList, _super);
    function ConstestOrderList() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    ConstestOrderList.prototype.render = function () {
        return (React.createElement("div", { key: this.props.tatami, className: "col-lg-4" },
            React.createElement("table", { className: "table table-striped" },
                React.createElement("thead", null,
                    React.createElement("tr", null,
                        React.createElement("th", null,
                            "Tatami ",
                            this.props.tatami))),
                React.createElement("tbody", null, this.props.contests.map(function (contest, i) {
                    return (React.createElement("tr", { key: i },
                        React.createElement("td", null, contest)));
                })))));
    };
    return ConstestOrderList;
}(React.Component));
export default ConstestOrderList;
