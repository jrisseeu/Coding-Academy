using System;

namespace Playground {
    class Program {
        static void Main(string[] args) {
            Animal myAnimal = new Animal();  // Create a Animal object
            Animal myPig = new Pig();  // Create a Pig object
            Animal myDog = new Dog();  // Create a Dog object

            myAnimal.makesSound();
            myPig.makesSound();
            myDog.makesSound();
        }
    }
}
