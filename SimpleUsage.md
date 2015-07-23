## How to build ##
```
    Class Person
        public name
        public age
        public anotherObject


        'auto reflect the object as dictionary'
        public function reflect()
        set reflect = server.createObject("scripting.dictionary")
        with reflect
            .add "name"          , name
            .add "age"           , age
            .add "anotherObject" , anotherObject 'You can create other objects, must ever use the reflect function in your code'
        end with
        End function
    End Class

    Class anotherObject
        public id
        public objectName

        'auto reflect the object as dictionary'
        public function reflect()
        set reflect = server.createObject("scripting.dictionary")
        with reflect
            .add "id"          , id
            .add "objectName"  , objectName
        end with
        End function
    End Class
```


## Usage ##
Inside of your ASP3 code

```
<!--#include file="asp3tojson.asp"-->

<%
    Set obj = new anotherObject
    obj.id = 1
    obj.objectName = "My test object"

    Set p = new Person
    p.name = "Alice"
    p.age = 20
    set p.anotherObject = obj
%>
<!-- Parsing to JSON now -->
<%=(new JSON).toJSON(p)%>
```

## Output ##
`{"name":"Alice","age":20,"anotherObject":[{"id":1,"objectName":"My test object"}]}`

_**Obs : The objects are parsed like array of objects .**_


## JavaScript Usage ##
```
<script>
obj = {"name":"Alice","age":20,"anotherObject":[{"id":1,"objectName":"My test object"}]};

var name = obj.name;
var age = obj.age;

var idObject = obj.anotherObject[0].id;
var objectName = obj.anotherObject[0].objectName;
</script>
```