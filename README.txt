Agri Energy Connect Web Application
Introduction

Welcome to the Agri Energy Connect web application! This application provides functionality for managing farmer profiles, adding new farmer profiles, and viewing/filtering a list of products.
Getting Started

To launch the Agri Energy Connect web application through Visual Studio, follow these steps:

    Clone the Repository: Clone the repository to your local machine using Git:

    bash

    git clone <repository-url>

    Open Solution in Visual Studio: Open the solution file (AgriEnergyConnect.sln) in Visual Studio.

    Build the Solution: Build the solution to restore NuGet packages and compile the project.

    Configure Database Connection: Update the database connection string in the Web.config file to point to your SQL Server instance.

    Run the Application: Press F5 or click on the "Start" button in Visual Studio to run the application. This will launch the web application in your default web browser.

    Navigate to Employee Page: Once the application is running, navigate to the Employee Page by appending /EmployeePage.aspx to the application URL (e.g., 	http://localhost:port/Login.aspx).

Usage
Adding New Farmer Profile

    To add a new farmer profile, enter the farmer's details (first name, last name, email, password) in the input fields provided on the Employee Page.
    Click on the "Add Farmer" button to add the farmer profile.
    The page will be refreshed, and the new farmer profile will be displayed in the list of farmers.

Filtering Products

    To filter products by date range, enter the start date and end date in the input fields provided on the Employee Page.
    Click on the "Filter" button to apply the date range filter.
    The list of products will be updated to display only the products that fall within the specified date range.