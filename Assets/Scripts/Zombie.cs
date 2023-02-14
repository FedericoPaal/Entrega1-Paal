using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyStates
{
    Idle,
    Pursuit,
    RunAway
}

public enum Enemies
{
    Enemy1,
    Enemy2
}
public class Zombie : MonoBehaviour
{ 
[SerializeField] private EnemyStates currentState;

[SerializeField] private Enemies settingEnemies;

[SerializeField] private Transform character;
[SerializeField] private float rotationSpeed;
[SerializeField] private float speed;
[SerializeField] private float pursuitDistance;

private void LookAt()
{

    var vectorToCharacter = character.position - transform.position;
    var newRotation = Quaternion.LookRotation(vectorToCharacter);
    transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
}

private void Pursuit()
{
    var vectorToCharacter = character.position - transform.position;

    var distance = vectorToCharacter.magnitude;
    if (distance > pursuitDistance)
    {
        transform.position += vectorToCharacter.normalized * (speed * Time.deltaTime);
    }
}

public void SetEnemies()
{
    switch (settingEnemies)
    {
        case Enemies.Enemy1:
            ExecuteIdle();
            break;

        case Enemies.Enemy2:
            ExecutePursuit();
            break;
    }
}

public void SetCurrentState()
{
    switch (currentState)
    {
        case EnemyStates.Idle:
            ExecuteIdle();
            break;

        case EnemyStates.Pursuit:
            ExecutePursuit();
            break;

        case EnemyStates.RunAway:
            ExecuteRunAway();
            break;
    }
}

private void ExecuteIdle()
{
    LookAt();
}

private void ExecutePursuit()
{
    LookAt();
    Pursuit();
}

private void ExecuteRunAway()
{

}

void Start()
{

}

void Update()
{
    SetEnemies();

}
}
