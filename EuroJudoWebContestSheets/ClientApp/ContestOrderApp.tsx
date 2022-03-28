//https://blog.hellojs.org/fetching-api-data-with-react-js-460fe8bbf8f2

//https://stackoverflow.com/questions/46190574/how-to-import-signalr-in-react-component

import * as React from 'react';
import { ContestOrderList, IContest, IContestList } from './ContestOrderList';
import * as signalR from "@microsoft/signalr";

interface IContestOrderAppProps {
    ContestOrders: IContest[]
}

export default class ContestOrderApp extends React.Component<any, IContestOrderAppProps> {
    Connection: signalR.HubConnection;
    
    constructor(props) {
        super(props);
        this.state = {
            ContestOrders: []
        };

        this.Connection = null;
        this.connected = this.connected.bind(this);
        this.updateContestOrder = this.updateContestOrder.bind(this);
    }

    componentWillMount() {
        fetch('/ContestOrder/ContestOrderLists')
            .then(results => {
                return results.json();
            })
            .then(data => {
                if (data.length > 0) {
                    this.generateLists(data);
                }
            });
    }

    componentDidMount() {
        // create the connection instance
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

    componentWillUnmount() {
        this.Connection.stop();
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
        let lists = contestOrder.map((list: IContestList) => {
            return (<ContestOrderList key={list.tatami.toString()} Tatami={list.tatami} Contests={list.contests} />);
        });
        this.setState({ ContestOrders: lists });
    }

    render() {
        return this.state.ContestOrders;
    }
}