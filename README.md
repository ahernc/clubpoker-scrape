# clubpoker-scrape

This is a simple C# console app which allows you to pull all of the useful poker-related definitions from http://en.clubpoker.net/poker-dictionary.
I wrote this app as I wanted a way to pull over 650 useful definitions for someone learning Poker terminology.

Note: this code worked on 12th Jan 2017. Obviously, websites change. So if the Html structure of clubpoker.net changes, this code might not work. 

## What this app does

1. It will load http://en.clubpoker.net/poker-dictionary into a HtmlDocument using HtmlAgilityPack. 
1. Then it will find all of the links to the use definitions for someone learning poker, for example http://en.clubpoker.net/kicker/definition-274.
1. It will parse the name of the of the term, and its associated definition. Each definition is written out as tab-separated values to a text file. 
1. The text file can be opened in Excel and will load just like a CSV file.


## Setup

1. Clone the repo to your local disk
1. Restore packages
1. Open the file Program.cs. If you want, change the output file specified in the StreamWriter. Otherwise it will just write it out to c:\temp\clubpoker.txt


## Dependencies
https://www.nuget.org/packages/Newtonsoft.Json/

https://www.nuget.org/packages/HtmlAgilityPack/
