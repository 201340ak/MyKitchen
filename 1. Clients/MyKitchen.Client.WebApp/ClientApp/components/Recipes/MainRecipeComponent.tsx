import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import * as e6p from "es6-promise";
(e6p as any).polyfill();
import 'isomorphic-fetch';
import { GetAllFood } from '../Food/FetchFood';
import { Recipe, Food } from "../MyKitchenInterfaces";
import { GetEmptyRecipe, AddRecipeCard } from "./AddRecipe";
import { RenderRecipeCards, GetAllRecipes } from "./FetchRecipes";

interface FetchRecipeDataState{
    recipes: Recipe[];
    loading: boolean;
    recipeToAdd: Recipe;
    description?: string;
    addRecipeForm?: JSX.Element;
    allFood: Food[];
}

export class MainRecipeComponent extends React.Component<RouteComponentProps<{}>, FetchRecipeDataState> {
    constructor() {
        super();
        this.state = { recipes: [], loading: true, recipeToAdd: GetEmptyRecipe(), allFood: [] };

        this.InitState();
    }

    public render() {
        let recipes = this.state.loading
            ? <p><em>Loading...</em></p>
            : RenderRecipeCards(this.state.recipes, this);

        return <div>
            <h1>All Recipes</h1>
            <br />
            <button className="btn glyphicon glyphicon-plus add-recipe" name="add-recipe" onClick= { e => AddRecipeCard(this) } />
            <div id="addRecipeArea">
                { this.state.addRecipeForm }
            </div>
            { recipes }
        </div>
    }

    private async InitState()
    {
        await GetAllFood(this);
        GetAllRecipes(this);
        this.setState({loading: false});
    }
}