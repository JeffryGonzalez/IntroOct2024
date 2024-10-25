# Developer "Modes"

## Systems Programming
- Building general purpose tools, languages, operating systems, databases, network protocols, etc.
- TONS of Unit Tests (low level)
- Performance
- Reliability
- BACKWARD COMPATIBILITY


## Library / Framework
- Library is code your code uses, a Framework is code that uses your code.
- More specific than systems programming, but more generic than application development.
- UI Framework, shared Nuget packages, etc.
- These only* succeed if they are extracted from existing specific solutions (applications). 
    - React is really good, actually. But it is because it started out life as just the code behind Facebook and
      instagram.
- "Premature Abstraction" - thinking you've solved a general problem without enough specific examples.
    - Moist > DRY
- Combination of Unit Tests and Systems Tests (balanced)

## Application Development
- If you knew 100% of what I taught you in this class, you would know about 3% of what you need to be a good application developer.
- Applying technology to provide business-facing solutions.
- Specific
- Primarily Systems Tests (some sprinking of unit tests)

Part of our job as application developers when using libararies or framework is to:
    - Help the people that make those things make them better based on our specific uses.
    - Keep our stuff up to date.



Semantic Versioning of Libraries and Packages
- Just something we came up with, and all versioning is hard, but this is the best we have.
- Semver.org
- 3.23.8
- 3 Major Version
    - At least one breaking change that may or may not impact your application.
- 23 Minor Version
    - Backward Compatible, but new stuff (new methods, new classes, new functionality, whatever)
- 8 Patch Version
    - this contains backward compatible bug fixes.
    - you probably should take this.

