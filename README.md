Test Automation exercise:
Create a simple Test Automation Framework in .NET (preferable xUnit) for API tests for following API:
http://fakerestapi.azurewebsites.net

Test project should include tests for following requests:
1. GET /api/v1/Activities
Verify if request was successful, amount of activities = 30 and there is no activity with dueDate = yesterday.
2. POST /api/v1/Authors
Verify if request was successfully, response body should be the same as request body.
3. PUT /api/v1/Books/{id}
Verify if request was successfully, response body should be the same as request body.
4. GET /api/v1/Books/{id} for ids from 1 to 10
Verify if request was successfully, Id in response body should be the same as in the request, page count should be 100 for id = 1, 200 for id =1 ... 10000 for id = 10.
5. DELETE /api/v1/Authors/{id} for {id} created in 2. POST /api/v1/Authors
Verify if request was successful

In case of assertion failure, please log request with URL, request body, expected response and actual response.
Framework should allow to run tests in parallel.
