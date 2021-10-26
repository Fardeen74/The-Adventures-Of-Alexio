using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int robotsDestroyed;
    
    public bool isOtherUIActive = false;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {

    }

    private void Update()
    {

    }
}