using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float cooldown = 3f;
    private bool onCooldown = false;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && !onCooldown)
        {
            Fire();
            StartCoroutine("Cooldown");
            //Invoke("ResetCooldown", cooldown);
        }
    }
    void Fire()
    {
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        onCooldown = true;
    }

    IEnumerator Cooldown()
    {
        while (onCooldown)
        {
            yield return new WaitForSeconds(cooldown);
            onCooldown = false;
        }
    }
}
