Feature: Beacons API Tests

  Scenario: Single beacon added
    Given there are no saved beacons
    When the following beacons are added
        | Owner                                |
        | Farmer Ted                           |
    Then the number of saved beacons should be 1
