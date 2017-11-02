import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import * as e6p from 'es6-promise';
(e6p as any).polyfill();
import 'isomorphic-fetch';
import { Food } from '../MyKitchenInterfaces';
import { MainRecipeComponent } from "../Recipes/MainRecipeComponent";
import { AddRecipeCard, UpdateRecipeFoodList } from '../Recipes/AddRecipe';
import * as ReactDOM from 'react-dom';

interface FetchFoodDataState{
    allFood: Food[];
}

var currentInputList: JSX.Element;

export async function GetAllFood(component: MainRecipeComponent)
{
    var food = await fetch('api/Food/GetAll')
    .then(response => response.json() as Promise<Food[]>);  
    component.setState({ allFood: food });
    return food;
}

export function RenderAddFoodToRecipeComponent (foods: Food[], component: MainRecipeComponent)
{
    var header = <h4>Ingredients:</h4>
    var addButton = GetAddButton(1, foods, component);

    return <div id="add-food-to-recipe">{ header } { addButton } <div id="food-inputs">{ currentInputList }</div>
    { GetFoodDataList(foods, component) }</div>;
}

function GetAddButton(id: number, foods: Food[], component: MainRecipeComponent)
{
    var foodItemId = "food-item-" + id;
    return <button className="btn glyphicon glyphicon-plus" id={ foodItemId } onClick={ e => ReplaceButtonWithFoodInput(id, foods, component) }/> 
}

function ReplaceButtonWithFoodInput(id: number, foods: Food[], component: MainRecipeComponent)
{
    var element = document.getElementById("food-item-" + id);
    element!.outerHTML = "";
    var componentElement = <div> { GetFoodInput(foods, component) } { GetAddButton(id++, foods, component) }</div>;
    ReactDOM.render(componentElement, document.getElementById("food-inputs"));
    // element!.outerHTML = GetFoodInput(foods, component).props.toString();
    // var domElement = ReactDOM.findDOMNode(element!);
    // domElement = GetFoodDataList(foods, component).props;
}

function GetFoodInput(foods: Food[], component: MainRecipeComponent) {
    var foodInput = <div>
    <input list="food-data-list" placeholder="Ingredient"/> 
    </div>;
    return foodInput;
}
    
function GetFoodDataList(foods: Food[], component: MainRecipeComponent)
{

    return <datalist id="food-data-list"> 
        { foods.map(food => <option value={ food.name } id={ food.id!.toString() }/>) } 
        </datalist> ;
    // <li>
    //     <input type="checkbox" name={ food.name } value={ food.id } onChange={ e => UpdateRecipeFoodList(e, component) } /> { food.name }
    // </li>;
}


