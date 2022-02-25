import * as React from "react";

export interface IContest {
    number: number,
    short: string,
    weight: string,
    competitorWhite: string,
    competitorBlue: string
}

export interface IContestList {
    tatami: number,
    contests: IContest[]
}

interface ContestOrderListProps {
    Tatami: number,
    Contests: IContest[]
}

export class ContestOrderList extends React.Component<ContestOrderListProps>{
    render() {
        return (
            <div key={this.props.Tatami} className="col-lg-4 col-md-6 col-sm-12">
                <table className="table table-striped">
                    <thead>
                        <tr>
                            <th colSpan={5}>{"Tatami " + this.props.Tatami}</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.props.Contests.map(function (contest, i) {
                            return (
                                <tr key={i}>
                                    <td>{contest.number}</td>
                                    <td>{contest.short}</td>
                                    <td>{contest.weight}</td>
                                    <td>{contest.competitorWhite}</td>
                                    <td>{contest.competitorBlue}</td>
                                </tr>
                            );
                        })
                        }
                    </tbody>
                </table>
            </div>
        )
    }
}