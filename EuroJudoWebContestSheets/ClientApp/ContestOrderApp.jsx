//https://blog.hellojs.org/fetching-api-data-with-react-js-460fe8bbf8f2


import React from 'react';
import ContestOrderList from './ContestOrderList';

export default class ContestOrderApp extends React.Component {
    constructor() {
        super();
        this.state = {
            ContestOrders: []
        };
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

    render() {
        return this.state.ContestOrders;
    }
}76