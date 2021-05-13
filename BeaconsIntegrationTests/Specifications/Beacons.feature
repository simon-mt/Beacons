Feature: Beacons API Tests

  Scenario: Single beacon added
    Given there are no saved beacons
    When the following beacons are added
        | Name                                 | Activated |
        | Ted                                  | n         |
    Then the number of saved beacons should be 1

  Scenario: Search beacon by name
    Given the following beacons exist
        | Name                                 | Activated |
        | Ted                                  | n         |
        | John                                 | n         |
        | Jack                                 | n         |
    When beacon John is requested
    Then the number of returned beacons should be 1

  Scenario: Search beacon by active
    Given the following beacons exist
        | Name                                 | Activated  |
        | Ted                                  | y          |
        | John                                 | n          |
        | Jack                                 | n          |
    When the list of active beacons is requested
    Then the number of returned beacons should be 1