package propertyInjection_example;

import java.io.File;

public class PropertyInjection {
	public class LogAnalyzer
	{		
		public boolean IsValidLogFileName(String fileName, String extName) throws Exception {
			if (! new File(fileName).exists()) {	//it was	(1)
			throw new Exception("No log file with that name exists");
			}
			if( !fileName.toLowerCase().endsWith(".pdf")) {
				return false;
			}
			return true;			
		}		
	}	
}
