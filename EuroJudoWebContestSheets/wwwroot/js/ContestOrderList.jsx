class ConstestOrderList extends React.Component {
    render() {
        return (
            <table className="table table-striped">
                <thead>
                    <th>Tatami {props.tatami}</th>
                </thead>
                {this.props.contests.map(function (contest) {
                    return (
                        <tr>
                            <td>{contest}</td>
                        </tr>
                    );
                })
                }
            </table>
        );
    }
}

export default function () { return null; }