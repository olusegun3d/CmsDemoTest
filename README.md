**A test automation project**

**Github address : https://github.com/olusegun3d/CmsDemoTest**

**Prerequisites**

-   Visual studio 2022
-   Specflow
-   Nunit
-   Extent report plugin
-   Windows 10 or 11

**Running the tests**

-   To run open the CmsDemoTest.csproj in visual studio
-   If the test explorer window is not opened on visual studio then click on the Test menu of visual studio and select ‘Test Explorer’. ‘Modifying the contents of the cart’ scenario should be present in the Test explorer window
-   You can right click on the ‘Modifying the contents of the cart’ scenario and select Debug or Run
-   The test should run through to the end and pass

**Folder structures**

Most of the source files are in folders that are named appropriately so that navigation can be easier.

**Random selection of products**

A core requirement of the assignment is the random selection of products. My comprehension of this is that the user will need to select random products that are distinct. Consequently the code is a little bit complex as this random choosing will have to be across two pages of listed products. A further complication is that the some of the products are not available for purchase or are being sold on external stores.

On the home page of the website is a listing of the products being sold. There is a maximum of 12 products displayed per page. As of writing, there are a total of 24 products listed on the web site.As a result, we have 12 products on the first page and the second page which is accessible via pagination, also has 12 products.

The end user (encapsulated in the ‘*EndUser’* class) needs to make 4 random but distinct choices from these 24 products. This is done by a function called ‘*ProductsToBeBought’* in the ‘*EndUser’* class.

The function does this by randomly selecting 4 distinct items across the 24 products and then store these 4 items in a list. It then sorts them in ascending order. This sorting is necessary so that all the product indices that fall on a particular page would be processed whilst still on that page.

Take for example, if the customer chooses 4 products with the following indices 20, 3, 15, 1 and they are unsorted. The automation code will need to shuttle back and forth between pages one and two of the product listing to add the items to cart. If the product listing becomes larger, the unsorted listing will slow the automation run significantly. Sorting the shopping list ensures automation code will add to cart all products related to a particular page in one go and then move to the next page

A different function called ‘*Buy’* in the ‘*EndUserClass’* does the actual buying and adding to cart of the selected products.

**Test reporting**

Test reporting is done by the Extent reporting plugin. My current implementation is not as robust as I would like it to be. However, there is screenshotting and all the other features that come out of the box. I have made further modifications to draw a border on the screenshot for the UI element being tested. A green border for pass and a red for fail.

A sample report is contained in the ‘*TestReprting’* folder. This folder contains an archive of passed and failed test folders for reference purposes only. Please view the sample reports. There is also a video capture of the automation run.

Navigate to the following path in the repo to see examples of test report

/CmsDemoTest/TestReporting/Archive/FailedTest/index.html

CmsDemoTest/TestReporting/Archive/PassedTest/index.html

Notice how a border is highlighting the area of interest, in this example it will be the cart listing. Passed test shows a green border and the failed ones red borde.r

**Areas of improvements**

*Modelling of web pages*

For the most part I’m using the webdriver api in a raw manner. Preferably I would like to model the components that make up the page. These would include things like the product cards, menu, header and footers, cart item, etc. Page object relation is also not implemented (that is how one page relates to the other)

*Extension functions*

I have a very minimal extension method function. It needs to cater for more expected conditions and management of selenium exceptions that we can expect to occur during the running of automated tests.

*WebDriver management*

There needs to be a more robust webdriver options implementation

*Object creation*

Dependency injection technology may be ideal for object creation and management
