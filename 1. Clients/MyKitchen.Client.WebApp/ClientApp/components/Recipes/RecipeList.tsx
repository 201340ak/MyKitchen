import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';
import { Recipe, Food, RecipeFood } from "../MyKitchenInterfaces";
import * as $ from 'jquery';

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
        return <div>{ recipes.map(recipe => this.GetRecipeCard(recipe)) }</div>;
    }

    private async GetAllRecipes()
    {
        var recipes = await fetch('api/Recipe/GetAll')
        .then(response => response.json() as Promise<Recipe[]>);

        this.setState({allRecipes: recipes});
        return recipes;
    }

    public GetRecipeCard(recipe: Recipe)
    {
        var id = recipe.id == null ? 0 : recipe.id
        return <div className="recipe-card">
                <div className="row">
                    <h3 className="recipe-title col-xs-10">{ recipe.name }</h3>
                    <div className="col-xs-2">
                        <button className="btn glyphicon glyphicon-remove remove-recipe pull-right" onClick={ e => this.DeleteRecipe(recipe.id) } />
                    </div>
                </div>
                <div className="row">
                    <text className="recipe-description col-xs-12">{ recipe.description }</text>
                </div>
                <div className="row">
                    { this.GetRecipeData(recipe) }
                    { this.GetRecipeFoodList(recipe.ingredients!) }
                </div>
            </div>
    }

    private GetRecipeData(recipe: Recipe)
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

    private GetRecipeFoodList(recipeFoods: RecipeFood[])
    {
        return <ul className="recipe-food col-sm-6">
            { recipeFoods.map(recipeFood => this.GetRecipeFoodListItem(recipeFood))}
        </ul>
    }

    private GetRecipeFoodListItem(recipeFood: RecipeFood) 
    {
        return <li>
            <div className="row">
                <div className="col-sm-6 col-xs-12 recipe-food-name">
                    { recipeFood.food!.name }
                </div>
                <div className="col-sm-6 col-xs-12 recipe-food-quantity">
                    { recipeFood.quantity } { recipeFood.food!.unit!.name }
                </div>
            </div>
        </li>
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