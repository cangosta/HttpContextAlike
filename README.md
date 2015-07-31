# HttpContextAlike
This library creates a .net Web Api Handler that creates a System.Web.HTTPContext-alike class. This is useful in self-hosted OWIN(Katana) applications IIS or applications on the Helios host.

## Getting started

Configure your ASP.NET Web API application with this library by putting the following code in your WebApiConfig.Register() method:

    config.MessageHandlers.Add(new HttpContextHandler());
    
Access your user variable everywhere in your code:

    HttpContext.Current.User
    
or your Request variable:

    HttpContext.Current.Request

## Future work
* Create an OWIN-middleware to move the creation of the HttpContext at the OWIN level.
* Write unit tests

## License
Released under the [MIT License](http://www.opensource.org/licenses/MIT).
