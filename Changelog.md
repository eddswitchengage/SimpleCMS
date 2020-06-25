
SimpleCMS Changelog
=========


<br />

Version 0.2
---
**2020/05/25**

Added:
 - Db configurations for Category, Topic, and Content entities
 - Base design time factory for db contexts
 - SimpleDbContext factory implementation
 - Dependency injection class for Application library
 - Mediatr implemented
 - Implemented fluent validation
 - Sample data seeding command (runs during program startup)
 - CRUD operations for Category, Topic, and Content entities
 - EditorClient controllers for Category, Topic, and Content operations
 - Implemented Northwind trader AutoMapper configuration:<br />
	[IMapFrom](https://github.com/jasontaylordev/NorthwindTraders/blob/master/Src/Application/Common/Mappings/IMapFrom.cs) interface that DTOs/VMs inherit from.
	Mapping profile class that uses Northwind's [ApplyMappingsFromAssembly](https://github.com/jasontaylordev/NorthwindTraders/blob/master/Src/Application/Common/Mappings/MappingProfile.cs) code.

<br />

Version 0.1
---
**2020/05/20**

Created repo and made some basic implementations.

Added:
- Empty editor client project
- EF core packages and implemented db context
- AuditableEntity class to represent entities whose changes should be tracked
- Topic, Category, and Content entities 
- DependencyInjection class in both Application and Domain projects. This class is used to configure a class library's service injection options.

