import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import * as e6p from 'es6-promise';
(e6p as any).polyfill();
import 'isomorphic-fetch';
import { Food } from '../MyKitchenInterfaces';
import { MainRecipeComponent } from "../Recipes/MainRecipeComponent";
import * as ReactDOM from 'react-dom';

interface FetchFoodDataState{
    allFood: Food[];
}

var currentInputList: JSX.Element;

// export async function GetAllFood(component: MainRecipeComponent)
// {
//     var food = await fetch('api/Food/GetAll')
//     .then(response => response.json() as Promise<Food[]>);  
//     component.setState({ allFood: food });
//     return food;
// }

