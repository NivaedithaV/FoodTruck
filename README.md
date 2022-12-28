# FoodTruck

The problem was to create a backend application that facilitates the search process of food trucks in San Fransisco. 

I use the Asp .NET application as discussed or since I have experiene with the same. 
I created a controller that handels the serach requests and takes in all the search parameters to display list of trucks information based on the search criteria. 
I chose to have one endpoint to all the 3 scenarios that was asked for because the basic opperation performed by them were same which is "Searching". This way in future it can have clean code as well as prevent having too many classes/components where it is not needed. 
I had a helper class that takes care of the underlying operations based on the search criteria.

Things that I could have done better with more time would be as follows:

First thing would be to use a database as in SQL DB instead of using an external API with JSON data.
I would have added a swagger documentation(I tried adding it using swashbuckle but then had issues due to timing constraint I had to eliminate it as it would take little bit more time to be resolved).
I would also add test cases to the project.

The amount of time spent is 2-3 hrs.
