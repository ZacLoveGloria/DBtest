using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class UserLogin : MonoBehaviour
{

    public string loginname;
    public string loginpassword;

    // Start is called before the first frame update
    void Start()
    {
        if (loginname != "")
        {
            StartCoroutine(Login(loginname, loginpassword));
        }
    }

    IEnumerator Login(string name, string pass)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginname", name);
        form.AddField("loginpass", pass);


        UnityWebRequest www = UnityWebRequest.Post("http://localhost/db_test/userlogin.php", form);
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
