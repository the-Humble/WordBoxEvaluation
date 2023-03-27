using UnityEngine;

namespace Model
{
    [System.Serializable]
    public class PeopleModel
    {
        public PersonModel[] results;
    }
    
    [System.Serializable]
    public class PersonModel
    {
        public string gender;
        public Name name;
        public Location location;
        public string email;
        public DOB dob;
        public Picture picture;
    }

    [System.Serializable]
    public class Name
    {
        public string title;
        public string first;
        public string last;
    }

    [System.Serializable]
    public class Location
    {
        public string city;
    }

    [System.Serializable]
    public class DOB
    {
        public int age;
    }

    [System.Serializable]
    public class Picture
    {
        public string large;
        public string medium;
        public string thumbnail;
    }
    
    
}
