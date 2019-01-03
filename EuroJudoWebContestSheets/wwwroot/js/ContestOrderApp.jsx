//https://blog.hellojs.org/fetching-api-data-with-react-js-460fe8bbf8f2


import ContestOrderList from './ContestOrderList.jsx';

class ContestOrderApp extends React.Component {
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
                let lists = data.map((list) => {
                    return (<ContestOrderList tatami={list.tatami} contests={list.contests} />);
                });
                this.setState({ ContestOrders: lists });
            });
    }

    render() {
        return this.state.ContestOrders;
    }
}

ReactDOM.render(
    <ContestOrderApp />,
    document.getElementById('contestorderapp')
);