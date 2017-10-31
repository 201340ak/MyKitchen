import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import * as e6p from "es6-promise";
(e6p as any).polyfill();
import 'isomorphic-fetch';
import { GetAllFood, RenderFoodList } from '../FetchFood';
import { Recipe, RecipeFood, Food } from "../MyKitchenInterfaces";
import { GetEmptyRecipe, AddRecipe } from "./AddRecipe";
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
            : RenderRecipeCards(this.state.recipes);
        let foods = this.state.loading
        ? <p><em>Loading Foods...</em></p>
        : RenderFoodList(this.state.allFood);

        return <div>
            <div>{ foods }</div>
            <h1>All Recipes</h1>
            <br />
            <button className="btn glyphicon glyphicon-plus add-recipe" name="add-recipe" onClick= { e => this.addRecipeCard() } />
            <div id="addRecipeArea">
                { this.state.addRecipeForm }
            </div>
            <p>This component demonstrates fetching data from the server.</p>
            { recipes }
        </div>
    }

    private async InitState()
    {
        this.GetAllFoodAsync();
        this.GetAllRecipesAsync();
        this.setState({loading: false});
    }

    public async GetAllFoodAsync()
    {
        var food = await GetAllFood();
        this.setState({ allFood: food });
    }    

    public async GetAllRecipesAsync()
    {
        var allRecipes = await GetAllRecipes();
        this.setState({recipes: allRecipes});
    }

    public addRecipeCard() 
    {
        var recipeCard = <div className="add-recipe-card form-group">
                <input className="recipe-title form-control" placeholder="Title of Recipe" onChange={ e => this.UpdateRecipeTitle(e)}></input>
                <textarea className="recipe-description form-control" rows={2} placeholder="Description of Recipe" value={ this.state.description } onChange={ e => this.UpdateRecipeDescription(e)}></textarea>
                <div className="row">
                    {/* { FetchRecipes.recipeData(recipe) }
                    { FetchRecipes.recipeFoods(recipe.recipeFoods) } */}
                </div>
                <button className="btn" name="cancel-recipe-btn" onClick= { e => this.cancelAddRecipeCard() }>Cancel</button>
                <button className="btn" onClick= { e => AddRecipe(this.state.recipeToAdd) }>Save Recipe</button>
            </div>;

            this.setState({ addRecipeForm: recipeCard } );
    }
    
    public UpdateRecipeDescription(event: React.ChangeEvent<HTMLTextAreaElement>)
    {
        // alert(event.target.value);
        this.setState({ description: event.target.value });
        // alert(this.state.description);
        
 
        let recipeToAdd = this.state.recipeToAdd;
        recipeToAdd.description = event.target.value;
        this.setState({ recipeToAdd: recipeToAdd});
    }

    public UpdateRecipeTitle(event: React.ChangeEvent<HTMLInputElement>)
    {
        let titleValue = event.target.value
        let recipeToAdd = this.state.recipeToAdd;
        recipeToAdd.name = titleValue;
        this.setState({ recipeToAdd: recipeToAdd});
        event.target.value = titleValue;
    }

    public handleChange(event: React.ChangeEvent<HTMLInputElement>)
    {
        let recipeToAdd = this.state.recipeToAdd;
        recipeToAdd.name = event.target.value;
        this.setState({ recipeToAdd: recipeToAdd});
    }

    public cancelAddRecipeCard()
    {
        this.setState({recipeToAdd: GetEmptyRecipe()});
        this.setState({ addRecipeForm: <div></div> } );
    }
}