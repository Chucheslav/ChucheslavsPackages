	General description.

You can create scriptable objects that house variables of any type and scriptable events that transmit an object of any type. Also, runtime sets and observable lists.
Almost all base classes are generic and extendable.
There is a decent system for managing and storing preferences as Scriptable objects.


	Extending and usage.
	
You will find a new subfolder on top of Create menu named SOA, use it to create all premade types.
Simple event with no data is a separate class, erything else are just chains of generics.
Base is GenericEvent<T>, this one can only transmit data and doesn't store it.
GenericVariable<T> inherits from  GenericEvent<T> and will also store last transmitted value.
You can be Subcribe and Unsubscribe to both events and variables, with a usual Action of appropriate type. With variables you can also Link which will call the Action with the value stored immeddiately.

Making your own type:
MyEvent<MyType> : GenericEvent<MyType> {}
MyVariable<MyType> : GenericVariable<MyType>{}
MySet : RuntimeSet<MyType> { }

then decorate with appropriate attributes to add to Create menu.

Adding editors:
[CustomEditor(typeof(MyVariable))]
public class MyVariableEditor: GenericVariableEditor<MyType>{}

do remember to store those in an Editor folder.


	Prefs.
	
Managind preferences as scriptable objects gretly reduces headache of precise string management, and allows for some extra flexibility.

Five types can be stored into prefs - Bool, Int, Float, Enum, String
You will need to create a pref container and prefs system to fully utilize features, from a subfolder Prefs under SOA folder in Create menu. The rest should be more or less self-explanatory.
