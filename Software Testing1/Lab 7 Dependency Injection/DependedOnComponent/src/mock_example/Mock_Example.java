package mock_example;

import java.io.File;

import javax.jws.WebService;

public class Mock_Example {
	public class LogAnalyzer
	{		
		WebService service = new WebService();
				
		public void Analyze(String fileName) throws Exception {
			if (new File(fileName).length() < 8) {
				service.LogError("File name too short: "+fileName);
			}			
		}		
	}
	public class WebService{
		public void LogError(String message) {
			System.out.print(message);
		}
	}
}
