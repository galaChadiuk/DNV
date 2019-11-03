# DNV
In this solution you can find tests which cover functionality descried below:
- redirect to Veracity login page
- possibility to change site region
- possibility to search be keywork
- possibility to open Contact us page

These tests could be run with Chrome and FireFox browsers

Test suite can be extended with following test:
Varacity:
 - verify sucessful sign up
 - verify error message in case of creating account with password which doesn't meet criteria: 
    Contain at least 8 characters
    Contain at least one lower case letter (a-z)
    Contain at least one upper case letter (A-Z)
    Contain at least one number (0-9)
    Not contain characters: '<' or '>'
    Not contain your first name
    Not contain your last name
- verify error message in case of creating account with empty required fields
- verify error message in case of creating account when phone number doesn't start with country code
- vefiry sucessful sign in
- verify error message in case of sign in with unexisting user
- verify error message in case of sign in with incorrect password
Navigation:
- chect Sectors menu items
- check Services menu items
- check Insights menu items
- check About us menu items
- navigation to Global news/Tweets/Video insights/Events
- check indastry pages 
- check About us menu items
- check Contact Us menu items
Social media:
- check redirect to Facebook
- check redirect to Tweeter
- check redirect to Linkedin
Search
- check sucessful Base/Advanced search
- check unsucessful Base/Advanced search
