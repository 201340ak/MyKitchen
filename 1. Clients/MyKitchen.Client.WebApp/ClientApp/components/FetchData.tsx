import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface FetchDataExampleState {
    forecasts: WeatherForecast[];
    loading: boolean;
}

interface FetchRecipeDataState{
    recipes: Recipe[];
    loading: boolean;
}

export class FetchData extends React.Component<RouteComponentProps<{}>, FetchDataExampleState> {
    constructor() {
        super();
        this.state = { forecasts: [], loading: true };

        fetch('api/SampleData/WeatherForecasts')
            .then(response => response.json() as Promise<WeatherForecast[]>)
            .then(data => {
                this.setState({ forecasts: data, loading: false });
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderForecastsTable(this.state.forecasts);

        return <div>
            <h1>Weather forecast</h1>
            <p>This component demonstrates fetching data from the server.</p>
            { contents }
        </div>;
    }

    private static renderForecastsTable(forecasts: WeatherForecast[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Temp. (C)</th>
                    <th>Temp. (F)</th>
                    <th>Summary</th>
                </tr>
            </thead>
            <tbody>
            {forecasts.map(forecast =>
                <tr key={ forecast.dateFormatted }>
                    <td>{ forecast.dateFormatted }</td>
                    <td>{ forecast.temperatureC }</td>
                    <td>{ forecast.temperatureF }</td>
                    <td>{ forecast.summary }</td>
                </tr>
            )}
            </tbody>
        </table>;
    }
}

export class FetchRecipe extends React.Component<RouteComponentProps<{}>, FetchRecipeDataState> {
    constructor() {
        super();
        this.state = { recipes: [], loading: true };

        fetch('api/SampleData/Recipes')
            .then(response => response.json() as Promise<Recipe[]>)
            .then(data => {
                this.setState({ recipes: data, loading: false });
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchRecipe.renderRecipesTable(this.state.recipes);
            
        return <div>
            <h1>All Recipes</h1>
            <p>This component demonstrates fetching data from the server.</p>
            { contents }
        </div>
    }
    
        private static renderRecipesTable(recipes: Recipe[]) {
            return <table className='table'>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Description</th>
                        <th>Preparation Time</th>
                        <th>Cook Time</th>
                        <th>Servings</th>
                    </tr>
                </thead>
                <tbody>
                {recipes.map(recipe =>
                    <tr key={ recipe.id }>
                        <td>{ recipe.id }</td>
                        <td>{ recipe.name }</td>
                        <td>{ recipe.description }</td>
                        <td>{ recipe.preparationTime }</td>
                        <td>{ recipe.cookTime }</td>
                        <td>{ recipe.servings }</td>
                    </tr>
                )}
                </tbody>
            </table>;
        }
}

interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

interface Recipe {
    id: number;
    name: string;
    description: string;
    preparationTime: number;
    cookTime: number;
    servings: number;
    deleted: boolean;
    // TODO: Add list of recipeFoods;
}
