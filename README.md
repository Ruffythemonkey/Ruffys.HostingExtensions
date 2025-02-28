Extended Hosting.ServiceCollection by giving you the option to automatically include all classes that inherit an interface in the Hosting.ServiceCollection. This can then be retrieved from the ServiceCollection using IEnumarable<TInterface>

📦 **NuGet:** [Ruffys.HostingExtensions](https://www.nuget.org/packages/Ruffys.HostingExtensions)

App
```csharp
using Ruffys.HostingExtensions;
services.AddAllTransientImplementations<IMyInterface>();
```

Class (Primary Constructor)
```csharp
public class MyClass(IEnumerable<IMyInterface> myservices)
```
