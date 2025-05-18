using System;
using Firebase.Database;
using System.Collections;
using UnityEngine;
using Unity.Mathematics;


public class DatabaseHandler : MonoBehaviour
{
    private string userID;
    private DatabaseReference reference;

    private void Awake()
    {
        userID = SystemInfo.deviceUniqueIdentifier;
    }


    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;


        Invoke(nameof(GetUserInfo), 1f);
    }

    public void LoadInfo()
    {
        Invoke(nameof(GetUserInfo), 1f);
    }
    public void SaveInfo(PlayerData playerData)
    {
        CreateUser(playerData);
    }
    private void CreateUser(PlayerData playerData)
    {
        User newUser = new User(playerData.Name, playerData.LastName, 99999999, playerData.lastScore); //User newUser = new User("Pedro", "Piedrito");
        string json = JsonUtility.ToJson(newUser);


        reference.Child("users").Child(userID).SetRawJsonValueAsync(json);
    }


    private IEnumerator GetFirstName(Action<string> onCallBack)
    {
        var userNameData = reference.Child("users").Child(userID).Child("firstName").GetValueAsync();


        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);


        if (userNameData != null)
        {
            DataSnapshot snapshot = userNameData.Result;
            onCallBack?.Invoke(snapshot.Value.ToString());
        }
    }


    private IEnumerator GetLastName(Action<string> onCallBack)
    {
        var userNameData = reference.Child("users").Child(userID).Child("lastName").GetValueAsync();


        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);


        if (userNameData != null)
        {
            DataSnapshot snapshot = userNameData.Result;
            onCallBack?.Invoke(snapshot.Value.ToString());
        }
    }


    private IEnumerator GetCodeID(Action<int> onCallBack)
    {
        var userNameData = reference.Child("users").Child(userID).Child(nameof(User.codeID)).GetValueAsync();


        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);


        if (userNameData != null)
        {
            DataSnapshot snapshot = userNameData.Result;
            //(int) -> Casting
            //int.Parse -> Parsing
            //https://teamtreehouse.com/community/when-should-i-use-int-and-intparse-whats-the-difference
            onCallBack?.Invoke(int.Parse(snapshot.Value.ToString()));
        }
    }


    public void GetUserInfo()
    {
        StartCoroutine(GetFirstName(PrintData));
        StartCoroutine(GetLastName(PrintData));
        StartCoroutine(GetCodeID(PrintData));
    }


    private void PrintData(string name)
    {
        Debug.Log(name);
    }


    private void PrintData(int code)
    {
        Debug.Log(code);
    }
}



public class User
{
    public string firstName;
    public string lastName;
    public int codeID;
    public int lastScore;

    public User(string firstName, string lastName, int _codeID, int lastScore)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.codeID = _codeID;
        this.lastScore = lastScore;
    }
}