package testingCourse.CoffeeMaker;

import testingCourse.CoffeeMaker.CoffeeMaker;
import testingCourse.CoffeeMaker.Recipe;

import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

//import static org.junit.Assert.*;
//import org.junit.Before;
//import org.junit.Test;

public class CoffeeMakerTest {
	private CoffeeMaker cm;
	private Recipe r1;
	private Recipe r2;
	private Recipe r3;
	private Recipe r4;

	@BeforeEach
	public void setUp() throws Exception {
	
		cm = new CoffeeMaker();
		
		//Set up for r1
		r1 = new Recipe();
		r1.setName("Coffee");
		r1.setAmtChocolate(0);
		r1.setAmtCoffee(3);
		r1.setAmtMilk(1);
		r1.setAmtSugar(1);
		r1.setPrice(50);
		
		//Set up for r2
		r2 = new Recipe();
		r2.setName("Mocha");
		r2.setAmtChocolate(2);
		r2.setAmtCoffee(3);
		r2.setAmtMilk(1);
		r2.setAmtSugar(1);
		r2.setPrice(75);
		
		//Set up for r3
		r3 = new Recipe();
		r3.setName("Latte");
		r3.setAmtChocolate(0);
		r3.setAmtCoffee(3);
		r3.setAmtMilk(3);
		r3.setAmtSugar(1);
		r3.setPrice(100);
		
		//Set up for r4
		r4 = new Recipe();
		r4.setName("Hot Chocolate");
		r4.setAmtChocolate(4);
		r4.setAmtCoffee(0);
		r4.setAmtMilk(1);
		r4.setAmtSugar(1);
		r4.setPrice(65);		
	}
	
	@Test
	public void AddRecipe() {
		assertTrue(cm.addRecipe(r1));
		assertEquals(cm.getRecipeForName("Coffee"),r1);
		assertTrue(cm.addRecipe(r2));
		assertEquals(cm.getRecipeForName("Mocha"), r2);
		assertFalse(cm.addRecipe(r1));
		assertTrue(cm.addRecipe(r3));
		assertEquals(cm.getRecipeForName("Latte"), r3);
		assertFalse(cm.addRecipe(r4));
		assertEquals(cm.getRecipeForName("Hot Chocolate"), null);
	}

	@Test
	public void DeleteRecipe() {
		assertFalse(cm.deleteRecipe(r1));
	}

	@Test
	public void EditRecipe() {
		assertFalse(cm.editRecipe(r1,r2));
		cm.addRecipe(r1);
		assertTrue(cm.editRecipe(r1,r2));
		assertEquals(cm.getRecipeForName("Mocha"),r2);
	}

	@Test
	public void AddInventory() {
		//An inventory is initialized with 15 units of each ingredient
		assertTrue(cm.addInventory(0,0,0,0));
		assertEquals(cm.checkInventory().getChocolate(), 15);
		assertEquals(cm.checkInventory().getCoffee(), 15);
		assertEquals(cm.checkInventory().getMilk(), 15);
		assertEquals(cm.checkInventory().getSugar(), 15);
		
		assertFalse(cm.addInventory(-1,0,0,0));
		assertEquals(cm.checkInventory().getChocolate(), 15);
		assertEquals(cm.checkInventory().getCoffee(), 15);
		assertEquals(cm.checkInventory().getMilk(), 15);
		assertEquals(cm.checkInventory().getSugar(), 15);
		
		assertFalse(cm.addInventory(0,-1,0,0));
		assertEquals(cm.checkInventory().getChocolate(), 15);
		assertEquals(cm.checkInventory().getCoffee(), 15);
		assertEquals(cm.checkInventory().getMilk(), 15);
		assertEquals(cm.checkInventory().getSugar(), 15);
		
		assertFalse(cm.addInventory(0,0,-1,0));
		assertEquals(cm.checkInventory().getChocolate(), 15);
		assertEquals(cm.checkInventory().getCoffee(), 15);
		assertEquals(cm.checkInventory().getMilk(), 15);
		assertEquals(cm.checkInventory().getSugar(), 15);
		
		assertFalse(cm.addInventory(0,0,0,-1));
		assertEquals(cm.checkInventory().getChocolate(), 15);
		assertEquals(cm.checkInventory().getCoffee(), 15);
		assertEquals(cm.checkInventory().getMilk(), 15);
		assertEquals(cm.checkInventory().getSugar(), 15);
	}

	@Test
	public void CheckInventory() {
		assertEquals(cm.checkInventory().getChocolate(), 15);
		assertEquals(cm.checkInventory().getCoffee(), 15);
		assertEquals(cm.checkInventory().getMilk(), 15);
		assertEquals(cm.checkInventory().getSugar(), 15);
	}

	@Test
	public void MakeCoffee() {
		cm.addRecipe(r1);
		cm.addRecipe(r2);
		cm.addRecipe(r3);
		assertEquals(cm.makeCoffee(r1, 100), 50);
		assertEquals(cm.makeCoffee(r1, 45), 45);
		assertEquals(cm.makeCoffee(r4, 60), 60);
		assertEquals(cm.makeCoffee(r1, 100), 50);
	}

	@Test
	public void GetRecipeForName() {
		cm.addRecipe(r1);
		assertEquals(cm.getRecipeForName("Coffee"), r1);
		assertEquals(cm.getRecipeForName("Mocha"), null);
	}

	@Test
	public void GetRecipeFull() {
		boolean [] recipeFull = cm.getRecipeFull();
		for(int i = 0; i < recipeFull.length; i++) {
			assertFalse(recipeFull[i]);
		}
	}
}
