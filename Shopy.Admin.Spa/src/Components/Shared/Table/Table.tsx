import React from 'react'
import { TableProps } from "./Types/TableProps";
import { Link } from 'react-router-dom';

export const Table: React.FC<TableProps> = (props) =>
    <React.Fragment>
        <h2>{props.Title} <Link to={props.AddItemUrl} className="btn btn-success">Add</Link></h2>
        <div className="table-responsive">
            <table className="table table-striped table-sm">
                <thead>
                    <tr>
                        <th>#</th>
                        {
                            props.Header.map(item => <th>{item.Name}</th>)
                        }
                        <th colSpan={props.ActionsCount}>Actions</th>
                    </tr>
                </thead >
                <tbody>
                    {
                        props.RenderBody()
                    }
                </tbody>
            </table>
        </div>
    </React.Fragment>
