
# SimpleCMS
*SimpleCMS* is a .Net Core project I'm developing to improve my developer skill-set.
The project is a generic CMS suite and includes built-in authorisation/authentication along with a configurable web-client.

Ultimately I'm developing this as a learning tool so hopefully it'll help some folk out. 

You can check out the changelog [here](https://github.com/eddswitchengage/SimpleCMS/blob/master/Changelog.md).

<br />

### Structure
The project structure follows a clean architecture approach and aims to separate/decouple wherever possible. You can find out more about clean architecture from Jason Taylor [here](https://www.youtube.com/watch?v=_lwCVE_XgqI).

The handling of requests follows the [CQRS](https://martinfowler.com/bliki/CQRS.html#:~:text=CQRS%20stands%20for%20Command%20Query,you%20use%20to%20read%20information.) pattern and is implemented with the [Mediatr](https://github.com/jbogard/MediatR) package. 