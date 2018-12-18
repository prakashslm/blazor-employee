import { Recipe } from "./recipe.model";
import { Injectable } from "@angular/core";
import { Ingredient } from "../shared/ingredient.model";
import { ShoppingListService } from '../shopping-list/shopping-list.service';
import { Subject } from 'rxjs';

@Injectable()
export class RecipeService{
    recipesChanged = new Subject<Recipe[]>();
  private recipes : Recipe[] = [
        new Recipe('A Test Recipe',
        'This is simply a test',
        'https://img.delicious.com.au/52hfFIjf/h506-w759-cfill/del/2017/05/one-pot-butter-chicken-with-dill-yoghurt-46876-2.jpg',
    [
        new Ingredient('Meat', 1),
        new Ingredient('French Fries', 20)
    ]),
        new Recipe('A Test Recipe',
        'This is simply a test',
        'https://food.fnr.sndimg.com/content/dam/images/food/fullset/2012/2/29/0/0149359_Making-Taco_s4x3.jpg.rend.hgtvcom.616.462.suffix/1371603491866.jpeg',
    [
        new Ingredient('Buns', 2),
        new Ingredient('Meat', 1)
    ])
      ];

      constructor(private slService : ShoppingListService){}

      getRecipes(){
          return this.recipes.slice();
      }
      getRecipe(index : number){
          return this.recipes[index];
      }


      addIngredientsToShoppingList(ingredients : Ingredient[]){
          this.slService.addIngredients(ingredients);
      }     
      
      addRecipe(recipe: Recipe) {
        this.recipes.push(recipe);
        this.recipesChanged.next(this.recipes.slice());
      }
    
      updateRecipe(index: number, newRecipe: Recipe) {
        this.recipes[index] = newRecipe;
        this.recipesChanged.next(this.recipes.slice());
      }
      deleteRecipe(index: number) {
        this.recipes.splice(index, 1);
        this.recipesChanged.next(this.recipes.slice());
      }
}
