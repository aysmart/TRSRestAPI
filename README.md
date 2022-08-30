# PwC .Net Technical Assessment

Travel Requisition System

## CRUD endpoints

<p>The Api provides several endpoints and they are all listed below with a sample body json data to place a request.</p>

## User Authentication

<p>User Authentication is used to verify the user and then returns an Authenticaton Bearer Token that should be added to the request header while accessing the API endpoints.</p>

***Endpoint:*** https://localhost:7022/api/trs/authenticate

***Method:*** POST

### Sample Body Data

    {
        "userName":"pwc1",
        "userPassword":"password1"
    }


## Add New Travel Request

<p>This takes in the json body data, add the record to database and returns the requestID to client.</p>

***Endpoint:*** https://localhost:7022/api/trs/addTravelData

***Method:*** POST

### Sample Body Data

    {
        "requestDate": "2022-08-28T00:00:00",
        "sourceLocation": "Lagos Nigeria",
        "sourceCountry": "Nigeria",
        "destinationLocation": "London",
        "destinationCountry": "United Kingdom",
        "departureTimestamp": "2022-09-13T00:00:00",
        "travelClass": "Economy",
        "tripType": "Round Trip",
        "chargeCode": "HDT486",
        "travelerName": "Ayorinde Smart",
        "requestStatus": "Submitted"
    }

## View All Existing Data in Database

<p>This returns a json string of all existing travel requests in database.</p>

***Endpoint:*** https://localhost:7022/api/trs/getTravelData

***Method:*** GET

### Sample Body Data

    No need for Body Data

## View Existing Data in Database by RequestID

<p>This returns a json string of the specific travel request in database matching the requestID if it exists.</p>

***Endpoint:*** https://localhost:7022/api/trs/singleTravelData

***Method:*** GET

### Sample Body Data

    {
        "requestID": 1
    }

## Update An Existing Travel Request

<p>This takes in the json body data and updates an existing record in database if not booked.</p>

***Endpoint:*** https://localhost:7022/api/trs/updateTravelData

***Method:*** PUT

### Sample Body Data

    {
        "requestID": 1,
        "requestDate": "2022-08-28T00:00:00",
        "sourceLocation": "Abuja Nigeria",
        "sourceCountry": "Nigeria",
        "destinationLocation": "London",
        "destinationCountry": "United Kingdom",
        "departureTimestamp": "2022-09-13T00:00:00",
        "travelClass": "Business",
        "tripType": "Round Trip",
        "chargeCode": "HDT486",
        "travelerName": "Ayorinde Smart",
        "requestStatus": "Submitted"
    }

## Delete Existing Data in Database by RequestID

<p>This deletes the specific travel request in database matching the requestID if it exists and not booked.</p>

***Endpoint:*** https://localhost:7022/api/trs/deleteTravelData

***Method:*** DELETE

### Sample Body Data

    {
        "requestID": 1
    }

## Search For Country and Weather Forcast Details By Country Name

<p>This uses the country name stated in the request body and returns the country and weather forecast details.</p>

***Endpoint:*** https://localhost:7022/api/trs/search

***Method:*** GET

### Sample Body Data

    {
        "name":"Nigeria"
    }
