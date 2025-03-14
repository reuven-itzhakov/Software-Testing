package constructorInjection_example;

import constructorInjection_example.ConstructorInjection.LogAnalyzer;

public class MainConstructorInjection {

	public static void main(String[] args) throws Exception {
		ConstructorInjection cIE = new ConstructorInjection();
				
		LogAnalyzer logA = cIE.new LogAnalyzer();
		
		String fileName = "k:\\test.doc";
		System.out.print(logA.IsValidLogFileName(fileName));

	}

}
