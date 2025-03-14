package testingCourse.lab2_currencyEditor;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

class MoneyBagTest {
	
	private IMoney testSubject;
	private Money m12usd;
	private Money m10gbp;
	private Money m4gbp;
	private Money m_2usd;
	private Money m_4usd;
	private Money m11nis;
	@BeforeEach
	void setUp() throws Exception {
		testSubject = new MoneyBag(new Money(4,"USD"),new Money(11,"NIS"));
		m12usd = new Money(12,"USD");
		m10gbp = new Money(10,"GBP");
		m4gbp = new Money(4,"GBP");
		m_2usd = new Money(-2,"USD");
		m_4usd = new Money(-4,"USD");
		m11nis = new Money(11,"NIS");
	}
	
	@Test
	// checking functionality: Adding positive value to an existing currency
	// input data: {4USD, 11NIS} + 12USD
	// expected result: {12USD, 11NIS}
	void testAddMoney_PositiveValueOfExistingCurrency() {
		MoneyBag expected = new MoneyBag(new Money(16,"USD"),new Money(11,"NIS"));
		MoneyBag result = (MoneyBag)testSubject.addMoney(m12usd);
		assertEquals(expected, result);
	}
	
	@Test
	// checking functionality: Adding positive value to a non-existing currency
	// input data: {4USD, 11NIS} + 10GBP
	// expected result: {4USD, 11NIS, 10GBP}
	void testAddMoney_PositiveValueOfNonExistingCurrency() {
		MoneyBag expected = new MoneyBag(new Money[]{new Money(4,"USD"),new Money(11,"NIS"),m10gbp}) ;
		MoneyBag result = (MoneyBag)testSubject.addMoney(m10gbp);
		assertEquals(expected, result);
	}
	@Test
	// checking functionality: Adding negative value while not resulting in zero
	// input data: {4USD, 11NIS} + (-2USD)
	// expected result: {2USD, 11NIS}
	void testAddMoney_NegativeValueNotReachingZero() {
		MoneyBag expected = new MoneyBag(new Money(2,"USD"),new Money(11,"NIS")) ;
		MoneyBag result = (MoneyBag)testSubject.addMoney(m_2usd);
		assertEquals(expected, result);
	}
	@Test
	// checking functionality: Adding negative value intentionally reaching zero
	// input data: {4USD, 11NIS} + (-4USD)
	// expected result: 11NIS
	void testAddMoney_NegativeValueReachingZero() {
		Money expected = new Money(11,"NIS");
		Money result = (Money)testSubject.addMoney(m_4usd);
		assertEquals(expected, result);
	}
	
	@Test
	// checking functionality: checking whether a money exists when it does
	// input data: {4USD, 11NIS} ,11NIS
	// expected result: true
	void testContains_ExistingCurrencyExistingValue() {
		boolean result = ((MoneyBag)testSubject).contains(m11nis);
		assertTrue(result);
	}
	@Test
	// checking functionality: checking whether a money exists when the same currency exists but different in value
	// input data: {4USD, 11NIS} ,12USD
	// expected result: false
	void testContains_ExistingCurrencyNotExistingValue() {
		boolean result = ((MoneyBag)testSubject).contains(m12usd);
		assertFalse(result);
	}
	@Test
	// checking functionality: checking whether a money exists when the same value exists but different in currency
	// input data: {4USD, 11NIS} , 4GBP
	// expected result: false
	void testContains_NotExistingCurrencyExistingValue() {
		boolean result = ((MoneyBag)testSubject).contains(m4gbp);
		assertFalse(result);
	}
	@Test
	// checking functionality: checking whether a money exists when it doesn't in value nor currency
	// input data: {4USD, 11NIS} ,10GBP
	// expected result: false
	void testContains_NotExistingCurrencyNotExistingValue() {
		boolean result = ((MoneyBag)testSubject).contains(m10gbp);
		assertFalse(result);
	}

}
