//https://blog.hellojs.org/fetching-api-data-with-react-js-460fe8bbf8f2

//https://stackoverflow.com/questions/46190574/how-to-import-signalr-in-react-component

import React from 'react';
import ContestOrderList from './ContestOrderList';
require('signalr');

export default class ContestOrderApp extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            ContestOrders: []
        };

        this.connection = null;
        this.updateContestOrder = this.updateContestOrder.bind(this);
    }

    componentWillMount() {
        fetch('/ContestOrder/ContestOrderLists')
            .then(results => {
                return results.json();
            })
            .then(data => {
                //let width = { Math.floor(12.0 / data.lenght()) };
                let width = "col-lg-2";
                let lists = data.map((list) => {
                    return (<ContestOrderList columnWidth={width} tatami={list.tatami} contests={list.contests} />);
                });
                this.setState({ ContestOrders: lists });
            });
    }

    componentDidMount() {
        // create the connection instance
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl("/contestOrderHub")
            .build();

        this.connection.on('updateContestOrder', this.updateContestOrder);
        
        this.connection.start()
            .then(() => console.info('SignalR Connected'))
            .catch(err => console.error('SignalR Connection Error: ', err));
    }

    componentWillUnmount() {
        this.connection.stop();
    }

    updateContestOrder(contestOrder) {
        let lists = contestOrder.map((list) => {
            return (<ContestOrderList columnWidth={width} tatami={list.tatami} contests={list.contests} />);
        });
        this.setState({ ContestOrders: lists });
    }

    render() {
        return this.state.ContestOrders;
    }
}