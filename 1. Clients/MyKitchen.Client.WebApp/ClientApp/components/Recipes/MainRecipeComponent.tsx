import { AddRecipeCardComponent } from './AddRecipeCard';
import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { RecipeListComponent } from './RecipeList';

interface FetchRecipeDataState{
}

export class MainRecipeComponent extends React.Component<RouteComponentProps<{}>, FetchRecipeDataState> {
    constructor() {
        super();

        this.state = {};
    }

    public render() {
        return <div>
            <h1>Recipes</h1>
            <br />
            <div id="addRecipeArea">
            <AddRecipeCardComponent {...this.props}/>
            </div>
            <RecipeListComponent {...this.props}/>
        </div>
    }
}