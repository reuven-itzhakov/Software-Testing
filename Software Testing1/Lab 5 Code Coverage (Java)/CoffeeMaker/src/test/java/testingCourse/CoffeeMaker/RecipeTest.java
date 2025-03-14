package testingCourse.CoffeeMaker;

import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import testingCourse.CoffeeMaker.Recipe;

public class RecipeTest {

	private Recipe r1;
	private Recipe r2;
	
	@BeforeEach
	public void setUp() throws Exception {
		r1 = new Recipe();
		r2 = new Recipe();		
	}
	
	@Test
	public void GetAmtChocolate() {
		assertEquals(0, r1.getAmtChocolate());
	}

	@Test
	public void SetAmtChocolate() {
		//Equivalence class - neg
		r1.setAmtChocolate(-5);
		assertEquals(0,r1.getAmtChocolate());
		//Equivalence class - pos
		r1.setAmtChocolate(5);
		assertEquals(5,r1.getAmtChocolate());
		//Boundary
		r1.setAmtChocolate(-1);
		assertEquals(5,r1.getAmtChocolate());
		r1.setAmtChocolate(0);
		assertEquals(0,r1.getAmtChocolate());
		r1.setAmtChocolate(1);
		assertEquals(1,r1.getAmtChocolate());
	}

	@Test
	public void GetAmtCoffee() {
		assertEquals(0, r1.getAmtCoffee());
	}

	@Test
	public void SetAmtCoffee() {
		
	}

	@Test
	public void GetAmtMilk() {
		assertEquals(0, r1.getAmtMilk());
	}

	@Test
	public void SetAmtMilk() {
	}

	@Test
	public void GetAmtSugar() {
		assertEquals(0, r1.getAmtSugar());
	}

	@Test
	public void SetAmtSugar() {
	}

	@Test
	public void GetName() {
		assertEquals("", r1.getName());
	}

	@Test
	public void SetName() {
		r1.setName("Coffee");
		assertEquals("Coffee", r1.getName());
	}

	@Test
	public void GetPrice() {
		assertEquals(0, r1.getPrice());
	}

	@Test
	public void SetPrice() {
		r1.setPrice(50);
		assertEquals(50, r1.getPrice());
	}

	/*
	 * Class under  for boolean equals(Recipe)
	 */
	@Test
	public void EqualsRecipe() {
		r1.setName(null);
		r2.setName("asdf");
		assertFalse(r1.equals(r2));
		assertFalse(r2.equals(r1));
		r1.setName("jkl");
		assertFalse(r1.equals(r2));
		assertFalse(r2.equals(r1));
		r1.setName("asdf");
		assertTrue(r1.equals(r2));
		assertTrue(r2.equals(r1));
	}

	/*
	 * Class under  for String toString()
	 */
	@Test
	public void ToString() {
		r1.setName(null);
		assertEquals(r1.toString(), "");
		r1.setName("asdf");
		assertEquals(r1.toString(), "asdf");
	}

}
