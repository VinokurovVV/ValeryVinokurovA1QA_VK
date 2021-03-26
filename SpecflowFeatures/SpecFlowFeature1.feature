Feature: VKFeatures
	Check that basic funcions of user page are worked

@vkapitest
Scenario: Sending base commands for user page
	Given I am navigated to vk authorization page 
	When I am login
	And I go to user the page
	When I am adding a post to the page
	Then The post will be created
	When I add a comment to the post
	Then The comment will be created
	When I like the last post
	Then Like on the post will turn up