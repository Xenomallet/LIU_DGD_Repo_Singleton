using UnityEngine;
using UnityEngine.InputSystem;

public class ClickScript : MonoBehaviour
{
    //Variables
    private Camera maincam;


    //Awake is called before frame 1
    private void Awake()
    {
        maincam = Camera.main;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check if left mouse is pressed; call Raycasthit() if true
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Raycasthit();
        } 
    }

    private void Raycasthit()
    {
        // get current mouse position
        Vector2 mousePos = Mouse.current.position.ReadValue();

        // convert screen position to ray
        Ray ray = maincam.ScreenPointToRay(mousePos);

        // cast ray; if it hits something, do something
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
        
        // upon hit
        if (hit2D.collider != null)
        {
            // prevent index out of bounds error
            if (GameManager.instance.foodIndex < GameManager.instance.shoppingarray.Length - 1)
            {
                GameManager.instance.foodIndex++;
                GameManager.instance.currentFood = GameManager.instance.shoppingarray[GameManager.instance.foodIndex + 1];
            }
            else
            {
                GameManager.instance.foodIndex = 0;
                GameManager.instance.currentFood = GameManager.instance.shoppingarray[0];
            }

            Debug.Log("Hit " + hit2D.collider.name);
            Debug.Log("Current index: " + GameManager.instance.foodIndex);
        }
    }
}
