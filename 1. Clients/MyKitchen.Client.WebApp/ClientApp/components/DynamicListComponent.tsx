// import { GetAllFood } from './Food/FetchFood';
import { Food } from './MyKitchenInterfaces';
import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import * as e6p from 'es6-promise';
(e6p as any).polyfill();
import 'isomorphic-fetch';

export interface DynamicListState{
    items: string[];
    selectedFood: Food[];
    selectedFoodQuantity: FoodQuantity[]
    allFoods: Food[];
}

export interface FoodQuantity {
    food: Food,
    quantity: number
}

export interface DynamicListComponentProps
{
    getSelectedFoodsCallBack(foodQuantities: FoodQuantity[]): any;
    selectedFoodQuantity: FoodQuantity[];
}

export class FoodListComponent extends React.Component<DynamicListComponentProps, DynamicListState> {
    constructor() {
        super();
        this.state = { items: [], allFoods: [], selectedFood: [], selectedFoodQuantity: []};
        this.GetAllFood();
    }

    public render() {
        let list = <ul id="selected-food-list"> { this.RenderListOfSelectedFood() }</ul>
        let dataList = <div> { this.GetFoodDataList() }</div>;
        return <div>
                { dataList }
                { list }
                { this.GetInput() }
            </div>
    }

    public GetInput()
    {        
        var unit = <input className="form-control" id="food-input" list="food-data-list" placeholder="Add item to the list" />
        var quantityInput = <div className="col-xs-8 quantity-input-container row"><input type="number" min="0" className="form-control col-xs-6" id="quantity-input" placeholder="0.0" />{unit}</div>;
        
        var quantityUnit = <div></div>

        var foodInput = <input className="form-control" id="food-input" list="food-data-list" placeholder="Add item to the list" />
        var button = <span className="input-group-btn"> <button className="btn btn-default glyphicon-plus" onClick={ e => this.AddToList() }/> </span>;
        var foodInputGroup = <div className="input-group col-xs-4">{ foodInput } { button }</div>;

        return <div> { quantityInput } {foodInputGroup} </div>;
    }

    private AddToList()
    {
        this.AddSelectedFoodToList();
        this.ClearInput();
    }

    private AddSelectedFoodToList()
    {
        var inputValue = (document.getElementById("food-input") as HTMLInputElement).value;
        let selectedFood = this.GetFoodBySelectedOptionValue(inputValue);
        var quantity = this.GetQuantity();
        var foodQuantity: FoodQuantity = {
            food: selectedFood,
            quantity: quantity
        };
        var foodAndQuantities = this.state.selectedFoodQuantity;
        foodAndQuantities.push(foodQuantity);
        this.setState({ selectedFoodQuantity: foodAndQuantities });
        this.props.getSelectedFoodsCallBack(this.state.selectedFoodQuantity);
    }

    private GetFoodBySelectedOptionValue(value: string)
    {
        var query = "#food-data-list option[value='" + value + "']";
        var selectedOption = document.querySelector(query) as HTMLOptionElement;
        return this.GetFoodById(+selectedOption.id);
    }

    private GetQuantity()
    {
        return +(document.getElementById("quantity-input") as HTMLInputElement).value;
    }

    private RenderListOfSelectedFood()
    {
        return this.state.selectedFoodQuantity.map(food => this.GetListItem(food));
    }
    
    private GetListItem(foodQuantity: FoodQuantity)
    {
        var className = "btn btn-xs glyphicon glyphicon-remove";
        var removeButton = <button className={"btn btn-xs glyphicon glyphicon-remove"} onClick={ e => this.RemoveFoodFromList(foodQuantity) }/>;
        var id = foodQuantity.food.id!.toString() + "-" + foodQuantity.food.name + "-" + foodQuantity.quantity;
        return <li id={id}> {foodQuantity.quantity} { foodQuantity.food.name } { removeButton } </li>;
    }
    
    private RemoveFoodFromList(foodQuantity: FoodQuantity)
    {
        let foodQuantities = this.state.selectedFoodQuantity.filter(obj => obj !== foodQuantity);
        this.setState({ selectedFoodQuantity: foodQuantities});
        this.props.getSelectedFoodsCallBack(foodQuantities);
    }

    private ClearInput()
    {
        (document.getElementById("food-input") as HTMLInputElement).value = "";
        (document.getElementById("quantity-input") as HTMLInputElement).value = "";
    }

    private GetFoodDataList()
    {
        let foods = this.state.allFoods;
        return <datalist id="food-data-list"> 
           { this.GetFoodOptions() }
        </datalist>;
    }

    private GetFoodOptions()
    {
        let foods = this.state.allFoods;
        return foods.map(food => <option value={food.name} id={ food.id!.toString() }/>)
    }
    
    private async GetAllFood()
    {
        await fetch('api/Food/GetAll')
            .then(response => response.json() as Promise<Food[]>)
            .then(data => this.setState({allFoods: data}));
    }

    private GetFoodById(id: number)
    {
        var foodById = this.state.allFoods.filter(food => food.id == id)[0];
        return foodById;
    }
}