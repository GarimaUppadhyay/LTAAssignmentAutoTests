Feature: UserRegistration

Background:
	Given User navigates to Buggy Cars site

Scenario Outline:(1) Validate User Registration
	When User clicks on Registration "<Scenario>" and enter "<LoginName>", "<FirstName>", "<LastName>", "<Password>" and "<ConfirmPassword>" to registor
	Then User validates success "<message>"

	Examples:
		| Scenario | LoginName | FirstName | LastName | Password | ConfirmPassword | message                    |
		| Valid    | Test1     | FTest1    | LTest1   | Pass@123 | Pass@123        | Registration is successful |
		| InValid  | Test1     | FTest1    | FTest1   | Pass@123 | Pass@123        | User already exists        |

Scenario Outline:(2) Validate Registered User Votes
	When The "<Registered>" user enters "<User>" and "<Password>" and login
	Then "<Registered>" User can Vote and "<Comment>" for Sports "<CarModel>" and "<Validates>"

	Examples:
		| Scenario         | User    | Password | Comment | CarModel | Registered       | Validates                         |
		| RegisteredUser   | Valid   | Pass@123 | Test    | Diablo   | RegisteredUser   | Thank you for your vote!          |
		| UnRegisteredUser | Invalid | Invalid  | Test    | Diablo   | UnRegisteredUser | You need to be logged in to vote. |