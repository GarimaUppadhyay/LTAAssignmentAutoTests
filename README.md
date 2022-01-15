# LTAAssignmentAutoTests
##Introduction:
The current Automated Solution covers two projects (UI and API)
 1. BuggyCarsRatingAPIAutoTests - API Project
 2. BuggyCarsRatingUIAutoTests  - UI Project

 ## Tools and Technologies used:
 Programming language - C#
 Test Automation Tool - Selenium 
 For BDD scenario creation - Spec Flow  
 Rest Sharp (for API Project)

 ## Software Requirements:
 Visual Studio 2019
 Git Hub
 
 ## Cloning and Running The Tests
- Clone the repo named “LTAAssignmentAutoTests (https://github.com/GarimaUppadhyay/LTAAssignmentAutoTests) ” in VS2019 or using Git command line
- Open the solution and build the solution
- Navigate to View-> Test Explorer, Test Explorer will be open on the left panel
- Right click the top feature project (either UI or API) and click run (or select all the tests and click run)


 ## Test Coverage:
 ### Covers Below scenarios for UI 
 - Successful User Registration
 - UnUnsuccessful User Registration - Existing User
 - Validating Registered User can Vote
 - Validating UnRegistered user cannot vote

 ### Covers Below scenarios for API 
 - Successful User Registration
 - UnUnsuccessful User Registration - Existing User
 - Validating Password check with different combination, while registering user


 ## Active Repository:
 Follow the link to navigate and clone the repository "LTAAssignmentAutoTests" to your local repo path

 ## Automation Framework Design & Structure:
 The UI Automation framework is flexibly designed and easy to understand:
 - Based on POM
 Comparises of below folder structure:

 - Application Feature: This contains list application features, contains test sceanrios written in spec flow.
 - Helper: This is a helper class for common utilities and config helpers for reusable generic methods for screenshots and config properties etc.
 - Objects: This folder contains page specific objects/locators based on IDs, classes, XPaths etc.
 - Pages: This folder contains actual business logic for specific application pages
 - Step Definition: This folder contains all the features specific generated steps
 - TestData: This folder contains TestDataProvider class for managing static variables to be used in the application
 - BaseTest: This class contains Specflow Base for base set up and cleanup


## The API Automation framework is also based on POM
 Comparises of below folder structure:

   - Helper: This is a helper class for common utilities, API Helper( for RestClient initialization and common method for Executing Request/Response) and config helpers for reusable generic methods for screenshots and config properties etc.
   - Model: This contains list of classes with actual endpoint hierarchy, contains methods for generating the request body, Validating request payload by capturing response(s).
   - Step Definition: This folder contains all the features specific generated steps.
   - TestData: This contains list application features, contains test sceanrios written in spec flow.
