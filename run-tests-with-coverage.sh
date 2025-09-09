#!/bin/bash

# Run tests with code coverage
echo "Running tests with code coverage..."
dotnet test --collect:"XPlat Code Coverage" --results-directory ./TestResults

# Find the coverage file
COVERAGE_FILE=$(find ./TestResults -name "coverage.cobertura.xml" | head -1)

if [ -f "$COVERAGE_FILE" ]; then
    echo "Coverage file found: $COVERAGE_FILE"
    
    # Generate HTML report
    echo "Generating HTML coverage report..."
    reportgenerator -reports:"$COVERAGE_FILE" -targetdir:"./TestResults/CoverageReport" -reporttypes:Html
    
    echo "Coverage report generated at: ./TestResults/CoverageReport/index.html"
    
    # Display basic coverage statistics
    echo ""
    echo "=== Coverage Summary ==="
    reportgenerator -reports:"$COVERAGE_FILE" -targetdir:"./TestResults/CoverageReport" -reporttypes:TextSummary
    cat ./TestResults/CoverageReport/Summary.txt
else
    echo "Coverage file not found!"
    exit 1
fi