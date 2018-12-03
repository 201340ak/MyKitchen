// import { GetAllFood } from './Food/FetchFood';
import { Food, Unit } from './MyKitchenInterfaces';
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
    acceptableUnits: Unit[];
}

export interface FoodQuantity {
    food: Food,
    quantity: number,
    unit: Unit
}

export interface DynamicListComponentProps
{
   getSelectedFoodsCallBack(foodQuantities: FoodQuantity[]): any;
}

export class FoodListComponent extends React.Component<DynamicListComponentProps, DynamicListState> {
    constructor() {
        super();
        this.state = { items: [], allFoods: [], selectedFood: [], selectedFoodQuantity: [], acceptableUnits: []};
        this.GetAllFood();
        // this.UpdateUnitDataList([]);
    }

    public render() {
        let list = <ul id="selected-food-list"> { this.RenderListOfSelectedFood() }</ul>
        let fooddataList = <div> { this.GetFoodDataList() }</div>;
        let unitDataList = <div> {this.GetUnitDataList()} </div>
        return <div>
                { fooddataList } { unitDataList }
                { list }
                { this.GetInput() }
            </div>
    }

    public GetInput()
    {  
        var unit = <div className="col-xs-4"><input className="form-control add-recipe-input" id="unit-input" list="units-data-list" placeholder="Select a unit" /></div>
        var quantityInput = <div className="col-xs-4"><input type="number" min="0" className="form-control add-recipe-input" id="quantity-input" placeholder="0.0" /></div>;
        var foodInput = <div className="col-xs-4"><input onChange={e => this.UpdateUnitOptionsWhenFoodIsSelected()} className="form-control add-recipe-input" id="food-input" list="food-data-list" placeholder="Select an ingredient" /></div>    
        var button = <div className="row"><div className="col-xs-12 text-center"><button className="btn btn-default btn-lg glyphicon glyphicon-plus add-ingredient" onClick={ e => this.AddToList() }/></div></div>;
        var inputRow = <div className="row">{ foodInput }{ quantityInput }{unit}</div>;
        return <div>{inputRow}{button}</div>;
    }

    private UpdateUnitOptionsWhenFoodIsSelected()
    {
        console.log("changing..");
        var acceptableUnits = this.GetAcceptableUnitsForSelectedFood();
        if(acceptableUnits == null || acceptableUnits.length < 1)
        {
            return;
        }
        this.UpdateUnitDataList(acceptableUnits);
    }

    private GetAcceptableUnitsForSelectedFood()
    {
        var inputValue = (document.getElementById("food-input") as HTMLInputElement).value;
        var query = "#food-data-list option[value='" + inputValue + "']";
        var selectedOption = document.querySelector(query) as HTMLOptionElement;
        if(selectedOption != null)
        {
            console.log(selectedOption.value);
            let food = this.state.allFoods.filter(food => food.id == +selectedOption.id)[0];
            console.log(food.units!.length);
            return food.units
        }

        return null;
    }

    private AddToList()
    {
        this.AddSelectedFoodToList();
        this.ClearInput();
    }

    private AddSelectedFoodToList()
    {
        var foodQuantity = this.GetSelectedFoodInputs();
        var foodAndQuantities = this.state.selectedFoodQuantity;
        foodAndQuantities.push(foodQuantity);
        console.log(foodAndQuantities.length);
        this.setState({ selectedFoodQuantity: foodAndQuantities });
        this.props.getSelectedFoodsCallBack(this.state.selectedFoodQuantity);
    }

    private GetFoodBySelectedOptionValue(value: string)
    {
        var query = "#food-data-list option[value='" + value + "']";
        var selectedOption = document.querySelector(query) as HTMLOptionElement;
        return this.state.allFoods.filter(food => food.id == +selectedOption.id)[0];
    }
    
        private GetUnitBySelectedOptionValue(value: string)
        {
            var query = "#units-data-list option[value='" + value + "']";
            var selectedOption = document.querySelector(query) as HTMLOptionElement;
            console.log(value);
            let unit: Unit = {
                id: +selectedOption.id,
                name: selectedOption.value
            }
            return unit;
            // return this.state.allFoods.filter(food => food.id == +selectedOption.id)[0];
        }

    private GetSelectedFoodInputs()
    {
        var inputValue = (document.getElementById("food-input") as HTMLInputElement).value;
        let selectedFood = this.GetFoodBySelectedOptionValue(inputValue);
        let quantity = +(document.getElementById("quantity-input") as HTMLInputElement).value;
        let unitValue = (document.getElementById("unit-input") as HTMLInputElement).value;
        let selectedUnit = this.GetUnitBySelectedOptionValue(unitValue);
        var foodQuantity: FoodQuantity = {
            food: selectedFood,
            quantity: quantity,
            unit: selectedUnit
        };
        console.log(selectedUnit.name);
        return foodQuantity;
    }

    private RenderListOfSelectedFood()
    {
        return this.state.selectedFoodQuantity.map(food => this.GetListItem(food));
    }
    
    private GetListItem(foodQuantity: FoodQuantity)
    {
        var className = "btn btn-xs glyphicon glyphicon-remove";
        var removeButton = <button className={"btn btn-xs glyphicon glyphicon-remove remove-food"} onClick={ e => this.RemoveFoodFromList(foodQuantity) }/>;
        var id = foodQuantity.food.id!.toString() + "-" + foodQuantity.food.name + "-" + foodQuantity.quantity;
        return <li className="selected-food-list" id={id}> { removeButton }  {foodQuantity.quantity} {foodQuantity.unit.name} of { foodQuantity.food.name }</li>;
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
        (document.getElementById("unit-input") as HTMLInputElement).value = "";
    }

    private GetFoodDataList()
    {
        let foods = this.state.allFoods;
        return <datalist id="food-data-list"> 
           { foods.map(food => <option value={food.name} id={ food.id!.toString() }/>) }
        </datalist>;
    }
    
        private GetUnitDataList()
        {
            let units = this.state.acceptableUnits;
            return <datalist id="units-data-list"> 
               { units.map(units => <option value={units.name} id={ units.id!.toString() }/>) }
            </datalist>;
        }

    private UpdateUnitDataList(units: Unit[])
    {
        console.log("Number of units:" + units.length)
        var unitDataList = (document.getElementById("units-data-list") as HTMLInputElement);
        var innerHtmlOptions = units.map(unit => '<option value="' + unit.name + '" id="' + unit.id + '" />').join("");
        unitDataList.innerHTML = innerHtmlOptions;
    }
    
    private async GetAllFood()
    {
        await fetch('api/Food/GetAll')
            .then(response => response.json() as Promise<Food[]>)
            .then(data => { 
                console.log(data[0].units!.length);
                this.setState({allFoods: data});
            });
    }
}