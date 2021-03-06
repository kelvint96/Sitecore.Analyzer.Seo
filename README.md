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
**Important: Make sure that Docker Desktop is running before proceeding. Please also ensure that no other application are running on the same ports as the application mentioned in the section above.**

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

#### Optional: Using Redis Insights
1. Accept all the terms and conditons on the first screen when entering redis insights for the first time.
2. Choose "I already have a database option" and click on "Connect to a Redis Database"
![image](https://user-images.githubusercontent.com/82433256/115178689-6ddbe200-a104-11eb-8800-dd8ac10a4d87.png)
![image](https://user-images.githubusercontent.com/82433256/115178757-89df8380-a104-11eb-9684-88f88cc56f0d.png)

3. Key in the following options and click on Add Redis Database.
 `Host: redisdb
  Port: 6379
  Name: redisdb`

4. The redis Insights will be ready and you can now view the stats and lookup on redis cache on redisdb.
![image](https://user-images.githubusercontent.com/82433256/115179026-01adae00-a105-11eb-8606-ff40e43621fc.png)

