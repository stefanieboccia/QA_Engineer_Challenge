
# QA Engineer Challenge

## 🧪 Postman Collection - How to Run

Quick guide on how to run a Postman collection using Postman CLI to generate reports

### Prerequisites
- Newman installed (`npm install -g newman`)
- Node.js installed ([Node.js](https://nodejs.org))
- Exported Postman Collection (`.json file`)

### Steps

Open cmd

Execute the command to generate a test report

**`newman run <my_collection.json> -r html --reporter-html-export <report.html`>**

my_collection.json -> Is the path where the file .json is saved in your computer

report.html        -> Is the path where you want to save the report file in your computer
