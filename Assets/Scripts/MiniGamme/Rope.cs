using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public float rotationSpeed = 5f;

    void Update()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the screen coordinates to world coordinates
       // Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));

        // Calculate the direction from the image to the mouse position
        Vector3 direction = mousePosition - transform.position;

        // Calculate the angle to rotate towards the mouse position
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the image towards the mouse position
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, angle), rotationSpeed * Time.deltaTime);

        // Scale the image on Y based on the mouse Y position
        //float scaleY = Mathf.Clamp(mousePosition.y - transform.position.y, 0.5f, 2f); // Adjust the range of scaling as needed
        float scaleY = Vector2.Distance(mousePosition, transform.position)/100;
        if(Input.GetMouseButton(0))
        transform.localScale = new Vector3(scaleY * -1,1 , 1f);
        else
        transform.localScale = new Vector3(0,1 , 1f);

    }
}
