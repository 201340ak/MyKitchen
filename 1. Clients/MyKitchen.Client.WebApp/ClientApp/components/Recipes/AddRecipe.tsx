import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';
import { Recipe } from "../MyKitchenInterfaces";

interface AddRecipeDataState{
    recipeToAdd: Recipe;
    addRecipeForm?: JSX.Element;
}

export function GetEmptyRecipe()
{
    var recipe: Recipe = {}
    return recipe;
}
    
export function AddRecipe(recipe: Recipe)
{
    alert("Saving!..")
    let recipeTitle = recipe.name;
    let recipeDescription = recipe.description;
    alert("Title: " + recipeTitle + "; Description: " + recipeDescription);
}

async function PostRecipe(recipe: Recipe)
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
    }).then(response => response.json() as Promise<boolean>)
    return recipeWasAdded;
}