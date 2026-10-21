using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Variables
    public string currentFood;
    public int foodIndex = 0;
    public TextMeshProUGUI foodText;

    // Make an array to hold strings
    public string[] shoppingarray = new string[10]
    {
        "Saffron",
        "Milk",
        "Bread",
        "Eggs",
        "Cheese",
        "Oil",
        "Ham",
        "Noodles",
        "Bacon",
        "PB&J",
    };
    // Singleton
    public static GameManager instance;

    //Awake is called before frame 1
    private void Awake()
    {
        //if there is no instance of GameManager, make this the main instance
        if(instance == null)
        {
            instance = this;
            // Don't destroy upon new scene load
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy all dublicates except the main instance
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentFood = shoppingarray[foodIndex];
    }

    // Update is called once per frame
    void Update()
    {
        foodText.text = currentFood;
    }
}
