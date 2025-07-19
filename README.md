# What is this?

A project seed for a C# dotnet API ("PaylocityBenefitsCalculator").  It is meant to get you started on the Paylocity BackEnd Coding Challenge by taking some initial setup decisions away.

The goal is to respect your time, avoid live coding, and get a sense for how you work.

# Coding Challenge

**Show us how you work.**

Each of our Paylocity product teams operates like a small startup, empowered to deliver business value in
whatever way they see fit. Because our teams are close knit and fast moving it is imperative that you are able
to work collaboratively with your fellow developers. 

This coding challenge is designed to allow you to demonstrate your abilities and discuss your approach to
design and implementation with your potential colleagues. You are free to use whatever technologies you
prefer but please be prepared to discuss the choices you’ve made. We encourage you to focus on creating a
logical and functional solution rather than one that is completely polished and ready for production.

The challenge can be used as a canvas to capture your strengths in addition to reflecting your overall coding
standards and approach. There’s no right or wrong answer.  It’s more about how you think through the
problem. We’re looking to see your skills in all three tiers so the solution can be used as a conversation piece
to show our teams your abilities across the board.

Requirements will be given separately.


Notes form candidate:
I'm not entirely sure if one of the tasks was to hook it up to a db and use that for persistency or not, but given the requirements I got, it doesn't seem like it. There are no CRUD operations. So my best bet is that it is not the goal of the exercice. 
Changes I have made in the structure:
- I have moved the ApiResponseDto from model directory to Dto directory, it is a Dto and not a persistence model, so this is to prevent confusion.
- I have added a mapper library just to make it simpler for me to work (no manual mapping between fields necessary)
- I have crated "InMemory data store" just moved the example definition of employee list into it and hooked the api to that

Calculations:
I'm not sure if I understood it correctly, beacuase based on the rules you've provided, the more dependents (kids) you have, the lower your net pay will be. That is strange concept and I think in real life it works the other way round. But whatever. And maybe I didn't understood correctly.
It would make sense if these were tax deductables, but it is not defined like that, so my best bet is that these costs are reducing gross salary... and so then netpay = grosspay - deductions
