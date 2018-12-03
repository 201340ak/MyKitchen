import { ImageUploaderComponent } from './ImageUploader';
import { Ingredient, Recipe } from '../MyKitchenInterfaces';
import '../../css/animatedform.css';
import { AddRecipeCardComponent } from './AddRecipeCard';
import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { RecipeListComponent } from './RecipeList';
import * as $ from 'jquery';
import TextareaAutosize from 'react-autosize-textarea';
import { FoodListComponent, FoodQuantity } from '../DynamicListComponent';


interface AddRecipeCardState{
    recipeToAdd: Recipe;
}

export class AnimatedForm extends React.Component<{}, AddRecipeCardState> {
    constructor() {
        super();

        this.state = {recipeToAdd:{}};
    }

    public render() {
        var recipeTitleForm = this.TitleInput();
        var descriptionForm = this.DescriptionTextArea();
        var prepTime = this.PreparationTime();
        var cookTime = this.CookTime();
        var servings = this.Servings();
        var recipeData = <div className="row">{ prepTime } { cookTime } { servings }</div>;
        
        var buttons = <div className="add-recipe-btn-container col-xs-12">
        {/* <button id="cancel-recipe" className="btn" name="cancel-recipe-btn" onClick= { e => this.CloseAddRecipeCard() }>Cancel</button> */}
        <button id="save-recipe" className="btn" onClick= {e => this.SaveRecipe()}>Save Recipe</button>
        </div>
        return <div> 
            { this.TitleInput() } 
            { this.DescriptionTextArea() } 
            {recipeData} 
            <br /> 
            {this.FoodInput() } 
            <ImageUploaderComponent getImage={this.GetImageCallBack.bind(this)} /> 
            {buttons} 
         </div>
    }

    private TitleInput()
    {
        return <label>
          <input type="text" className="form-input" required onChange={e => this.UpdateRecipeTitle(e)} />
          <div className="label-text">Name your recipe</div>
        </label>
    }

    private DescriptionTextArea()
    {
        return <div className="textarea-form">
            <label>Summary</label>
            <TextareaAutosize onChange={e => this.UpdateRecipeDescription(e)}/>
          </div>
    }

    private PreparationTime()
    {
        return <div className="recipe-data col-xs-4">
            <p>Preparatin Time (in minutes)</p>
            <input type="number" min="0" className="form-control add-recipe-input" placeholder="--" onChange={e => this.UpdateRecipePrepTime(e)} />
            </div>
    }
    
        private CookTime()
        {
            return <div className="recipe-data col-xs-4">
                <p>Cook Time (in minutes)</p>
                <input type="number" min="0" className="form-control add-recipe-input" placeholder="--" onChange={e => this.UpdateRecipeCookTime(e)} />
                </div>
        }
        
            private Servings()
            {
                return <div className="recipe-data col-xs-4">
                    <p>Servings</p>
                    <input type="number" min="0" className="form-control add-recipe-input" placeholder="--" onChange={e => this.UpdateRecipeServings(e)} />
                    </div>
            }
    

    private GetSelectedFoodsCallBack(selectedFoods: FoodQuantity[])
    {
        var ingredient: Ingredient[] = selectedFoods.map(foodQuantity => {
            return {
                foodId: foodQuantity.food.id,
                food: foodQuantity.food,
                quantity: foodQuantity.quantity,
                unit: foodQuantity.unit
            } as Ingredient;
        });
        var recipeToAdd = this.state.recipeToAdd;
        recipeToAdd.ingredients = ingredient;
        this.setState({recipeToAdd: recipeToAdd});
    }

    private GetImageCallBack(file: File)
    {
        var recipeToAdd = this.state.recipeToAdd;
        var reader = new FileReader();
        var reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = function (evt) {
            var fileText = reader.result;
            recipeToAdd.image = fileText;
        }
        this.setState({recipeToAdd: recipeToAdd});
    }

    private FoodInput()
    {
        return <div className="food-input">
        <p>Ingredients</p>
        <FoodListComponent getSelectedFoodsCallBack={this.GetSelectedFoodsCallBack.bind(this)} />
        </div>
    }    

    private CloseAddRecipeCard()
    {
        this.setState({recipeToAdd: {}});
    }    
    
    private async SaveRecipe()
    {
        console.log()
        let recipe = this.state.recipeToAdd;
        var recipeJson = JSON.stringify(recipe);
        
        console.log(recipe.image!.substr(0, 20));
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
    
    private UpdateRecipeTitle(event: React.ChangeEvent<HTMLInputElement>)
    {
        let titleValue = event.target.value;
        let recipeToAdd = this.state.recipeToAdd;
        recipeToAdd.name = titleValue;
        this.setState({ recipeToAdd: recipeToAdd});
        event.target.value = titleValue;
    }    
    
    private UpdateRecipeDescription(event: React.FormEvent<HTMLTextAreaElement>)
    {
        let changeEvent = event as React.ChangeEvent<HTMLTextAreaElement>;
        let descriptionValue = changeEvent.target.value
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
}