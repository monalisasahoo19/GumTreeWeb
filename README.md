
## GumTree Search  
Technology Used : C# ,NUnit and Selenium

Below is the test result from the nUnit Console:
```sh
λ nunit3-console.exe C:\Monalisa\GumTreeWeb\GumTreeSearch\bin\Debug\GumTreeSearchTest.dll                                                         
NUnit Console Runner 3.11.1 (.NET 2.0)                                                                                                                            
Copyright (c) 2020 Charlie Poole, Rob Prouse                                                                                                                      
Tuesday, 7 April 2020 11:21:28 PM                                                                                                                                 
                                                                                                                                                                  
Runtime Environment                                                                                                                                               
   OS Version: Microsoft Windows NT 6.2.9200.0                                                                                                                    
   Runtime: .NET Framework CLR v4.0.30319.42000                                                                                                                   
                                                                                                                                                                  
Test Files                                                                                                                                                        
    C:\Monalisa\GumTreeWeb\GumTreeSearch\bin\Debug\GumTreeSearchTest.dll                                                                          
                                                                                                                                                                  
                                                                                                                                                                  
Errors, Failures and Warnings                                                                                                                                     
                                                                                                                                                                  
1) Failed : GumTreeSearchTest.Test.SearchQueryTests.VerifySearchResult                                                                                            
  Number of results on the page should match the number of results show in label.                                                                                 
  Expected: 24                                                                                                                                                    
  But was:  30                                                                                                                                                    
   at GumTreeSearchTest.Test.SearchQueryTests.VerifySearchResult() in C:\Monalisa\GumTreeWeb\GumTreeSearch\Test\SearchQueryTests.cs:line 63       
                                                                                                                                                                  
Run Settings                                                                                                                                                      
    DisposeRunners: True                                                                                                                                          
    WorkDirectory: C:\Monalisa\GumTreeWeb\packages\NUnit.ConsoleRunner.3.11.1\tools                                                               
    ImageRuntimeVersion: 4.0.30319                                                                                                                                
    ImageTargetFrameworkName: .NETFramework,Version=v4.7.2                                                                                                        
    ImageRequiresX86: False                                                                                                                                       
    ImageRequiresDefaultAppDomainAssemblyResolver: False                                                                                                          
    RuntimeFramework: net-4.0                                                                                                                                     
    NumberOfTestWorkers: 4                                                                                                                                        
                                                                                                                                                                  
Test Run Summary                                                                                                                                                  
  Overall result: Failed                                                                                                                                          
  Test Count: 3, Passed: 2, Failed: 1, Warnings: 0, Inconclusive: 0, Skipped: 0                                                                                   
    Failed Tests - Failures: 1, Errors: 0, Invalid: 0                                                                                                             
  Start time: 2020-04-07 13:21:28Z                                                                                                                                
    End time: 2020-04-07 13:22:44Z                                                                                                                                
    Duration: 75.845 seconds                                                                                                                                      
                                                                                                                                                                  
Results (nunit3) saved as TestResult.xml                                                                                                                          
```
