package testingCourse.lab2_currencyEditor;

import static org.junit.jupiter.api.Assertions.assertTrue;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

public class MoneyTest
{     
    private Money m12chf;
	private Money m14chf;
	
	@BeforeEach
	protected void setUp() throws Exception {
		m12chf= new Money(12,"CHF");
		m14chf= new Money(14,"CHF");
	}

	// checking functionality: sum of two positive values
	// input data: 12 CHF + 14CHF 
	// expected result: 26CHF
    @Test	    
	public void testAdd_PositiveValues() {
		Money expected= new Money(26,"CHF");
		Money result= (Money)m12chf.add(m14chf);
		assertTrue(expected.equals(result));
	}

    
    // checking functionality: equivalence of two objects with the same content
	@Test	
    public void testEquals_SameValue() {
		assertTrue(m12chf.equals(new Money(12, "CHF"))); 
    }	
	
	
    // checking functionality: object is not equal to NULL
     @Test	
     public void testEquals_NULL() {
        assertTrue(!m12chf.equals(null)); 
     }
       
    
     // checking functionality: two objects with different content are not equal
     @Test	
     public void testEquals_DifferentValues() {
    	  assertTrue(!m12chf.equals(m14chf)); 
     }     
}


