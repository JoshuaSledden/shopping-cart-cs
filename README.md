# Shopping Cart
A simple console application of a shopping cart that can add or remove given products and provide a sub-total.
The application can also handle promotions such as "3 for 40" or "25% off 2" offers.

## Requirements
The application requirements are as follows:

* Given I have selected to add an item to the basket Then the item should be added to the basket
* Given items have been added to the basket Then the total cost of the basket should be calculated
* Given I have added a multiple of 3 lots of item ‘B’ to the basket Then a promotion of ‘3 for 40’ should be applied to every multiple of 3
* Given I have added a multiple of 2 lots of item ‘D’ to the basket Then a promotion of ‘25% off’ should be applied to every multiple of 2

## Methods Used

* Employed TDD disciplines when attempting to meet the given requirements criteria.
* Consistently refactored the code to attempt to meet principles such as SOLID, GRASP, DRY.
* Clear use of documentation both within unit test cases and the code base to explain code function.
* Make use of interfaces and avoid depending on concrete classes where possible.


### What I learned?
What I learned from creating this application is the use of continued test driven development as a discipline has high value.
Starting with an acceptance criteria and working from the outter edge of an issue and working inward to the core functionality helps you locate edge cases in the code, helps you better refactor and rename methods & variables to suit their purpose as the code transforms as well as aids in the documentation process of your application.

I would probably employ a design pattern like a strategy pattern for the algorithms on promotion calculations to make it more modular as currently a switch case with concrete methods would break open/close principle if you were to attempt to add more promotion methods.

We continue learning.
