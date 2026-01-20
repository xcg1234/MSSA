// Pet should be abstract as we don't want to create instances of Pet directly
public abstract class Pet{
    public string FirstName { get; set; }
    public string Color { get; set; }
    public abstract void Speak();
}

class Dog : Pet{
    
    public override void Speak() => Console.WriteLine("Woof!");
}

class Hound : Dog{
    public override void Speak() => Console.WriteLine("Woof! Woof!");
}

class Terrier : Dog{
    public override void Speak() => Console.WriteLine("Yap! Yap!");
}

class Working : Pet{
    public override void Speak() => Console.WriteLine("Grrr!");
}

class Beagle : Hound{
    public override void Speak() => Console.WriteLine("Aroo! Aroo!");
}

class WelshTerrier : Terrier{
    public override void Speak() => Console.WriteLine("Yip! Yip!");
}

class Boxer: Working{
    public override void Speak() => Console.WriteLine("Woof! Grrr!");
}
