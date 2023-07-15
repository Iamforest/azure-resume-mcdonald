# azure-resume-mcdonald
This is my online resume hosted in Azure and using Azure CosmosDB and Azure Functions to count and display how many times the page has been viewed.
Following [ACG Azure Resume Project](https://www.youtube.com/watch?v=ieYrBWmkfno&t=2762s).

### Technologies used
- Azure CosmosDB
- Azure Functions
- Azure Blob Storage
- Azure CDN
- Azure CLI
- GitHub Actions

### Practices Used
- CI/CD
- Unit Testing
- Documentation

## First Steps: Frontend

- First I set up my GitHub Repository and cloned it into my local Repository.
- Then I added the provided frontend and backend files.
- I edited the index.html to correctly reflect me and my skills.
- main.js was created for the visitor counter code.

## Step Two: Backend

This stage provided much more of a challenge and I learned a lot.

- The first step for the backend was to create my CosmosDB resources. This process was simple as I have experience in this area.
- The next step is to set up Azure Functions. [issue #1] To do this I set up an Azure Function in the api folder in the backend, this is a C# function with .NET 6. Then I created the counter class and added the CosmosDB function bindings. [issue #2]
- The last step was much more simple. I added the local link to the main.js so I could test locally to make sure the counter was updating.

### Step Two Issues
Setting up Azure functions turned out to be very difficult for me, someone who has not touched Azure Functions, .NET, or C#.
#### Issue #1
- To start with, the project I am following is a few years old so the process of creating an Azure Function in Visual Studio Code has changed slightly. The changes and vocabulary were only slightly different so I quickly figured out how to properly create one. This is when I ran into my much bigger problem.

#### Issue #2
- The process for creating an Azure Function is simple enough, you select where you want the project to be located, you select the language you want to use, the name of the function, and you select which version of .NET you want to use. In the project .NET 3.1 was used. Initially I wanted to try to use this but after a short time I realized it would not work. After some research I decided to use .NET 6, as I had seen some other people create this project using it. Everything was going great until I tried to run the basic function that it creates for you. I got a big wall of red text. I discovered some researchable error messages and worked and worked but it just would not work. So I bit the bullet and started over. I tried .NET 6 one more time and was not successful. Then I tried .NET 7 and voila! the initial function would activate. But my success was short lived, as soon as I started trying to add the bindings I was getting errors left and right. This led me to the Microsoft documentation but after spending a rough evening of trying again and again to understand what and how I needed to add, I decided to start over. Start way over. I backed up my index.html and main.js and deleted everything, my local repository and my GitHub repository. I started over and re-did the first steps. When I got back to creating the Azure Function I got to thinking, I know for a fact that people were successful using .NET 6, so I reinstalled it, created the function and it worked perfectly. Now I was able to create the bindings as shown in the project and Microsoft documentation.

## Step Three: Deploying

This stage was a lot of fun as I finally got to see my hard work and troubleshooting pay off.

- The first step is to deploy my Azure Function to Azure. To do this I need a function app. I ran the Create Azure Functions App (advanced) and it created very quickly. Now I can deploy my function to azure.
- I needed to add an application setting to the Azure Function App. The setting is the connection string for my CosmosDB account. My bindings in the Azure Function uses this to connect to the correct database.
- The Azure Function is ready so I take the function URL and put it into main.js so the data can be called from this api.
- After deploying the function to Azure it is time to deploy my static site to blob storage. The project created a storage account using Visual Studio Code but I decided to try from Azure. This did not work for me as the options were slightly different and the storage account I created did not have static website functionality. So I deleted the resource and created the storage account in Visual Studio Code, and deployed my site to the storage account.
- Now, in that storage account I created a CDN for HTTPS and custom domain support. This was very simple, I just put in the required information and after waiting a while it was ready for a custom domain.
- Once the CDN is created I can add my custom domain and my site is ready to go!

## Step Four: CI/CD

When I first started this project I was very excited and curious to learn this part, as I have heard a lot about CI/CD and know it is a valuable skill. I will be using GitHub Actions.

- First I created the frontend pipeline. To do this I created my .github and workflows folder. Then I had to get my Azure secret and put it to Actions Secrets in GitHub.
- Then I used the documentation provided by Microsoft and added the code to my frontend yml file. I updated it with my information, pushed it to GitHub and it worked! Now when I make changes to the frontend file they are automatically deployed to Azure when I push them to GitHub.
- The process was very similar for the backend but I did have to do some digging to find the code for the yml file.

## Step Five: Testing

This step is testing for the backend code when it is deployed. This is to make sure that if I make a change and it messed something up it will not make it to Azure.

- I used the provided test files and created a job in the backend yml file that runs the tests. If any of the tests fail the workflow will not succeed and the deployment will not make it to Azure.

## Reflections

This was a really good project. I ended up with a great website and I learned a lot. I loved getting hands on with all these technologies. The thing I learned most was to take everything step by step and not to get ahead of myself. There were times where I rushed ahead thinking I knew what to do next and ended up creating more work for myself.
