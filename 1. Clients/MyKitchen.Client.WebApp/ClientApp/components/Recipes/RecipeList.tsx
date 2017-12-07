import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';
import { Recipe, Food, Ingredient } from "../MyKitchenInterfaces";
import * as $ from 'jquery';
import { RecipeCard } from './recipeCard';
import Masonry from 'react-masonry-component';

interface RecipeListState
{
    gettingRecipes: boolean,
    allRecipes: Recipe[]
}

export class RecipeListComponent extends React.Component<RouteComponentProps<{}>, RecipeListState> {
    constructor() {
        super();

        this.state = { gettingRecipes: true, allRecipes:[] }

        this.InitState();
    }

    public render() {
        this.AddEventHandlerToGetAllRecipesAfterSave();
        let recipeCards = this.state.gettingRecipes
        ? <p><em>Loading Recipes..</em></p>
        : this.RenderRecipeCards();
        return <div>{ recipeCards }</div>;
    }

    private async InitState()
    {
        await this.GetAllRecipes();
        this.setState({gettingRecipes: false});
    }

    private RenderRecipeCards() {
        let recipes = this.state.allRecipes;
        var masonry = <Masonry className={'grid'}>{ recipes.map(recipe => <RecipeCard recipe={recipe} />) }</Masonry>
        return masonry;
    }

    private async GetAllRecipes()
    {
        var recipes = await fetch('api/Recipe/GetAll')
        .then(response => response.json() as Promise<Recipe[]>);
        this.setState({allRecipes: recipes});
        return recipes;
    }

    private async DeleteRecipe(recipeId: number | undefined)
    {
        var recipeIdJSON = JSON.stringify(recipeId);

        var myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");
        myHeaders.append("Accept", "application/json");

        var recipeWasDeleted = await fetch("api/Recipe/Delete",
        {
            method: 'Delete',
            headers: myHeaders,
            body: recipeIdJSON
        })
        .then(response => {
            response.json() as Promise<boolean>
        });

        this.GetAllRecipes();
        return recipeWasDeleted;
    }

    private async AddEventHandlerToGetAllRecipesAfterSave()
    {
        $(document).on('click', '#save-recipe', e => this.GetAllRecipes());
    }
}