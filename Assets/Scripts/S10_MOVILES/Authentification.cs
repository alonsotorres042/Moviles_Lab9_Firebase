using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase;
using System.Threading.Tasks;
using UnityEngine.Events;
using Firebase.Firestore;
using UnityEngine.Rendering;

public class Authentification : MonoBehaviour
{
    [SerializeField] private string email;
    [SerializeField] private string password;

    [Header("Bool Actions")]
    [SerializeField] private bool signUp = false;
    [SerializeField] private bool signIn = false;

    private FirebaseAuth _authReference;

    public UnityEvent OnLogInSuccesful = new UnityEvent();
    public UnityEvent OnLogOutSuccesful = new UnityEvent();

    private void Awake()
    {
        _authReference = FirebaseAuth.GetAuth(FirebaseApp.DefaultInstance);
    }

    public void LogIn()
    {
        StartCoroutine(SignInWithEmail(email, password));
    }
    public void signUP()
    {
        StartCoroutine(RegisterUser(email, password));

    }
    public void recoverPassword()
    {
        StartCoroutine(RecoverPassword(email));
    }
    private IEnumerator RecoverPassword(string email)
    {
        Debug.Log("Registering");
        var registerTask = _authReference.SendPasswordResetEmailAsync(email);
        yield return new WaitUntil(() => registerTask.IsCompleted);

        if (registerTask.Exception != null)
        {
            Debug.LogWarning($"Failed to register task with {registerTask.Exception}");
        }
        else
        {
            Debug.Log("contra recuperada");
            //Debug.Log($"Succesfully registered user {registerTask.email}");
        }
    }
    private IEnumerator RegisterUser(string email, string password)
    {
        Debug.Log("Registering");
        var registerTask = _authReference.CreateUserWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(() => registerTask.IsCompleted);

        if(registerTask.Exception != null)
        {
            Debug.LogWarning($"Failed to register task with {registerTask.Exception}");
        }
        else
        {
            Debug.Log($"Succesfully registered user {registerTask.Result.User.Email}");
        }
    }

    private IEnumerator SignInWithEmail(string email, string password)
    {
        Debug.Log("Loggin In");

        var loginTask = _authReference.SignInWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(() => loginTask.IsCompleted);

        if (loginTask.Exception != null)
        {
            Debug.LogWarning($"Login failed with {loginTask.Exception}");
        }
        else
        {
            Debug.Log($"Login succeeded with {loginTask.Result.User.Email}");
            OnLogInSuccesful?.Invoke();
        }
    }

    public void LogOut()
    {
        FirebaseAuth.DefaultInstance.SignOut();
        OnLogOutSuccesful?.Invoke();
    }
}
