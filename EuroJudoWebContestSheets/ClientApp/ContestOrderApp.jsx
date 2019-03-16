//https://blog.hellojs.org/fetching-api-data-with-react-js-460fe8bbf8f2

//https://stackoverflow.com/questions/46190574/how-to-import-signalr-in-react-component

import React from 'react';
import ContestOrderList from './ContestOrderList';

export default class ContestOrderApp extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            ContestOrders: []
        };

        this.connection = null;
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
                    this.generateLists(contestOrder);
                }
            });
    }

    componentDidMount() {
        // create the connection instance
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl("/contestOrderHub", { transport: signalR.HttpTransportType.WebSockets | signalR.HttpTransportType.LongPolling })
            .configureLogging(signalR.LogLevel.Trace)
            .build();

        this.connection.on('connected', this.connected);
        this.connection.on('updateContestOrder', this.updateContestOrder);
        
        this.connection.start()
            .then(() => console.info('SignalR Connected'))
            .catch(err => console.error('SignalR Connection Error: ', err));
    }

    componentWillUnmount() {
        this.connection.stop();
    }

    connected(message) {
        console.log(message);
    }

    updateContestOrder(contestOrder) {
        console.log("Received new contest data");
        this.generateLists(contestOrder);
    }

    generateLists(contestOrder) {
        let lists = contestOrder.map((list) => {
            return (<ContestOrderList key={list.tatami.toString()} tatami={list.tatami} contests={list.contests} />);
        });
        this.setState({ ContestOrders: lists });
    }

    render() {
        return this.state.ContestOrders;
    }
}