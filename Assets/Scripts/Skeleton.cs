﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{

    private DialogTrigger _dt;
    private EventManager _eventManager;
    private Help _helpBx;
    [SerializeField] private Dialog _clubFoundDialog;

    // Start is called before the first frame update
    void Start()
    {
        _dt = GetComponent<DialogTrigger>();
        _helpBx = FindObjectOfType<Canvas>().GetComponentInChildren<Help>();

        _eventManager = EventManager.Instance != null ? EventManager.Instance : FindObjectOfType<EventManager>();
        if (_eventManager == null)
            Debug.Log("Event Manager is null");

        _eventManager.ClubFound += ClubFound;
        _eventManager.FreeGammieSceneActive += TurnOffDialog;
    }

    public void ClubFound() => _dt.dialog = _clubFoundDialog;

    public void TurnOffDialog() => _dt.TurnOffDialogTrigger();

    OnTriggerEnter2d()
    {

    }

    private void OnDestroy()
    {
        _eventManager.ClubFound -= ClubFound;
        _eventManager.FreeGammieSceneActive -= TurnOffDialog;
    }
}
