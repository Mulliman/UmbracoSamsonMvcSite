Umbraco-Samson
==============

Named after the Mythological character that was famed being strong, Samson gives the ability to have strongly typed content and media services in Umbraco. This is a base site for building on Samson.

## Architecture

This is a simple solution including all the basic code for hooking up the Samson components with an Umbraco installation. This implementation follows the architecture shown below, though slightly more simplistic.

![alt text](http://sam-mullins.com/media/1009/samsonmvcdiagram.jpg "Recommended Architecture")

### Domain Model Project (Samson.Model)
In this solution the domain model project actually contains the concrete model layer, the abstract model layer and the domain model layer. As this is just a demo / starter project I didn't want to go too crazy with solution size at the start.

Concrete Model => Samson.Model.DocumentTypes & Samson.Model.MediaTypes

Abstract Model => Samson.Model.DocumentTypes.Interfaces

Domain Model => Samson.Model.Repositories & Samson.Model.Services

### Website Project (Samson.Website)
In the website project it is possible to see how we use MVC in this architecture. Some choose to use route hijacking to use MVC in a more pure state, however I like to keep the component nature of Umbraco intact; in this architecture a macro partial is used only to call an action on a controller. The benefits of this include using Umbraco caching on macros and being able to use the Macro Container data type to create configurable pages.