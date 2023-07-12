# azure-resume-mcdonald
This is my online resume hosted in Azure and using Azure CosmosDB and Azure Functions to count and display how many times the page has been viewed.
Following [ACG Azure Reume Project](https://www.youtube.com/watch?v=ieYrBWmkfno&t=2762s).

## First Steps/Frontend

- First I set up my GitHub Repository and cloned it into my local Repository.
- Then I added the provided frontend and backend files. 
- I edited the index.html to correctly reflect me and my skills. 
- main.js was created for the visiter counter code.

## Step Two/Backend

This stage provided much more of a challenge and I learned a lot.

- The first step for the backend was to create my CosmosDB resources. This process was simple as I have experience in this area.
- The next step is to set up Azure Functions. [issue #1] To do this I set up an Azure Function in the api folder in the backend, this is a C# function with .NET 6. Then I created the counter class and added the CosmosDB function bindings. [issue #2]
- The last step was much more simple. I added the local link to the main.js so I could test locally to make sure the counter was updating.

### Step Two Issues
Setting up Azure functions turned out to be very difficult for me, someone who has not touched Azure Functions, .NET, or C#.
#### Issue #1
- To start with the project I am following is a few years old so the process of creating an Azure Function in Visual Studio Code has changed slightly. The changes and vocabulary were only slightly different so I quickly figured out how to properly create one. This is when I ran into my much bigger problem.

#### Issue #2
- The process for creating an Azure Function is simple enough, you select where you want the project to be located, you select the language you want to use, the name of the function, and you select which version of .NET you want to use. In the project .NET 3.1 was used. Initially I wanted to try to use this but after a short time I realised it would not work. After some recearch I decided to use .NET 6, as I had seen some other people create this project using it. Everything was going great untill I tried to run the basic function that it creates for you. I got a big wall of red text. I discovered some researchable error messages and worked and worked but it just would not work. So I bit the bullet and started over. I tried .NET 6 one more time and was not successful. Then I tried .NET 7 and voila! the initial function would activate. But my success was short lived, as soon as I started trying to add the bindings I was getting errors left and right. This led me to the Microsoft documentation but after spending a rough evening of trying again and again to understand what and how I needed to add, I decided to start over. Start way over. I backed up my index.html and main.js and deleted everyting, my local repository and my GitHub repository. I started over and re did the first steps. When I got back to creating the Azure Function I got to thinking, I know for a fact that people were successful using .NET 6, so I reinstalled it, created the function and it worked perfectly. Now I was able to create the bindings as shown in the project and Microsoft documentation.
