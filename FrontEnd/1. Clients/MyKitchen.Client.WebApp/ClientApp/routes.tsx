import { AddRecipeCardComponent } from './components/Recipes/AddRecipeCard';
import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Counter } from './components/Counter';
import { MainRecipeComponent } from './components/Recipes/MainRecipeComponent';
import { Login } from './components/Login';
import { ImageUploaderComponent } from './components/Recipes/ImageUploader';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/recipes' component={ MainRecipeComponent } />
    <Route path='/add-recipe' component={ AddRecipeCardComponent } />
</Layout>;
