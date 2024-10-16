# Day 2 Review

## Assemblies and Visual Studio
What is your understanding of what is meant by the term "Assembly" in .NET?

----
*An assembly is the unit of compilation in .NET. It's what you get when you build a .NET Project. It contains the IL code, and the metadata about the types in that assembly*

What is the relationship between an assembly and visual studio Project?

---
*A project in Visual Studio has a 1-1 relationship with an assembly.*

What is a solution in Visual Studio?
---
*A solution is a workspace for developing one or more projects simultaeously in Visual Studio*

What are the two types of Assemblies discussed in class?

---
*They are executables or class libraries*

What is the thing that makes an assembly "Runnable" - what is the *entry* point of an Assembly?

---
*An executable assembly has an entry point where the Just-In-Time compiler begins the process of running your code. In C# that is a `static void Main(string[] args)` method.*

## What is the "Common Language Runtime (CLR)" 
---
*A Runtime is a program that runs other programs. In .NET the Common Language Runtime runs assemblies compiled to the CIL (Common Intermediate Language). There are distrubtions of the CLR for various operating systems, include Mac, Windows, and various distributions of Linux*

## What is "Dotnet Core"? What's that all about?

---
*A subset of all of .NET that is able to run cross-platform*

## What is the Common Type System (CTS)?
*The base types of .NET - either value types (structs), or reference types (classes)*

## What are the "First Class Citizens" of .NET?

---
*A value type or a reference type. A name (variable) can only refer to an instance of a struct or a class*

