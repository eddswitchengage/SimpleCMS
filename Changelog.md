
SimpleCMS Changelog
=========

Version 0.4.4
--
**2020/11/03**

**SPA:**

Added:
 - Integrated upsert content endpoint to API module
 - Finished implementing the logic for EditContentModal and plugged it into the API module
 - Added ChangesMadeTooltip to display when the user has made changes to a local content item
 - The user is now prompted if they attempt to close an item with unsaved changes

**API:**

Added:
 - Tags field to upsert content command


Version 0.4.3
--
**2020/10/27**

**SPA:**

Added:
 - Loading stage before app starts with an overlay that displays whilst the app performs start-up initialisation
 - SimpleAPIClient interface and APIQueryCollection interface
 - API.ts client that integrates the SimpleCMS API
 - LoadingOverlay and child ActivityIndicator components
 - Implementation of contents/getall route
 - Implementation of categories/getall route


**API:**

Added:
 - Tags field to content entity and view model classes
 - PaginatedList class (Application class library)
 - Added several fields to GetContentsListQuery class to facilitate search filtering
 - Added pagination to GetContentsListQueryHandler
 - Added new parameters to Content GetAll route



Version 0.4.2
--
**2020/10/22**

**SPA:**

Added:
 - Added functionality to allow editing of topic and category titles within the EditHierarchyModal

Version 0.4.1
--
**2020/10/21**

**SPA:**

Added:
 - Edit category & topic modal (EditHierarchyModal). Allows users to create and manage both categories and topics.
 - Added HierarchyItemRow component which is used to represent topic and category items.
 - HierarchyItemRowList component to display multiple HierarchyItemRow components.
 - Added EditHierarchyButton to NavBar to allow the opening of the EditHierarchyModal.
 - SelectTopicDropdown displays a list of topics categorised into option groups by their parent category.
 - Implemented SelectTopicDropdown component in EditContentModal to allow a content's parent topic to be changed.


**API:**

Changed:
 - Moved TopicDetailVM to ...Topics.Queries.Common (to be shared among topic queries)
 - Moved CategoryDetailVM to ...Categories.Queries.Common (to be shared among topic queries)
 - Renamed both TopicContentDTO and CategoryTopicDTO to TopicContentVM and CategoryTopicVM, respectively. (Classes contained behaviours and therefore should be VM).
 - TopicDetailVM no longer contains associated Content list. Content should be retrieved from the Content endpoints using search filters (e.g. topicId = 1 for all contents under topic 1)
 - ContentDetailVM now contains LastModified and Created date time values.

Removed:
 - TopicDTO (usage replaced by TopicDetailVM)
 - CategoryDTO (usage replaced by CategoryDetailVM)
 - ContentTopicDTO


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

