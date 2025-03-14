package constructorInjection_example;
import java.io.File;

public class ConstructorInjection {
	public class LogAnalyzer
	{
		public boolean IsValidLogFileName(String fileName) throws Exception {
			if (! new File(fileName).exists()) {
			throw new Exception("No log file with that name exists");
			}
			if( !fileName.toLowerCase().endsWith(".docx")) {
				return false;
			}
			return true;			
		}		
	}	
}
