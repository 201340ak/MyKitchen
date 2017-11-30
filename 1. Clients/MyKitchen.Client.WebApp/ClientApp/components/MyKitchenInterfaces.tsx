export interface Recipe {
    id?: number;
    name?: string;
    description?: string;
    preparationTime?: number;
    cookTime?: number;
    servings?: number;
    deleted?: boolean;
    ingredients?: RecipeFood[]
};

export interface RecipeFood {
    recipeId?: number;
    foodId?: number;
    food?: Food;
    quantity?: number;
    unit?: Unit;
};

export interface Food {
    id?: number;
    name?: string;
    unit?: Unit;
    servingSize?: number;
    calories?: number;
    price?: number;
    unitQuantityForPrice?: number;
    // recipeFoods: RecipeFood[]
};

export interface Unit {
    // id: number;
    name?: string;
};