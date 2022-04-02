using Optional;

var myFoo = Option<string>.None;
var myBar = Option<string>.Some("hello world!");

Action<string> forString = (s) => Console.WriteLine(s);

myFoo.Then(forString);
myBar.Then(forString);

myFoo.Then((s) => myBar.Then((s2) => 
{
    Console.WriteLine("Both have values");
}));

    var combined = myFoo.And(myFoo);
    var anotherCombo = combined.And(myBar);

    anotherCombo.Then((tuple) =>
    {
        var s1 = tuple.Left.Left;
        var s2 = tuple.Left.Right;
        var s3 = tuple.Right;
    });


