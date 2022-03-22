using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Firebase.Firestore;
using Firebase.Extensions;

public class FB_FirestoreDB : MonoBehaviour
{
    public PlayerData playerData;
    //FirebaseFirestore db;
    public Text leaderboardText;
    public InputField NameText;

    int availableID;

    // Start is called before the first frame update
    void Awake()
    {
        if (!PlayerPrefs.HasKey("GuestName"))
        {
            AvailableGuestId();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeaderboardSubmit()
    {

        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        DocumentReference docRef = db.Collection("Leaderboard").Document(playerData.GeneratedName);
        Dictionary<string, object> user = new Dictionary<string, object>
        {
            { "pseudo", playerData.PlayerName },
            { "HighScore", playerData.BestScore }
        };
        docRef.SetAsync(user).ContinueWithOnMainThread(task => {
        Debug.Log("Added data to Leaderboard.");
        });
    }

    public void LeaderboardUpdate()
    {
        int i = 1;
        leaderboardText.text = null;
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        CollectionReference usersRef = db.Collection("Leaderboard");
        Query query = usersRef.OrderByDescending("HighScore").Limit(5);
        query.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            QuerySnapshot snapshot = task.Result;
            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                Dictionary<string, object> user = document.ToDictionary();
                leaderboardText.text +=  "\n" + "[" + i + "] " + user["pseudo"] + ": " + user["HighScore"] ;
                i++;
                // foreach (KeyValuePair<string, object> pair in user)
                // {
                //     Debug.Log(pair.Key + " " + pair.Value);
                // }
            }
        });
    }

    void AvailableGuestId()
    {

        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;

        DocumentReference docRef = db.Collection("GuestID").Document("CurrentNumber");
        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
        DocumentSnapshot snapshot = task.Result;
        if (snapshot.Exists) {
            Dictionary<string, object> guestIdRef = snapshot.ToDictionary();
            availableID = int.Parse(guestIdRef["availableID"].ToString());

            string generatedName = "Player " + availableID;
            PlayerPrefs.SetString("GuestName", generatedName);
            playerData.GeneratedName = PlayerPrefs.GetString("GuestName");
            playerData.PlayerName = PlayerPrefs.GetString("GuestName");
            }
            else
            {
            Debug.Log("Document "+ snapshot.Id +" does not exist!");
            }

        Dictionary<string, object> guestid = new Dictionary<string, object>
        {
                { "availableID", availableID + 1 },
        };
        docRef.SetAsync(guestid);

        });
    }

    public void NewName()
    {
        if (NameText.text.Length < 10)
        {
            PlayerPrefs.SetString("PlayerName", NameText.text);
            playerData.PlayerName = PlayerPrefs.GetString("PlayerName");
        }      
    }
}
