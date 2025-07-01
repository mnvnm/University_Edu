using UnityEngine;

public class Animal
{
    public string name = "";
    public int age = 0;
    public string sound = "";

    public void PlaySound()
    {
        Debug.Log(name + " makes sound: " + sound);
    }

    public void SetName(string newName)
    {
        name = newName;
    }

    public void SetAge(int newAge)
    {
        age = newAge;
    }

    public void SetSound(string newSound)
    {
        sound = newSound;
    }
}
