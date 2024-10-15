# Day 1 Review

Please address your current understanding of the following topics we covered (or began to cover) in class today. Your thoughts about these can and should be revised throughout the training (and your career!) as your understanding grows.

I am *not* looking for super "technical" stuff here. Just your ability to express and convey in your way your understanding of these things.

## 1. Git

We created a git repository on our VMs and added some existing code and committed it. We then used the `gh` cli tool to push that code to Github. 

- Say a few words about why *we* are using source control in this class?
- Say a few words about how source control is used by teams of developers working on the same code base.
- What is meant when we say a copy of the repository is the "origin"? (That's our copy on github).
- Why do we create commits locally?
- Why do we push those commits to Github?

---
In class we are using Git so that we can have a "backup" of our code living off the virtual machines in case our VM dies, and so that we can have a copy of our
code after the class is over.

Teams of developers use source control to have many developers collaborate on the same code base. Parallel versions of the code base are "cloned" on
each developers machine and changes are periodically integrated into the shared copy ("origin") version of the code base. There are many strategies
for keeping the code base integrated, including branching strategies and trunk-based development.

"Origin" is a conventional term to "knight" or "bless" a single copy (clone) of a repository as the *one* that is authoritative. Git has no concept of this
inherent in it's design. It's all anarchy, hippy free-love. Every copy of the repository is just as good as another, but when humans work, we need one to be 
sort of "in charge".

We create commits locally in preparation for merging our code into the origin. Local commits give us lots of things - like an "undo" history should we need
to back out of a coding decision, but also serve as documentation for the code changes we've made. 

The commits are pushed to github to integrate them into the origin copy so other developers have access to our code. Some repositories require you to
create a special request to the owners of the repository called a "pull request" that gives the repository owners a chance to review your commits before
integrating them into the origin's main branch. 

### Extra Credit

What were the steps, as detailed as you like, that we took to create our repository and push it to Github.

What are some other ways you might do the same thing?

---
We created a repository in our classroom directory with the `git init` command, added the existing code to the "staged" section of git with `git add .`, and then 
created a local commit `git commit -m "Commit Message"`. Use used the Github CLI (Command Line Interface) to create a repository under our Github accounts 
and push our commits to that repository.  (`gh repo create`).


## 2. Services

We began a project in Visual Studio to create a service. What is meant by the term "Service" in software development?

Our service exposes an *interface* that other applications can use to drive our service (make it do stuff). This is an
"Application Programming Interface". How does an API differ from a "User Interface" (UI)? How are they similiar?

What are some benefits of exposing a service's interface using the HTTP Protocol?

We "tested" our API three different ways. 

1. Manually using SwaggerUI
2. Manually using the `.http` file functionality in Visual Studio
3. Automated using an xUnit test project.

Which is the *right* way to do it? Why give preference to automated tests? 

---
APIs are intended to be used by other software. They allow us to create software by aggregating (gluing together) various APIs to accomplish tasks.
One way that APIs differ from UIs is that a human user interacting with a UI can accomodate changes in the UI easier than software can. For example,
if you add a new form field in a UI, users can simply provide a new value at the time of use, or if you relabel a button from 'Submit' to 'Add Todo',
users will not be typically confused or impeded from their task. However changes like that would require the consuming software using an API (called the `upstream`)
to be rewritten and redeployed to accomodate most changes. 

We use the HTTP protocol as a *reasonable default*. HTTP is well understood, easy to observe and instrument, provides ambient functionality like caching,
authentication and authorization, and has tremendous *reach*. HTTP is implemented as a protocol in all major (and most minor) programming libraries.

HTTP is ubiquitous - it's everywhere. That means that developers using an HTTP-based API probably already have a lot of experience using HTTP APIs. Because
HTTP is normative - it has strong opinions about how application functionality should be expressed - developers have a consistent way of interacting and
thinking about external APIs.

Manual testing (using tools like Postman, Bruno, using `.http` files, etc.) allows the developer to explore, APIs (either their own or others). For example, 
we don't typically write automated tests for APIs we don't own, but we may want to use a tool like SwaggerUI or Postman to explore the funcationality of an API.
These kind of manual tools are also relatively easy ways for us to think about the design of our API as we build it.

Automated tests are needed at least in part because as humans we sort of suck at doing repetitive things over and over again consistently. It would be too easy
to make a change to your code today that your "tested" manually yesterday which might "break" because of the code you added today. In this way automated
tests can be a sort of "safety net" to make sure new additions don't break existing functionality. This is imperative after the code is released and any consuming
applications are depending on our API. 

Automated tests also are *great* documentation about the capabilities of your system and you and your teams understanding of the business requirements.

### Extra Credit

Have you used any existing HTTP APIs in other projects?

Have you created any other HTTP APIs in your own work or studies?

