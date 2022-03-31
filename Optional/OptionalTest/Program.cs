using Optional;

var myFoo = Option<string>.None;
var myBar = Option<string>.Some("hello world!");

Action<string> forString = (s) => Console.WriteLine(s);

myFoo.Then(forString);
myBar.Then(forString);

myFoo.Match(
    some: (s) => Console.WriteLine(s),
    none: () => Console.WriteLine("nothing here!")
);
