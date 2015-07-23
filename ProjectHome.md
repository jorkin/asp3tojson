# RSoft Web - 2009 #
## Under GPL License ##


> This Json Converter parses ASP3 Objects .

> Your Classes must have a function named reflect

> To more examples, see wiki in http://code.google.com/p/asp3tojson/w/list


```
   Class Person
	public name
	public age
	public anotherObject


	'auto reflect the object as dictionary'
	public function reflect()
        set reflect = server.createObject("scripting.dictionary")
        with reflect
            .add "name"		 , name
            .add "age"		 , age
            .add "anotherObject" , anotherObject
	end with
	End function
  End Class
```


## Usage ##
Inside of your ASP3 code

```
<!--#include file="asp3tojson.asp"-->

<%
Set p = new Person
p.name = "Alice"
p.age = 20
p.anotherObject = obj 'You can create other objects, must ever use the reflect function in your code'

%>
<!-- Parsing to JSON now -->
<%=(new JSON).toJSON(p)%>
```


> To more examples, see wiki in http://code.google.com/p/asp3tojson/w/list


---

