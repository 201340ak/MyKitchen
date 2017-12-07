export interface Recipe {
    id?: number;
    name?: string;
    description?: string;
    preparationTime?: number;
    cookTime?: number;
    servings?: number;
    deleted?: boolean;
    ingredients?: Ingredient[];
    image?: string;
};

export interface Ingredient {
    recipeId?: number;
    foodId?: number;
    food?: Food;
    quantity?: number;
    unit?: Unit;
};

export interface Food {
    id?: number;
    name?: string;
    units?: Unit[];
    servingSize?: number;
    calories?: number;
    price?: number;
    unitQuantityForPrice?: number;
};

export interface Unit {
    id?: number;
    name?: string;
};