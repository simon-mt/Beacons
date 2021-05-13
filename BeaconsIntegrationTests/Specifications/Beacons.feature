Feature: Beacons API Tests

  Scenario: Single beacon added
    Given there are no saved beacons
    When the following beacons are added
        | Name                                 |
        | Farmer Ted's favourite tractor       |
    Then the number of saved beacons should be 1
