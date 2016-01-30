using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class DemonPlayer : MonoBehaviour
{

    public ExplosiveSheep explosiveSheepPrefab;
    public GameObject fireballPrefab;
    public GameObject decoyPrefab;

    private PlayerController playerController;

    private LinkedList<char> buttonsPressed = new LinkedList<char>();

    // Use this for initialization
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        addPressedButton();

        if (isComboPressed("aa")) //Explosive sheep
        {
            GameObject.Instantiate(explosiveSheepPrefab,
                new Vector3(playerController.gameObject.transform.position.x, 0, playerController.gameObject.transform.position.z) + (playerController.aimDirection) * 3
                , Quaternion.identity);
        }
        if (isComboPressed("bb")) //Fireball
        {
            GameObject fireball = GameObject.Instantiate(fireballPrefab, transform.position, Quaternion.identity) as GameObject;
            fireball.GetComponent<Fireball>().direction = playerController.aimDirection;
        }
        if (isComboPressed("yy")) //Decoy
        {
            GameObject.Instantiate(decoyPrefab,
                new Vector3(playerController.gameObject.transform.position.x, 0, playerController.gameObject.transform.position.z) + (playerController.aimDirection) * 3
                , Quaternion.identity);
        }
    }

    private bool isComboPressed(string combo)
    {
        LinkedListNode<char> key = buttonsPressed.Last;
        for (int i = combo.Length - 1; i >= 0; i--)
        {
            if (key == null || key.Value != combo[i])
            {
                return false;
            }
            key = key.Previous;
        }

        buttonsPressed.Clear();
        return true;
    }

    private void addPressedButton()
    {
        if (Input.GetKeyDown("joystick 2 button 0"))
        {
            buttonsPressed.AddLast('a');
        }
        if (Input.GetKeyDown("joystick 2 button 1"))
        {
            buttonsPressed.AddLast('b');
        }
        if (Input.GetKeyDown("joystick 2 button 2"))
        {
            buttonsPressed.AddLast('x');
        }
        if (Input.GetKeyDown("joystick 2 button 3"))
        {
            buttonsPressed.AddLast('y');
        }

        while (buttonsPressed.Count > 100)
        {
            buttonsPressed.RemoveFirst();
        }
    }
}
