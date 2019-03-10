import React, { Component } from 'react';
export default class ConstestOrderList extends React.Component {
    render() {
        return (
            <div key={this.props.tatami} className="col-lg-4 col-md-6 col-sm-12">
                <table className="table table-striped">
                    <thead>
                        <tr>
                            <th>Tatami {this.props.tatami}</th>
                        </tr>
                    </thead>
                    <tbody>
                    {this.props.contests.map(function (contest, i) {
                            return (
                            <tr key={i}>
                                    <td>{contest.number}</td>
                                    <td>{contest.short}</td>
                                    <td>{contest.weight}</td>
                                    <td>{contest.compeditorWhite}</td>
                                    <td>{contest.compeditorBlue}</td>
                            </tr>
                        );
                        })
                    }
                    </tbody>
                </table>
            </div>
        );
    }
}