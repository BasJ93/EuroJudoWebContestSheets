import * as signalR from "@microsoft/signalr";
import { ContestOrderList } from "./ContestOrderList";
const appTemplate = document.createElement("template");
appTemplate.innerHTML = `<div id="contest-order-app" class="container-fluid"></div>`;
class ContestOrder extends HTMLElement {
    constructor() {
        super();
        // Setup the environment for SignalR
        this.Connection = null;
        this.connected = this.connected.bind(this);
        this.updateContestOrder = this.updateContestOrder.bind(this);
        this.configureSignalR = this.configureSignalR.bind(this);
        this.fetchInitialData = this.fetchInitialData.bind(this);
        // Setup component
        this.attachShadow({ mode: 'open' });
        this.shadowRoot.appendChild(appTemplate.content.cloneNode(true));
    }
    connectedCallback() {
        this.configureSignalR();
        this.fetchInitialData();
    }
    configureSignalR() {
        this.Connection = new signalR.HubConnectionBuilder()
            .withUrl("/contestOrderHub", { transport: signalR.HttpTransportType.WebSockets | signalR.HttpTransportType.LongPolling })
            .withAutomaticReconnect([0, 500, 1000, 5000])
            //.configureLogging(signalR.LogLevel.Trace)
            .build();
        this.Connection.on('connected', this.connected);
        this.Connection.on('updateContestOrder', this.updateContestOrder);
        this.Connection.onreconnecting(error => {
            document.getElementById('overlay').style.visibility = "visible";
            document.getElementById('reconnect-indicator').style.visibility = "visible";
        });
        this.Connection.onreconnected(connectionId => {
            document.getElementById('overlay').style.visibility = "hidden";
            document.getElementById('reconnect-indicator').style.visibility = "hidden";
        });
        this.Connection.onclose(error => {
            document.getElementById('disconnected-indicator').style.visibility = "visible";
            document.getElementById('overlay').style.visibility = "hidden";
        });
        this.Connection.start()
            .then(() => console.info('SignalR Connected'))
            .catch(err => console.error('SignalR Connection Error: ', err));
    }
    fetchInitialData() {
        fetch('/ContestOrder/ContestOrderLists')
            .then(results => {
            return results.json();
        })
            .then(data => {
            if ((data === null || data === void 0 ? void 0 : data.length) > 0) {
                this.generateLists(data);
            }
        });
    }
    connected(message) {
        console.log(message);
        document.getElementById('overlay').style.visibility = "hidden";
    }
    updateContestOrder(contestOrder) {
        console.log("Received new contest data");
        this.generateLists(contestOrder);
    }
    generateLists(contestOrder) {
        let container = this.shadowRoot.getElementById("contest-order-app");
        // Clear all existing children
        while (container.lastElementChild) {
            container.removeChild(container.lastElementChild);
        }
        // Add the new contest orders
        contestOrder.map((list) => {
            container.appendChild(new ContestOrderList(list.tatami, list.contests));
        });
    }
}
window.customElements.define('contest-order-app', ContestOrder);
