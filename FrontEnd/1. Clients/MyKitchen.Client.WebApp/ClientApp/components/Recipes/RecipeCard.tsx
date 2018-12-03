import TextareaAutosize from 'react-autosize-textarea';
import '../../css/RecipeCard.css';
import '../../Images/index.jpg';
import { Ingredient, Recipe } from '../MyKitchenInterfaces';
import * as React from 'react';
import { Link, NavLink } from 'react-router-dom';

interface RecipeCardProps
{
    recipe: Recipe
}

export class RecipeCard extends React.Component<RecipeCardProps, {}> {
    private defaultImage = require('../../Images/index.jpg');
    public render() {
        let recipe = this.props.recipe;
        var imageSource
        return <div className="real-recipe-card col-md-4 col-xs-12">
            <img src={this.GetImageSource(recipe.image)} />
            <div className="recipe-card-data">
            <div className="recipe-data-header">
            <h3 className="title">{recipe.name} </h3>
                { this.TotalTimeSpan(recipe.preparationTime, recipe.cookTime) }  | <span className="servings"><span className="glyphicon glyphicon-record"></span> {recipe.servings}</span>
            </div>
            <p className="description">{this.TruncateSummary(recipe.description)}</p>
            <p className="ingredients">{this.ListOfIngredients(recipe.ingredients)}</p>
            </div>
        </div>;
    }

    private GetImageSource(recipeImage: string | undefined)
    {
        if(recipeImage != undefined && recipeImage != null && recipeImage.trim() != "")
        {
            return recipeImage;
        }
        console.log("No image was found");
        return String(this.defaultImage);
    }

    private TotalTimeSpan(preparationTime: number | undefined, cookTime: number | undefined)
    {
        let totalTime = 0;
        if((preparationTime == undefined || preparationTime == null) && (cookTime == undefined || preparationTime == null))
        {
            return null;
        }
        if(preparationTime != undefined && preparationTime != null)
        {
            totalTime = totalTime + preparationTime!;
        }
        if(preparationTime != undefined && preparationTime != null)
        {
            totalTime = totalTime + preparationTime!;
        }
        var totalTimeLabel = totalTime.toString() + " min";
        return <span className="recipe-time"><span className="glyphicon glyphicon-time"></span><span>{totalTimeLabel}</span></span>
    }

    private TruncateSummary(summary: string | undefined)
    {
        if(summary == undefined)
        {
            return undefined;
        }
        if(summary.length >150)
        {
            return summary.substr(0,147) + "..."
        }
        return summary;
    }

    private ListOfIngredients(ingredients: Ingredient[] | undefined)
    {
        return ingredients!.map(i => i.food!.name).join(", ");
    }
}
