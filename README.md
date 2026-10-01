## Buggar:
1. Första buggen är en System.IndexOutOfRangeException  
detta händer eftersom det skapas 4 lines istället för 3 där en line     
har bara en part som är tom. och när man försöker lägga till part[1]    
så finns den inte och då får man en crash.  
Man får även en extra \r på slutet som man behöver ta bort
2. 
### Fix:
1. Ändra ReadAllText => ReadAllLines som automatiskt tar bort \r i slutet och skapar inte en extra tom line.   
Lägger till en if som kollar om det finns en tom line i txt. Om det finns blir den ignorerad.
2.  

