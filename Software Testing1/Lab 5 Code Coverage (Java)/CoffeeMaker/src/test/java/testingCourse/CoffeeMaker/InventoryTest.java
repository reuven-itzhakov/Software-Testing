package testingCourse.CoffeeMaker;

import testingCourse.CoffeeMaker.Inventory;
import testingCourse.CoffeeMaker.Recipe;

import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

public class InventoryTest {

	private Inventory i;
	
	@BeforeEach
	public void setUp() throws Exception {
		i = new Inventory();		
	}

	@Test
	public void Inventory() {
		assertEquals(15, i.getCoffee());
		assertEquals(15, i.getMilk());
		assertEquals(15, i.getSugar());
		assertEquals(15, i.getChocolate());
	}

	@Test
	public void GetCoffee() {
		assertEquals(15, i.getCoffee());
	}

	@Test
	public void SetCoffee() {
		i.setCoffee(7);
		assertEquals(7, i.getCoffee());
	}
	
	@Test
	public void SetCoffeeNeg() {
		i.setCoffee(-1);
		assertEquals(15, i.getCoffee());
	}

	@Test
	public void GetMilk() {
		assertEquals(15, i.getMilk());
	}

	@Test
	public void SetMilk() {
		i.setMilk(3);
		assertEquals(3, i.getMilk());
	}
	
	@Test
	public void GetSugar() {
		assertEquals(15, i.getSugar());
	}

	@Test
	public void SetSugar() {
		i.setSugar(1);
		assertEquals(1, i.getSugar());
	}
	
	@Test
	public void SetSugarNeg() {
		i.setSugar(-1);
		assertEquals(15, i.getSugar());
	}

	@Test
	public void EnoughIngredients() {
		Recipe r1 = new Recipe();
		r1.setAmtChocolate(16);
		assertFalse(i.enoughIngredients(r1));
		r1.setAmtChocolate(0);
		r1.setAmtCoffee(16);
		assertFalse(i.enoughIngredients(r1));
		r1.setAmtChocolate(0);
		r1.setAmtCoffee(0);
		r1.setAmtMilk(16);
		assertFalse(i.enoughIngredients(r1));
		r1.setAmtMilk(0);
		r1.setAmtSugar(16);
		assertFalse(i.enoughIngredients(r1));
	}

	/*
	 * Class under  for String toString()
	 */
	@Test
	public void ToString() {
		String s = "Coffee: 15\n" +
			"Milk: 15\n" +
			"Sugar: 15\n" +
			"Chocolate: 15\n";
		assertEquals(i.toString(), s);
	}

}
