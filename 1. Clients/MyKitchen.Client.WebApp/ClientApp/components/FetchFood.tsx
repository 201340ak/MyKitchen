import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import * as e6p from "es6-promise";
(e6p as any).polyfill();
import 'isomorphic-fetch';
import { Food } from './MyKitchenInterfaces';

interface FetchFoodDataState{
    allFood: Food[];
}

export function RenderFoodList(foods: Food[]) {
    alert(foods.length);
    return <ul>{ foods.map(food => GetFoodItem(food)) }</ul>;
}

export async function GetAllFood()
{
    var food = await fetch('api/Food/GetAll')
    .then(response => response.json() as Promise<Food[]>)
    return food;
}

function GetFoodItem(food: Food) 
{
    return <li>{ food.name } </li>;
}