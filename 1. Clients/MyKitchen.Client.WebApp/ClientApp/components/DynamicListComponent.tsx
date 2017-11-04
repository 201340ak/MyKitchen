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
        let list = <ul> { this.RenderListItems() }</ul>

        return <div>
                { list }
                { this.GetInput() }
            </div>
    }

    public GetInput()
    {
        var button = <button className="btn glyphicon glyphicon-plus" onClick={ e => this.AddToList() }/> 
        var input = <input className="col-xs-4" id="item-input" placeholder="Add item to the list" />
        return <div className="row">{ input } { button } </div>;
    }

    private AddToList()
    {
        // add value of input to items list
        this.AddInputValueToList();
        // render list
        // clear input
        this.ClearInput();
    }

    private AddInputValueToList()
    {
        var inputValue = (document.getElementById("item-input") as HTMLInputElement).value;
        var listItems = this.state.items;
        listItems.push(inputValue);
        this.setState({ items: listItems });
    }

    private RenderListItems()
    {
        return this.state.items.map(this.GetListItem);
    }
    
    private GetListItem(item: string)
    {
        var className = "btn btn-xs glyphicon glyphicon-remove";
        var removeButton = <button className={className} />;
        var domElement = document.getElementsByClassName(className)[0];
        domElement.addEventListener("click", e => this.RemoveItemFromList(item));

        // var htmlButtonElement = (removeButton.props as HTMLButtonElement);
        // htmlButtonElement.addEventListener("click", e => this.RemoveItemFromList(item));
        var listItem = <li> { item } { domElement } </li>
        return <li> { item } { domElement } </li>;
    }
    
    private RemoveItemFromList(item: string)
    { 
        // let items = this.state.items.filter(obj => obj !== item);
        alert(item);
        // this.setState({items: items});
    }

    private ClearInput()
    {
        (document.getElementById("item-input") as HTMLInputElement).value = "";
    }
}