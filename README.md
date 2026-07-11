My Current Architecture 

    [Layers]
API <=references=> Infrastructure, both references ==> Application ==> Domain

* Only the Infrastructure and Domain has the Implementation.

* Domain has no interface, because its service is stateless, 
i've directly injected it to the application layer service.

* Application have Interface (IRepository) for the Implementation of the Infrastructure.

* The Api layer Registers the Application and Infrastructure all together via IServiceCollection extension.
