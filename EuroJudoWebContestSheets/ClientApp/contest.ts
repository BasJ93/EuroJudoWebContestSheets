import * as signalR from "@microsoft/signalr";
import {ContestOrderList, IContest} from "./ContestOrderList"

interface IContestList {
    tatami: number,
    contests: IContest[]
}

const appTemplate = document.createElement("template");
appTemplate.innerHTML = `
    <div class="container-fluid">
        <div id="contest-order-app" class="row">
        </div>
    </div>
`;

class ContestOrder extends HTMLElement {
    Connection: signalR.HubConnection;

    constructor() {
        super();

        // Setup the environment for SignalR
        this.Connection = null;
        this.connected = this.connected.bind(this);
        this.updateContestOrder = this.updateContestOrder.bind(this);
        this.configureSignalR = this.configureSignalR.bind(this);
        this.fetchInitialData = this.fetchInitialData.bind(this);

        // Setup component
        let shadow = this.attachShadow({ mode: 'open' });
        this.shadowRoot.appendChild(appTemplate.content.cloneNode(true));

        const linkElem = document.createElement('link');
        linkElem.setAttribute('rel', 'stylesheet');
        linkElem.setAttribute('href', 'https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css');

        shadow.appendChild(linkElem);
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
            document.getElementById('reconnect-indicator').style.visibility = "hidden";
            document.getElementById('overlay').style.visibility = "hidden";
        });

        this.Connection.start()
            .then(() => console.info('SignalR Connected'))
            .catch(err => console.error('SignalR Connection Error: ', err));
    }

    fetchInitialData() {
        fetch('api/ContestOrder/ContestOrderLists')
            .then(results => {
                return results.json();
            })
            .then(data => {
                if (data?.length > 0) {
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
        contestOrder.map((list: IContestList) => {
            let newList = new ContestOrderList(list.tatami, list.contests);
            newList.classList.add("col-xl-3", "col-lg-4", "col-md-6", "col-sm-12");
            container.appendChild(newList);
        });
    }
}

window.customElements.define('contest-order-app', ContestOrder);