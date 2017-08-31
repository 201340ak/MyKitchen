import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface FetchRecipeDataState{
    recipes: Recipe[];
    loading: boolean;
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
            <p>This component demonstrates fetching data from the server.</p>
            { contents }
        </div>
    }
    
    private static renderRecipeCards(recipes: Recipe[]) {
        return <div>{ recipes.map(recipe => FetchRecipes.recipeCard(recipe)) }</div>;
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
}

interface Recipe {
    id: number;
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
    id: number;
    name: string;
    unit: Unit;
    servingSize: number;
    calories: number;
    price: number;
    unitQuantityForPrice: number;
    // recipeFoods: RecipeFood[]
}

interface Unit {
    id: number;
    name: string;
}
