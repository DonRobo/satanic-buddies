using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class DemonPlayer : MonoBehaviour
{

    //private bool lastUp;
    // private bool lastDown;
    // private bool lastLeft;
    // private bool lastRight;
    private Dictionary<string, bool> lastDpad = new Dictionary<string, bool>();

    public ExplosiveSheep explosiveSheepPrefab;
    public GameObject fireballPrefab;
    public GameObject cometPrefab;
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
        if (isComboPressed("xyd")) //Fireball
        {
            GameObject fireball = GameObject.Instantiate(fireballPrefab, transform.position + new Vector3(0, 1,1), Quaternion.identity) as GameObject;
            fireball.GetComponent<Fireball>().direction = playerController.aimDirection;
        }
        if (isComboPressed("xx")) //comet
        {
            GameObject.Instantiate(cometPrefab,
                new Vector3(playerController.gameObject.transform.position.x, 10, playerController.gameObject.transform.position.z) + (playerController.aimDirection) * 8
                , Quaternion.identity);
        }
        if (isComboPressed("uda")) //Decoy
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
        if (Input.GetButtonDown("DemonA"))
        {
            buttonsPressed.AddLast('a');
        }
        if ( Input.GetButtonDown("DemonB"))
        {
            buttonsPressed.AddLast('b');
        }
        if (Input.GetButtonDown("DemonX"))
        {
            buttonsPressed.AddLast('x');
        }
        if ( Input.GetButtonDown("DemonY"))
        {
            buttonsPressed.AddLast('y');
        }

        if (GetDpadDown("DemonUp"))
        {
            buttonsPressed.AddLast('u');
        }
        if (GetDpadDown("DemonDown"))
        {
            buttonsPressed.AddLast('d');
        }
        if (GetDpadDown("DemonLeft"))
        {
            buttonsPressed.AddLast('l');
        }
        if (GetDpadDown("DemonRight"))
        {
            buttonsPressed.AddLast('r');
        }

        while (buttonsPressed.Count > 100)
        {
            buttonsPressed.RemoveFirst();
        }
    }

    private bool GetDpadDown(string axis)
    {
        bool last = false;
        if (lastDpad.ContainsKey(axis))
        {
            last = lastDpad[axis];
        }

        if (Input.GetAxis(axis) > 0.5)
        {
            lastDpad[axis] = true;
            if (!last)
            {
                return true;
            }
        }
        else
        {
            lastDpad[axis] = false;
        }
        return false;
    }
}
