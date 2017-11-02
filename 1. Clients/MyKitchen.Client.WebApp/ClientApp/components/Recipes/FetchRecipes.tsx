import { DeleteRecipe } from './RemoveRecipe';
import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import * as e6p from 'es6-promise';
(e6p as any).polyfill();
import 'isomorphic-fetch';
import { Recipe, RecipeFood } from "../MyKitchenInterfaces";
import { MainRecipeComponent } from "./MainRecipeComponent";

export function RenderRecipeCards(recipes: Recipe[], component: MainRecipeComponent) {
    return <div>{ recipes.map(recipe => GetRecipeCard(recipe, component)) }</div>;
}

export async function GetAllRecipes(component: MainRecipeComponent)
{    
    var recipes = await fetch('api/Recipe/GetAll')
    .then(response => response.json() as Promise<Recipe[]>);
    component.setState({recipes: recipes});
    return recipes;
}

function GetRecipeCard(recipe: Recipe, component: MainRecipeComponent) 
{
    var id = recipe.id == null ? 0 : recipe.id
    return <div className="recipe-card">
            <div className="row">
                <h3 className="recipe-title col-xs-10">{ recipe.name }</h3>
                <div className="col-xs-2">
                    <button className="btn glyphicon glyphicon-remove remove-recipe pull-right" onClick={ e => DeleteRecipe(component, recipe.id) } />
                </div>
            </div>
            <div className="row">
                <text className="recipe-description col-xs-12">{ recipe.description }</text>
            </div>
            <div className="row">
                { GetRecipeData(recipe) }
                { GetRecipeFoodList(recipe.ingredients!) }
            </div>
        </div>;
}


function GetRecipeData(recipe: Recipe)
{
        return <ul className="recipe-data col-sm-6">
        <li>
            <div className="row">
                <div className="col-sm-6 col-xs-12 recipe-data-key">
                    Preparation Time:
                </div>
                <div className="col-sm-6 col-xs-12 recipe-data-value">
                    { recipe.preparationTime } minutes
                </div>
            </div>
        </li>
        <li>
            <div className="row">
                <div className="col-sm-6 col-xs-12 recipe-data-key">
                    <i>Cook Time:</i>
                </div>
                <div className="col-sm-6 col-xs-12 recipe-data-value">
                    { recipe.cookTime } minutes
                </div>
            </div>
        </li>
        <li>
            <div className="row">
                <div className="col-sm-6 col-xs-12 recipe-data-key">
                    <i>Servings Yield:</i>
                </div>
                <div className="col-sm-6 col-xs-12 recipe-data-value">
                    { recipe.servings }
                </div>
            </div>
        </li>
    </ul>
}

function GetRecipeFoodList(recipeFoods: RecipeFood[])
{
    return <ul className="recipe-food col-sm-6">
        { recipeFoods.map(recipeFood => GetRecipeFoodListItem(recipeFood))}
    </ul>
}

function GetRecipeFoodListItem(recipeFood: RecipeFood) 
{
    return <li>
        <div className="row">
            <div className="col-sm-6 col-xs-12 recipe-food-name">
                { recipeFood.food!.name }
            </div>
            <div className="col-sm-6 col-xs-12 recipe-food-quantity">
                { recipeFood.quantity }
            </div>
        </div>
    </li>
}