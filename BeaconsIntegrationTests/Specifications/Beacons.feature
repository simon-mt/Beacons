Feature: Beacons API Tests

  Scenario: Single beacon added
    Given there are no saved beacons
    When the following beacons are added
        | Name                                 |
        | Farmer Ted's favourite tractor       |
    Then the number of saved beacons should be 1


  Scenario: Search beacon by name
    Given the following beacons exists
        | Name                                 |
        | Ted                                  |
        | John                                 |
        | Jack                                 |
    When beacon John is requested
    then the number of returned beacons should be 1

Scenario: Search beacon by name
    Given the following beacons exists
        | Name                                 |
        | Ted                                  |
        | John                                 |
        | Jack                                 |
    When beacon Fred is requested
    then the number of returned beacons should be 0

Scenario: Search beacon by name
    Given the following beacons exists
        | Name                                 |
        | Ted                                  |
        | John                                 |
        | Jack                                 |
    When beacon "J" is requested
    then the number of returned beacons should be 2

Scenario: Search beacon by active
    Given the following beacons exists
        | Name                                 | Active
        | Ted                                  | y
        | John                                 | n
        | Jack                                 | n
    When the list of active beacons is requested
    then the number of returned beacons should be 1