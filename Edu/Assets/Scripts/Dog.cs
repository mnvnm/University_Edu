using UnityEngine;

public class Dog : Animal
{
    void Start()
    {
        SetName("Dog");
        SetAge(5);
        SetSound("Woof");

        PlaySound();
    }
}
