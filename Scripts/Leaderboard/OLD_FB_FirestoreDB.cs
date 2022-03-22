using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Firebase.Firestore;
using Firebase.Extensions;

public class OLD_FB_FirestoreDB : MonoBehaviour
{
    //FirebaseFirestore db;
    public InputField inputName, inputData;
    public Text Leaderboard;

    string Name, Data;

    // Start is called before the first frame update
    void Start()
    {
        //FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeaderboardSubmit()
    {

        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        Debug.Log(inputName.text + " / " + inputData.text);
        Name = inputName.text.ToString();
        DocumentReference docRef = db.Collection("Testing").Document(inputName.text);
        Dictionary<string, object> user = new Dictionary<string, object>
        {
                { "pseudo", Name },
                { "HighScore", int.Parse(inputData.text) }
        };
        docRef.SetAsync(user).ContinueWithOnMainThread(task => {
                Debug.Log("Added data to Leaderboard.");
        });
    }

    public void LeaderboardUpdate()
    {
        Leaderboard.text = "Leaderboard : "+"\n";
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        CollectionReference usersRef = db.Collection("Testing");
        Query query = usersRef.OrderByDescending("HighScore").Limit(10);
        
        query.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            QuerySnapshot snapshot = task.Result;
            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                Dictionary<string, object> user = document.ToDictionary();
                Leaderboard.text += "\n" + user["pseudo"] + ": " + user["HighScore"] ;
                
                // foreach (KeyValuePair<string, object> pair in user)
                // {
                //     Debug.Log(pair.Key + " " + pair.Value);
                // }
            }
        });
    }
}
