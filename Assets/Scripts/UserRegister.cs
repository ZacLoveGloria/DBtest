using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UserRegister : MonoBehaviour
{
    public string registerName;
    public string registerPass;
    public string registerEmail;

    // Start is called before the first frame update
    void Start()
    {
        if (registerName != "")
        {
            StartCoroutine(Register(registerName, registerPass, registerEmail));
        }
    }

    IEnumerator Register(string name, string pass, string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("registername", name);
        form.AddField("registerpass", pass);
        form.AddField("registeremail", email);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/db_test/userregister.php", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
        }
    }
}
