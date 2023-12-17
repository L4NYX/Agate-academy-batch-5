using System.Collections;
using System;
using System.Collections.Generic;

using UnityEngine;

using UnityEngine.AI;


public class Enemy : MonoBehaviour

{
    private Player _player;
   private void Start()

{

if(Player != null)

{

Player.OnPowerUpStart += StartRetreating;

Player.OnPowerUpStop += StopRetreating;

}

}
      

    private void StartRetreating()

{

SwitchState(RetreatState);

}


private void StopRetreating()

{

SwitchState(PatrolState);

}

    private BaseState _currentState;


public PatrolState PatrolState = new PatrolState();

public ChaseState ChaseState = new ChaseState();

public RetreatState RetreatState = new RetreatState();

[SerializeField]

public List<Transform> Waypoints = new List<Transform>();

[SerializeField]

public float ChaseDistance;

[SerializeField]

public Player Player;

 

[HideInInspector]

public NavMeshAgent NavMeshAgent;

 

public void SwitchState(BaseState state)

{

_currentState.ExitState(this);

_currentState = state;

_currentState.EnterState(this);

}

 

private void Awake()

{

_currentState = PatrolState;

_currentState.EnterState(this);

NavMeshAgent = GetComponent<NavMeshAgent>();

}


private void Update()

{

if(_currentState != null)

{

_currentState.UpdateState(this);

}

}

}