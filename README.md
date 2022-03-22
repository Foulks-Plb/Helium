# Helium - Smartphone Game

<p align="center">
    <img align="center" src="https://github.com/Foulks-Plb/helium/blob/main/Images_Sprites/helium_download.PNG?raw=true" width="700" height="350" />
</p>

Helium is an arcade mobile game developed as a personal project during my student years.

I developed several aspects:

- Gameplay
- A store to progress in the game.
- A Scoring multiplayer System with Firebase firestore
- Ads system with google ad mob.
- Tracking data player system with Firebase analytics

## demo

If you want to see how Helium will render :
Youtube: https://www.youtube.com/watch?v=BgeTirM4m8Q

## Some interesting aspects...
### Throwing system:

<img src="https://github.com/Foulks-Plb/helium/blob/main/Images_Sprites/Trowing.gif?raw=true" width="350" height="350" />

```C#
Vector2 CalculateLaunchVelocity()
    {
        float displacementY = target.position.y - Projectile.transform.position.y;
        Vector2 displacementXZ = new Vector2(target.position.x - Projectile.transform.position.x, 0);
        Vector2 velocityY = Vector2.up * Mathf.Sqrt(Mathf.Abs(-2 * gravity * h));
        Vector2 velocityX = displacementXZ / (Mathf.Sqrt(Mathf.Abs(-2 * h / gravity)) + Mathf.Sqrt(Mathf.Abs(2 * (displacementY - h) / gravity)));
        return velocityX + velocityY;
    }
```
```C#
launchData CalculateLaunchData()
    {
        float displacementY = target.position.y - launchPos.y;
        Vector2 displacementXZ = new Vector2(target.position.x - launchPos.x, 0);
        float time = Mathf.Sqrt(Mathf.Abs(-2 * h / gravity)) + Mathf.Sqrt(Mathf.Abs(2 * (displacementY - h) / gravity));
        Vector2 velocityY = Vector2.up * Mathf.Sqrt(Mathf.Abs(-2 * gravity * h));
        Vector2 velocityX = displacementXZ / time;

        return new launchData(velocityX + velocityY, time);
    }
 ```
 ```C#
private void DrawPath()
    {
        launchData LaunchData = CalculateLaunchData();
        Vector3 previousDrawPoint = launchPos;

        for (int i = 0; i < TrajectoryParent.transform.childCount; i++)
        {
            float simulationTime = i / (float)resolution * .5f;
            Vector2 displacement = LaunchData.initialVelocity * simulationTime + Vector2.up * gravity * simulationTime * simulationTime / 2f;
            Vector3 drawPoint = new Vector3(launchPos.x, launchPos.y, 0) + new Vector3(displacement.x, displacement.y, 0);
            TrajectoryParent.transform.GetChild(i).position = drawPoint;
            TrajectoryParent.transform.GetChild(i).localScale = Vector3.one * (Mathf.Pow(.92f, i + 2) / 1.5f);
        }
    }
```
### Balloon spawn system:

<img src="https://github.com/Foulks-Plb/helium/blob/main/Images_Sprites/balloonSpawn.gif?raw=true" width="350" height="350" />

 ```C#
IEnumerator SpawnBalloon()
    {
        if (gameplayInfos.Playing)
        {
            while (true)
            {
                GameObject Balloon = Instantiate(enemies[Random.Range(0, 8)], transform.position, transform.rotation);
                SoundFx.RandomPopSound(Random.Range(0, 4));

                Balloon.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1 * Random.Range(150, 200), Random.Range(0, 1)));

                yield return new WaitForSeconds(spawnWait);
            }
        }
    }
   ```
   
   ### Leaderboard system:
   ```C#
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
"# Helium" 
