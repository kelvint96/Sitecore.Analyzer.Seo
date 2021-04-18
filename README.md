# Sitecore.Analyzer.Seo

Assignment Project For SEO Analyzing

![image](https://user-images.githubusercontent.com/82433256/115150549-73e9a880-a09b-11eb-88ee-2218a25333aa.png)


## Solutions
| Image  | Port  | Description |
| ----------------------- | ------------ | ------------|
| webmvc  | 8000  | Web Solution using C# and Razor Pages. |
| webscraper.api  | 9001  | REST API solution to handle web scraping requests and stopword management.
| redisdb | 6379| To cache scraped web pages to improve performance.
| mongodb | 27017|  To store stopword data.
| redisinsights | 8100| To view and manage redis cached keys.

## Getting Started

### Prerequisites
|  Name | Download  |
| ------------ | ------------ |
| Git  | https://git-scm.com/downloads  |
| Docker  |  https://www.docker.com/products/docker-desktop |
| .Net 5.0 Runtime | https://dotnet.microsoft.com/download/dotnet/5.0|

Make sure all the prerequisites are installed before proceeding.

### Steps
**Important: Make sure that Docker Desktop is running before proceeding.**

1. Firstly, create an empty folder and clone the repository into the folder.

` git clone https://github.com/kelvint96/Sitecore.Analyzer.Seo`

2. This may take a minute or two. After cloning the repository into the folder, run a cd command to change directory to the source folder that was created.

` cd Sitecore.Analyzer.Seo/src `

3. You may now run the following docker commands to install the images and host the solutions in docker. This might take a minute or two, while docker is pulling the images.

`docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d`

4. After running the above commands, you should be able to see the solution being run on docker desktop.

5. You may now launch the solution from the designated ports:
- **Web UI** - http://localhost:8000
- **Web Scraper API** - http://localhost:9001/swagger/index.html
- **Redis Insights** - http://localhost:8100

