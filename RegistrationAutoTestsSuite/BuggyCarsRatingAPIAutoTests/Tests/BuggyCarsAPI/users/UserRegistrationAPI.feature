Feature: BuggyRegistrationAPI

Scenario Outline:  (1) - Register User and Validate
	Given User has provided "<UserName>" "<FirstName>" "<LastName>" "<Password>" "<ConfirmPassword>" for "users" API
	When User Submit API Request by "POST" method with json for "Registration" to end point "users"
	Then the response should show "StatusCode" "EQUALS" "<ExpectedStatus>"
	And the response should show "message" "EQUALS" "<Message>"

	Examples:
		| Scenario        | UserName | FirstName | LastName | Password    | ConfirmPassword | ExpectedStatus | Message                                                                                                 |
		| 01_NewUser      | Test     | Test      | Test     | Pass123     | Pass123         | BadRequest     | InvalidPasswordException: Password did not conform with policy: Password not long enough                |
		| 02_NewUser      | Test     | Test      | Test     | Pass1234    | Pass1234        | BadRequest     | InvalidPasswordException: Password did not conform with policy: Password must have symbol characters    |
		| 03_NewUser      | Test     | Test      | Test     | password    | password        | BadRequest     | InvalidPasswordException: Password did not conform with policy: Password must have uppercase characters |
		| 04_NewUser      | Test     | Test      | Test     | PASSWORD123 | PASSWORD123     | BadRequest     | InvalidPasswordException: Password did not conform with policy: Password must have lowercase characters |
		| 05_NewUser      | Test     | Test      | Test     | Pass@123    | Pass@123        | Created        |                                                                                                         |
		| 06_ExistingUser | Test     | Test      | Test     | Pass@123    | Pass@123        | BadRequest     | UsernameExistsException: User already exists                                                            |