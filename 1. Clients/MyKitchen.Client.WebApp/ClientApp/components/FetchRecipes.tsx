import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import * as e6p from "es6-promise";
(e6p as any).polyfill();
import 'isomorphic-fetch';

interface FetchRecipeDataState{
    recipes: Recipe[];
    loading: boolean;
    recipeToAdd?: Recipe;
}

export class FetchRecipes extends React.Component<RouteComponentProps<{}>, FetchRecipeDataState> {
    constructor() {
        super();
        this.state = { recipes: [], loading: true };

        fetch('api/Recipe/GetAll')
            .then(response => response.json() as Promise<Recipe[]>)
            .then(data => {
                this.setState({ recipes: data, loading: false });
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchRecipes.renderRecipeCards(this.state.recipes);
            
        return <div>
            <h1>All Recipes</h1>
            <br />
            <button className="btn glyphicon glyphicon-plus add-recipe" name="add-recipe" onClick= { e => this.addRecipe() } />
            <div className="addRecipeArea"></div>
            <p>This component demonstrates fetching data from the server.</p>
            { contents }
        </div>
    }

    private async addRecipe()
    {
        // var recipeWasAdded = await this.postMethod();
        // alert("Adding Recipe.." + recipeWasAdded);
        // var isOne = await this.postMethod();
        var isOne = await this.TryPost();
        if(isOne === true)
        {
            alert("Worked!");
        }
        else
        {
            alert(":(");
        }
    }

    private TryPost()
    {
        try
        {
            var numberBody = JSON.stringify({number: 1});
            alert(numberBody);
            var myHeaders = new Headers();
            
            myHeaders.append('Content-Type', 'application/json');
            myHeaders.append('Accept', 'application/json');
            // myHeaders.append('content-type', 'application/x-www-form-urlencoded; charset=utf-8');
            // myHeaders.append('accept', 'application/json, application/xml, text/plain, text/html, *.*');
        var response = fetch(
            'api/Recipe/CheckIfNumberIsOne',
            {
                method: 'POST',
                headers: myHeaders,
                body: numberBody,
            })
            .then(response => response.json() as Promise<boolean>)
            return response;
        }
        catch(e)
        {
            alert(e);
        }
    }

    private async postMethod()
    {
        try
        {
            var numberBody = JSON.stringify(1);
            this.setState({recipeToAdd: this.GetTestRecipe()});
            var recipeToAddstringified = JSON.stringify(this.GetTestRecipe());
            alert(recipeToAddstringified);
            var myHeaders = new Headers();
            
            myHeaders.append('Content-Type', 'application/json');
            var response = await fetch(
                'api/Recipe/Add',
                {
                    method: 'POST',
                    headers: {
                        'content-type': 'application/x-www-form-urlencoded; charset=utf-8',
                        'Accept': 'application/json, application/xml, text/plain, text/html, *.*'
                      },
                    body: numberBody, // this.state.recipeToAdd,
                })
                .then(response => response.json() as Promise<boolean>)
                .then(data => {
                    return data;
                });
                return response;
        }
        catch(error)
        {
            alert(error);
        }
    }
    
    private static renderRecipeCards(recipes: Recipe[]) {
        return <div>{ recipes.map(recipe => FetchRecipes.recipeCard(recipe)) }</div>;
    }

    private static addRecipeCard() 
    {
        return <div className="recipe-card">
                <input></input>
                <div className="row">
                    <input className="recipe-description col-xs-12"></input>
                </div>
                <div className="row">
                    {/* { FetchRecipes.recipeData(recipe) }
                    { FetchRecipes.recipeFoods(recipe.recipeFoods) } */}
                </div>
            </div>;
    }

    private static recipeCard(recipe: Recipe) 
    {
        return <div className="recipe-card">
                <h3>{ recipe.name }</h3>
                <div className="row">
                    <text className="recipe-description col-xs-12">{ recipe.description }</text>
                </div>
                <div className="row">
                    { FetchRecipes.recipeData(recipe) }
                    { FetchRecipes.recipeFoods(recipe.recipeFoods) }
                </div>
            </div>;
    }

    private static recipeData(recipe: Recipe)
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

    private static recipeFoods(recipeFoods: RecipeFood[])
    {
        return <ul className="recipe-food col-sm-6">
            { recipeFoods.map(recipeFood => FetchRecipes.recipeFoodListItem(recipeFood))}
        </ul>
    }

    private static recipeFoodListItem(recipeFood: RecipeFood) {
        return <li>
            <div className="row">
                <div className="col-sm-6 col-xs-12 recipe-food-name">
                    { recipeFood.food.name }
                </div>
                <div className="col-sm-6 col-xs-12 recipe-food-quantity">
                    { recipeFood.quantity }
                </div>
            </div>
        </li>
    }
    
    private GetTestRecipe()
    {        
        var unit: Unit = {
            // id: 0,
            name: "Apple",
        };
        var apple: Food = {
            // id: 0,
            name: "Apple",
            unit: unit,
            servingSize: 1,
            calories: 10,
            price: 1.00,
            unitQuantityForPrice: 1.00
        };
        var foods: RecipeFood[] = [{
            recipeId: 0,
            foodId: 0,
            food: apple,
            quantity: 2
        }]
        var recipe: Recipe = {
            // id: 0,
            name: "First Recipe",
            description: "Very first recipe",
            preparationTime: 5,
            cookTime: 20,
            servings: 2,
            deleted: false,
            recipeFoods: foods
        }
        return recipe;
    }
}

interface Recipe {
    // id: number;
    name: string;
    description: string;
    preparationTime: number;
    cookTime: number;
    servings: number;
    deleted: boolean;
    recipeFoods: RecipeFood[]
}

interface RecipeFood {
    recipeId: number;
    foodId: number;
    food: Food;
    quantity: number;
}

interface Food {
    // id: number;
    name: string;
    unit: Unit;
    servingSize: number;
    calories: number;
    price: number;
    unitQuantityForPrice: number;
    // recipeFoods: RecipeFood[]
}

interface Unit {
    // id: number;
    name: string;
}
