# Blazor 8 with Roles and SignalR

This code base is by no means best practice coding.
It demonstrates two things.
Changing the template to include role based Authorization
How to send Signalr messages to a userId from an Injected service on the server.

The template also includes a seeded user with two roles.
bob@bob.com password: Pass123$

Items of interest:
Program.cs
PersistingRevalidatingAuthenticationStateProvider.cs
PersistentAuthenticationStateProvider.cs

NotificationHub.cs
SomeControllerc.cs