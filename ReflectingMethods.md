The complete example in  :
http://asp3tojson.googlecode.com/files/asp3tojson_0.0.2.0_samples.zip


## How to Reflect your Methods (Simple version) ##

Build a page with your class (person.class.asp for example)


<sub>person.class.asp</sub> (Create your methods like a commom asp3 class)
```
<%
Class Person
    Public function one()
        Response.Write("Nothing returns here, a response.write method from server only !")
    End Function

    Public function two(aValue)
        two = ucase(aValue)
    End Function

    
    Public function sayHello(strName, strLastName)
        sayHello = "Hello, " & strName &" "& strLastName & "."
    End Function
    ...
```
Inside in this same class, add a Method named **reflectMethod()** .
Don´t forget declare this method as Public .
```
    Public function reflectMethod()
        set reflectMethod = Server.CreateObject("Scripting.Dictionary")
        with reflectMethod
            .Add "function one", ""
            .Add "function two", "name"
            .Add "function sayHello", "name,lastName"
        End with
    End Function

End Class
```
Now add this Conditional. Inside of this conditional, add a method named **writeMethodsToJson**, the path must be placed and Type placed with **Quotes (")** .
```
If request.QueryString("m") = "" Then
    path = "./person.class.asp"
    writeMethodsToJson "Person", path
End If
%>
```
Finally, place the include file asp3tojson\_reflector.asp
```
<!-- #include file="asp3tojson_reflector.asp" -->

```
The result is a page with ASP3 methods parsed and ready to call via javascript
in the client side like this :

```
<script>
var _Person = {
one : function(method){
       var url = './person.class.asp?m=one&o=Person';
       a = new objectAjax.Ajax(url,{update:"", onComplete:
       function(_text,_xml)
       {
          method(_text);
       }
       });
       a.post();
},
two : function(method,name){
       var url = './person.class.asp?m=two&o=Person';
       a = new objectAjax.Ajax(url,{update:"", onComplete:
       function(_text,_xml)
       {
          method(_text);
       }
       });
       a.post('_param= "' + name + '" ');
},
sayHello : function(method,name,lastName){
       var url = './person.class.asp?m=sayHello&o=Person';
       a = new objectAjax.Ajax(url,{update:"", onComplete:
       function(_text,_xml)
       {
          method(_text);
       }
       });
       a.post('_param= "' + name + '" &_param= "' + lastName + '" ');
}
};
</script>
```


## Running now and JavaScript Usage ##
Inside of your ASP3 code

<sub>index.asp</sub>

```
<!--#include file="asp3tojson.asp"-->

<!--#include file="person.class.asp"-->

<html>
```

This javascript function is the Ajax callback
```
<script>
function test(msgCallback)
{
   alert(msgCallback);
}

function otherTest(msgCallback)
{
   alert(msgCallback);
}

function hello(msgCallback)
{
   alert(msgCallback);
}
</script>
```

The library writes the Class like this : `_Person` (`_+Type`)
The first param is the method that call
```
<body>

<input type="button" value="Click on me" onclick="new _Person.one(test)" />
<br />

<input type="button" value="Click on me" onclick="new _Person.two(otherTest, 'a string was lowercase, now is uppercase')" />
<br />

<input type="button" value="Click on me" onclick="new _Person.sayHello(hello, 'John' , 'Travolta')" />
<br />


</body>

</html>
```



## In Full code now ! ##

<sub>person.class.asp</sub>
```
<%
Class Person
    Public function one()
        Response.Write("Nothing returns here, a response.write method from server only !")
    End Function

    Public function two(aValue)
        two = ucase(aValue)
    End Function

    
    Public function sayHello(strName, strLastName)
        sayHello = "Hello, " & strName &" "& strLastName & "."
    End Function

    Public function reflectMethod()
        set reflectMethod = Server.CreateObject("Scripting.Dictionary")
        with reflectMethod
            .Add "function one", ""
            .Add "function two", "name"
            .Add "function sayHello", "name,lastName"
        End with
    End Function
End Class

If request.QueryString("m") = "" Then
    path = "./person.class.asp"
    writeMethodsToJson "Person", path
End If
%>
<!-- #include file="asp3tojson_reflector.asp" -->
```


<sub>index.asp</sub>
```
<!--#include file="asp3tojson.asp"-->

<!--#include file="person.class.asp"-->

<html>

<script>
function test(msgCallback)
{
   alert(msgCallback);
}

function otherTest(msgCallback)
{
   alert(msgCallback);
}

function hello(msgCallback)
{
   alert(msgCallback);
}
</script>

<body>

<input type="button" value="Click on me" onclick="new _Person.one(test)" />
<br />

<input type="button" value="Click on me" onclick="new _Person.two(otherTest, 'a string was lowercase, now is uppercase')" />
<br />

<input type="button" value="Click on me" onclick="new _Person.sayHello(hello, 'John' , 'Travolta')" />
<br />


</body>

</html>
```





## Enjoy ! :) ##