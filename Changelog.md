
SimpleCMS Changelog
=========

Version 0.4
--
**2020/10/20**

**SPA:**

Added:
 - Created Vue SPA project
 - Added NavBar, SearchBar, and Content template components
 - Pinned content state, mutations, and actions in the store
 - Pinned content toolbar to allow quick access to pinned content
 - Settings toolbar and relevant state, mutations and actions in store for toggling toolbar
 - Search bar functionality
 - Edit content modal including preview of how the content will be displayed
 - Search Filter Options component to allow search filtering
 - Currently Open toolbar component which allows users to keep different contents open and switch between them

Removed:
 - Settings route
 - Home and Settings route links in NavBar component


**API:**

Changed:
 - Renamed all 'name' fields to 'title' to avoid any ambiguity
 - Moved ContentDetailVM from ...Queries.GetContentDetail to ...Queries.Common (to be shared amongst content queries)

Removed:
 - ContentDTO (Usage replaced by shared ContentDetailVM)

Version 0.3
---
**2020/05/29**

Added:
 - Custom exceptions for validation errors, bad requests and deletion failures
 - Custom exception handler middleware
 - Application.UnitTests xUnit project
 - Wrote tests for Category, Contents and Topics commands & queries
 - Implemented NSwag open API documentation

Changed:
 - Renamed EditorClient to API

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

