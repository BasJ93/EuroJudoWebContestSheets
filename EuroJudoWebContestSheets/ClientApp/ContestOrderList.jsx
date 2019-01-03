﻿import React, { Component } from 'react';
export default class ConstestOrderList extends React.Component {
    render() {
        return (
            <div key={this.props.tatami} className="col-lg-4">
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
                                <td>{contest}</td>
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