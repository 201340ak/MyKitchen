import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import * as e6p from "es6-promise";
(e6p as any).polyfill();
import 'isomorphic-fetch';

interface DynamicListState{
    items: string[];
}

export class DynamicListComponent extends React.Component<RouteComponentProps<{}>, DynamicListState> {
    constructor() {
        super();
        this.state = { items: []};
    }

    public render() {
        return <div>
                { this.GetInput(1) }
            </div>
    }

    public GetInput(count: number)
    {
        var buttonId = "button-number-" + count;
        var button = <button className="btn glyphicon glyphicon-plus" id={ buttonId } onClick={ e => this.AddToList() }/> 
        var input = <input className="col-xs-4" id="item-input" placeholder="Add item to the list" />
        return <div className="row">{ input } { button } </div>;
    }

    private AddToList()
    {
        // add value of input to items list
        // render list
        // clear input
    }

    private AddInputValueToList()
    {
        var inputValue = document.getElementById("item-input")!.value;
    }
}