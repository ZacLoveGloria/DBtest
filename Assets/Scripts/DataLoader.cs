using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DataLoader : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {

        using (UnityWebRequest dbtest = UnityWebRequest.Get("http://localhost/db_test/items_data.php"))
        {
            yield return dbtest.SendWebRequest();
            if (dbtest.isNetworkError || dbtest.isHttpError)
            {
                Debug.Log(dbtest.error);
            }
            else
            {
                string itemsdata = dbtest.downloadHandler.text;
                //print(itemsdata);
                string[] itemrows = itemsdata.Split(';');
                GetInfo(itemrows[0], "Name:");
                GetInfo(itemrows[0], "Score:");
            }

        }
        yield return null;
    }


    public void GetInfo(string infodata, string index)
    {

        string info = infodata.Substring(infodata.IndexOf(index)+ index.Length);
        if(info.Contains("|"))
            info = info.Remove(info.IndexOf('|'));
        print(info);
    }


}
