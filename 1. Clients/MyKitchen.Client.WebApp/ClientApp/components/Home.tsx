import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class Home extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <h1>Welcome to MyKitchen</h1>
            <p>MyKitchen is an new way to manage your recipes, inventory, and shopping experience. When you use a recipe, it will be
                removed from your inventory. We will let you know when you are running low. When you go shopping, you can generate shopping lists
                using the recipes. By knowing what's in your inventory, we can help you not forget anything and help you from getting more of the same item.
                No more of "Do I need to get milk?" when your at the store. No more second trips!
            </p>
            <p>
                MyKitchen will also help you use your inventory effectively. There are days where you have a bunch of ingredients, and it still seems like
                you don't have anything to eat. But now, you can filter recipes by showing ones that only use what you have on hand. You can try something brand new
                and avoid those last minute store runs. 
            </p>
            <p>
                Let's start off by updating your inventory!
            </p>
        </div>;
    }
}
