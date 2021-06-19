# Shopping Cart
A simple console application of a shopping cart that can add or remove given products and provide a sub-total.
The application can also handle promotions such as "3 for 40" or "25% off 2" offers.

## What I learned?
What I learned from creating this application is the use of continued test driven development as a discipline has high value.
Starting with an acceptance criteria and working from the outter edge of an issue and working inward to the core functionality helps you locate edge cases in the code, helps you better refactor and rename methods & variables to suit their purpose as the code transforms as well as aids in the documentation process of your application.

If I was to continue to improve upon this I would probably look to depend on abstractions a bit more, not use static classes for my controllers and maybe make better use of interfaces.

I would also probably employ a design pattern like a strategy pattern for the algorithms on promotion calculations to make it more modular as currently a switch case with concrete methods would break open/close principle if you were to attempt to add more promotion methods.

We continue learning.
