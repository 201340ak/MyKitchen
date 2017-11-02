import { compile } from 'path-to-regexp';
import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';
import { Recipe, Food, RecipeFood } from "../MyKitchenInterfaces";
import { MainRecipeComponent } from "./MainRecipeComponent";
import { GetAllRecipes } from "./FetchRecipes";
import { RenderFoodList } from "../Food/FetchFood";


export function CloseAddRecipeCard(component: MainRecipeComponent)
{
    component.setState({recipeToAdd: GetEmptyRecipe()});
    component.setState({ addRecipeForm: <div></div> } );
}

export function GetEmptyRecipe()
{
    var recipe: Recipe = {}
    return recipe;
}

export async function SaveRecipe(recipe: Recipe, component: MainRecipeComponent)
{
    var recipeJson = JSON.stringify(recipe);
    var recipeWasAdded = await fetch("api/Recipe/Add",
    {
        method: 'Post',
        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json"
        },
        body: recipeJson
    }).then(response => response.json() as Promise<boolean>);

    await GetAllRecipes(component);
    CloseAddRecipeCard(component);
}


export function AddRecipeCard(component: MainRecipeComponent) 
{        
    let foods = component.state.loading
        ? <p><em>Loading Foods...</em></p>
        : RenderFoodList(component.state.allFood, component);

    var recipeCard = <div className="add-recipe-card form-group">
            <input className="recipe-title form-control" placeholder="Title of Recipe" onChange={ e => UpdateRecipeTitle(e, component)} />
            <textarea className="recipe-description form-control" rows={2} placeholder="Description of Recipe" onChange={ e => UpdateRecipeDescription(e, component)} />
            <div className="row">
                <div className="col-sm-6">
                    <input type="number" min="0" className="recipe-prep-time form-control" placeholder="Preparation Time (minutes)" onChange={ e => UpdateRecipePrepTime(e, component)} />
                    <input type="number" min="0" className="recipe-cook-time form-control" placeholder="Cook Time (minutes)" onChange={ e => UpdateRecipeCookTime(e, component)} />
                    <input type="number" min="0" className="recipe-serving form-control" placeholder="Servings Yielded" onChange={ e => UpdateRecipeServings(e, component)} />
                </div>
                <div className="col-sm-6">{ foods }</div>
            </div>
            <button id="cancel-recipe" className="btn" name="cancel-recipe-btn" onClick= { e => CloseAddRecipeCard(component) }>Cancel</button>
            <button id="save-recipe" className="btn" onClick= { e => SaveRecipe(component.state.recipeToAdd, component) }>Save Recipe</button>
        </div>;

    component.setState({ addRecipeForm: recipeCard } );
}

export function UpdateRecipeFoodList(event: React.ChangeEvent<HTMLInputElement>, component: MainRecipeComponent)
{
    let foodId = +event.target.value;
    let foodName = event.target.name;
    let selected = event.target.checked;

    let foodItem: Food = {
        id: foodId,
        name: foodName
    };

    if(selected === true)
    {
        AddToIngredients(foodItem, component);
    }
    else
    {
        RemoveFromIngredients(foodItem, component);
    }       
}

function AddToIngredients(food: Food, component: MainRecipeComponent)
{
    let foodList = component.state.recipeToAdd.ingredients;
    if(foodList == null)
    {
        foodList = []
    }

    let recipeFoodItem: RecipeFood = 
    {
        foodId: food.id,
        food: food,
        quantity: 1
    };

    foodList.push(recipeFoodItem);

    let recipeToAdd = component.state.recipeToAdd;
    recipeToAdd.ingredients = foodList;    
    component.setState({ recipeToAdd: recipeToAdd});    
}

function RemoveFromIngredients(food: Food, component: MainRecipeComponent)
{
    let foodList = component.state.recipeToAdd.ingredients;
    if(foodList == null)
    {
        foodList = []
    }

    let recipeFoodItem = foodList.filter(item => item.foodId == food.id)[0]

    foodList = foodList.filter(obj => obj !== recipeFoodItem);

    let recipeToAdd = component.state.recipeToAdd;
    recipeToAdd.ingredients = foodList;
    component.setState({ recipeToAdd: recipeToAdd});
}
    
function UpdateRecipeTitle(event: React.ChangeEvent<HTMLInputElement>, component: MainRecipeComponent)
{
    let titleValue = event.target.value
    let recipeToAdd = component.state.recipeToAdd;
    recipeToAdd.name = titleValue;
    component.setState({ recipeToAdd: recipeToAdd});
    event.target.value = titleValue;
}

function UpdateRecipeDescription(event: React.ChangeEvent<HTMLTextAreaElement>, component: MainRecipeComponent)
{
    component.setState({ description: event.target.value });
    let recipeToAdd = component.state.recipeToAdd;
    recipeToAdd.description = event.target.value;
    component.setState({ recipeToAdd: recipeToAdd});
}


function UpdateRecipePrepTime(event: React.ChangeEvent<HTMLInputElement>, component: MainRecipeComponent)
{
    let prepTimeValue = +event.target.value
    let recipeToAdd = component.state.recipeToAdd;
    recipeToAdd.preparationTime = prepTimeValue;
    component.setState({ recipeToAdd: recipeToAdd});
    event.target.value = prepTimeValue.toString();
}

function UpdateRecipeCookTime(event: React.ChangeEvent<HTMLInputElement>, component: MainRecipeComponent)
{
    let cookTimeValue = +event.target.value
    let recipeToAdd = component.state.recipeToAdd;
    recipeToAdd.cookTime = cookTimeValue;
    component.setState({ recipeToAdd: recipeToAdd});
    event.target.value = cookTimeValue.toString();
}
        
function UpdateRecipeServings(event: React.ChangeEvent<HTMLInputElement>, component: MainRecipeComponent)
{
    let servingsValue = +event.target.value
    let recipeToAdd = component.state.recipeToAdd;
    recipeToAdd.servings = servingsValue;
    component.setState({ recipeToAdd: recipeToAdd});
    event.target.value = servingsValue.toString();
}