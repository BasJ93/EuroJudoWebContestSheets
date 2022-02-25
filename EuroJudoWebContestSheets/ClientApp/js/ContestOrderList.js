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
import * as React from "react";
var ContestOrderList = /** @class */ (function (_super) {
    __extends(ContestOrderList, _super);
    function ContestOrderList() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    ContestOrderList.prototype.render = function () {
        return (React.createElement("div", { key: this.props.Tatami, className: "col-lg-4 col-md-6 col-sm-12" },
            React.createElement("table", { className: "table table-striped" },
                React.createElement("thead", null,
                    React.createElement("tr", null,
                        React.createElement("th", { colSpan: 5 }, "Tatami " + this.props.Tatami))),
                React.createElement("tbody", null, this.props.Contests.map(function (contest, i) {
                    return (React.createElement("tr", { key: i },
                        React.createElement("td", null, contest.number),
                        React.createElement("td", null, contest.short),
                        React.createElement("td", null, contest.weight),
                        React.createElement("td", null, contest.competitorWhite),
                        React.createElement("td", null, contest.competitorBlue)));
                })))));
    };
    return ContestOrderList;
}(React.Component));
export { ContestOrderList };
