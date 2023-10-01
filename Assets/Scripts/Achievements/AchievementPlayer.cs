using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AchievementPlayer : MonoBehaviour
{
    [SerializeField]
    private AchievementCollection aCollection;
    private PlayerMove playerMove;
    private ShotBullet shotBullet;

    [SerializeField]
    public Image successImage;
    [SerializeField]
    public Sprite goldenImage;

    public TMP_Text title;
    public TMP_Text description;
    public TMP_Text continueButton;

    private float startTime;
    public BossFight bossFight;

    [HideInInspector]
    public bool hasJumped = false;
    [HideInInspector]
    public float stepCounter = 0;

    private float timeFinished;

    void Start()
    {
        startTime = Time.time;
        playerMove = GetComponent<PlayerMove>();
        shotBullet = GetComponent<ShotBullet>();
    }

    void Update()
    {
        // Wait achievement
        if (aCollection.isAchieved(0) == false && Time.time - startTime >= 30f)
        {
            aCollection.activateAchievement(0);
            playerMove.achievementIdle = true;
        }
        // Walk achievement
        if (aCollection.isAchieved(1) == false && transform.position.x > -5)
        {
            aCollection.activateAchievement(1);
            playerMove.achievementHiking = true;
        }
        // Jump achievement
        if (aCollection.isAchieved(2) == false && hasJumped)
        {
            aCollection.activateAchievement(2);
            shotBullet.achievementAim = true;
        }
        // Death achievement
        if (aCollection.isAchieved(3) == false && playerMove.isDead)
        {
            aCollection.activateAchievement(3);
        }
        // Move 100 step achievement
        if (aCollection.isAchieved(4) == false && stepCounter >= 40)
        {
            aCollection.activateAchievement(4);
        }
        // Shoot achievement
        if (aCollection.isAchieved(5) == false && playerMove.IsAttacking != 0)
        {
            aCollection.activateAchievement(5);
        }
        // Boss kill achievement
        if (aCollection.isAchieved(6) == false && bossFight.bossKilled)
        {
            aCollection.activateAchievement(6);
            successImage.sprite = goldenImage;
            title.color = Color.black;
            description.color = Color.black;
            continueButton.color = Color.black;
            timeFinished = Time.time;
        }
        if (aCollection.isAchieved(6) == true && Time.time - timeFinished >= 4)
        {
            SceneManager.LoadScene("EndingScene");
        }
    }
}
