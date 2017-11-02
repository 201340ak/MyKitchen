import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import * as e6p from "es6-promise";
(e6p as any).polyfill();
import 'isomorphic-fetch';
import { Food } from '../MyKitchenInterfaces';
import { MainRecipeComponent } from "../Recipes/MainRecipeComponent";
import { UpdateRecipeFoodList } from "../Recipes/AddRecipe";

interface FetchFoodDataState{
    allFood: Food[];
}

export async function GetAllFood(component: MainRecipeComponent)
{
    var food = await fetch('api/Food/GetAll')
    .then(response => response.json() as Promise<Food[]>);  
    component.setState({ allFood: food });
    return food;
}

export function RenderFoodList(foods: Food[], component: MainRecipeComponent) {
    return <ul>{ foods.map(food => GetFoodItem(food, component)) }</ul>;
}
    
function GetFoodItem(food: Food, component: MainRecipeComponent)
{
    return <li>
        <input type="checkbox" name={ food.name } value={ food.id } onChange={ e => UpdateRecipeFoodList(e, component) } /> { food.name }
    </li>;
}


