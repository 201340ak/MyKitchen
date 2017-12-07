import { FoodListComponent, FoodQuantity } from '../DynamicListComponent';
import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';
import { Recipe, Food, Ingredient } from "../MyKitchenInterfaces";
import { AnimatedForm } from "./AnimatedForm";

interface AddRecipeCardState{
    recipeToAdd: Recipe;
    addRecipeForm?: JSX.Element;
    showForm: boolean;
}

export class AddRecipeCardComponent extends React.Component<RouteComponentProps<{}>, AddRecipeCardState> {
    constructor() {
        super();
        this.state = { recipeToAdd: this.GetEmptyRecipe(), showForm: false };
    }

    public render() {
        let addCardShow = !this.state.showForm ?
            <button className="btn glyphicon glyphicon-plus add-recipe" name="add-recipe" onClick={e => this.ShowForm()} /> :
            this.GetAddRecipeCard([])
        return <AnimatedForm />;
    }

    private ShowForm()
    {
        this.setState({showForm: true});
    }

    private GetSelectedFoodsCallBack(selectedFoods: FoodQuantity[])
    {
        var ingredient: Ingredient[] = selectedFoods.map(foodQuantity => {
            return {
                foodId: foodQuantity.food.id,
                food: foodQuantity.food,
                quantity: foodQuantity.quantity
            } as Ingredient;
        });
        var recipeToAdd = this.state.recipeToAdd;
        recipeToAdd.ingredients = ingredient;
        this.setState({recipeToAdd: recipeToAdd});
    }

    public GetAddRecipeCard(selectedFood: FoodQuantity[])
    {
         var listComponent = <FoodListComponent getSelectedFoodsCallBack={this.GetSelectedFoodsCallBack.bind(this)} />;
        let card = <div><h3>Add your recipe:</h3> <div className="add-recipe-card form-group" id="add-recipe-card">
        
            <input className="recipe-title form-control" placeholder="Title of Recipe" onChange={ e => this.UpdateRecipeTitle(e)} />
            <textarea className="recipe-description form-control" rows={2} placeholder="Description of Recipe" onChange={ e => this.UpdateRecipeDescription(e)} />
            <div className="row">
                <div className="col-sm-4">
                    <input type="number" min="0" className="recipe-prep-time form-control add-recipe-input" placeholder="Preparation Time (minutes)" onChange={ e => this.UpdateRecipePrepTime(e)} />
                    <input type="number" min="0" className="recipe-cook-time form-control add-recipe-input" placeholder="Cook Time (minutes)" onChange={ e => this.UpdateRecipeCookTime(e)} />
                    <input type="number" min="0" className="recipe-serving form-control add-recipe-input" placeholder="Servings Yielded" onChange={ e => this.UpdateRecipeServings(e)} />
                </div>
                <div className="col-sm-8">
                     { listComponent }
                </div>
            </div>
            <div className="add-recipe-btn-container">
                <button id="cancel-recipe" className="btn" name="cancel-recipe-btn" onClick= { e => this.CloseAddRecipeCard() }>Cancel</button>
                <button id="save-recipe" className="btn" onClick= {e => this.SaveRecipe()}>Save Recipe</button>
            </div>
        </div>
        </div>;

        return card;
    }
    
    private UpdateRecipeTitle(event: React.ChangeEvent<HTMLInputElement>)
    {
        let titleValue = event.target.value
        let recipeToAdd = this.state.recipeToAdd;
        recipeToAdd.name = titleValue;
        this.setState({ recipeToAdd: recipeToAdd});
        event.target.value = titleValue;
    }
    
    private UpdateRecipeDescription(event: React.ChangeEvent<HTMLTextAreaElement>)
    {
        let descriptionValue = event.target.value
        let recipeToAdd = this.state.recipeToAdd;
        recipeToAdd.description = descriptionValue;
        this.setState({ recipeToAdd: recipeToAdd});
    }

    private UpdateRecipePrepTime(event: React.ChangeEvent<HTMLInputElement>)
    {
        let prepTimeValue = +event.target.value
        let recipeToAdd = this.state.recipeToAdd;
        recipeToAdd.preparationTime = prepTimeValue;
        this.setState({ recipeToAdd: recipeToAdd});
        event.target.value = prepTimeValue.toString();
    }
    
    private UpdateRecipeCookTime(event: React.ChangeEvent<HTMLInputElement>)
    {
        let cookTimeValue = +event.target.value
        let recipeToAdd = this.state.recipeToAdd;
        recipeToAdd.cookTime = cookTimeValue;
        this.setState({ recipeToAdd: recipeToAdd});
        event.target.value = cookTimeValue.toString();
    }

    private UpdateRecipeServings(event: React.ChangeEvent<HTMLInputElement>)
    {
        let servingsValue = +event.target.value
        let recipeToAdd = this.state.recipeToAdd;
        recipeToAdd.servings = servingsValue;
        this.setState({ recipeToAdd: recipeToAdd});
        event.target.value = servingsValue.toString();
    }

    private GetEmptyRecipe()
    {
        var recipe: Recipe = {}
        return recipe;
    }

    private CloseAddRecipeCard()
    {
        this.setState({showForm: false});
    } 
    
    private async SaveRecipe()
    {
        let recipe = this.state.recipeToAdd;
        
        var recipeJson = JSON.stringify(recipe);
        var myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");
        var recipeWasAdded = await fetch("api/Recipe/Add",
        {
            method: 'Post',
            headers: myHeaders,
            body: recipeJson
        }).then(response => response.json() as Promise<boolean>);

        this.CloseAddRecipeCard();
    }
}