import { MainRecipeComponent } from './MainRecipeComponent';

export async function DeleteRecipe(component: MainRecipeComponent, recipeId: number | undefined)
{
    alert(recipeId);
    var recipeIdJSON = JSON.stringify(recipeId);
    var recipeWasDeleted = await fetch("api/Recipe/Delete",
    {
        method: 'Delete',
        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json"
        },
        body: recipeIdJSON
    }).then(response => {
        response.json() as Promise<boolean>
    });
    return recipeWasDeleted;
}