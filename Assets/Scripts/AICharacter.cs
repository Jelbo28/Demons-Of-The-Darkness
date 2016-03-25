using UnityEngine;
using System.Collections;

public class AICharacter : MonoBehaviour
{
	#region Variables
	PlayerController playerControls;
	PlayerController enemyControls;

	[SerializeField]
	float changeStateTolerance = 3;

	[SerializeField]
	float normalRate = 1;

	float normalTimer;

	[SerializeField]
	float closeRate = 0.5f;
	float closeTimer;

	[SerializeField]
	float blockingRate = 1.5f;
	float blockTimer;

	[SerializeField]
	float aiStateLife = 1;
	float aiTimer;

	bool initiateAI;
	bool closeCombat;

	bool gotRandom;
	float storeRandom;

	bool checkForBlocking;
	bool blocking;
	float blockMultiplier;

	bool randomizeAttacks;
	int numberOfAttacks;
	int currentNumberAttacks;

	[SerializeField]
	float JumpRate = 1;
	float jumpRate;
	bool jump;
	float jumpTimer;
	#endregion

	public enum AIState
	{
		closeState,
		normalState,
		resetAI
	}

	public AIState aiState;

	void Start ()
	{
		playerControls = GetComponent<PlayerController> ();
	}

	void Update ()
	{
		if (!enemyControls) 
		{
			enemyControls = playerControls.enemy.GetComponent<PlayerController> ();
		}

		CheckDistance ();
		States ();
		AIAgent ();
	}

	void States()
	{
		switch (aiState)
		{
		case AIState.closeState:
			CloseState ();
			break;
		case AIState.normalState:
			NormalState ();
			break;
		case AIState.resetAI:
			ResetAI ();
			break;
		}

        Blocking();
        Jumping();
	}

	void AIAgent()
	{
		if (initiateAI) 
		{
			aiState = AIState.resetAI;
            float multiplier = 0;


            if (!gotRandom)
            {
                storeRandom = ReturnRandom();
                gotRandom = true;
            }

            if(!closeCombat)
            {
                multiplier += 30;
            }
            else
            {
                multiplier -= 30;
            }

            if(storeRandom + multiplier < 50)
            {
                Attack();
            }
            else
            {
                Movement();
            }

		}
			
	}

    void Attack()
    {
        if(!gotRandom)
        {
            storeRandom = ReturnRandom();
            gotRandom = true;
        }

        if(storeRandom < 75)
        {
            if(!randomizeAttacks)
            {
                numberOfAttacks = (int)Random.Range(1, 4);
                randomizeAttacks = true;
            }

            if (currentNumberAttacks < numberOfAttacks)
            {
                int attackNumber = Random.Range(0, playerControls.attack.Length);

                playerControls.attack[attackNumber] = true;

                currentNumberAttacks++;
            }
        }
        else
        {
            if(currentNumberAttacks < 1)
            {
                playerControls.specialAttack = true;
                currentNumberAttacks++;
            }
        }
    }

	void Movement()
	{
        if(!gotRandom)
        {
            storeRandom = ReturnRandom();
            gotRandom = true;
        }

        if (storeRandom < 90)
        {
            if (playerControls.enemy.position.x < transform.position.x)
            {
                playerControls.horizontal = -1;
            }
            else
            {
                playerControls.horizontal = 1;
            }
        }
		if (playerControls.enemy.position.x < transform.position.x)
        {
            playerControls.horizontal = -1;
        }
        else
        {
            playerControls.horizontal = 1;
        }
    }

	void ResetAI()
	{
		aiTimer += Time.deltaTime;

		if(aiTimer > aiStateLife)
		{
			initiateAI = false;
            playerControls.horizontal = 0;
            playerControls.vertical = 0;
            aiTimer = 0;

            gotRandom = false;
            storeRandom = ReturnRandom();

            if(storeRandom < 50)
            {
                aiState = AIState.normalState;
            }
            else
            {
                aiState = AIState.closeState;
            }

            currentNumberAttacks = 1;
            randomizeAttacks = false;
		}
	}

	void CheckDistance()
	{
		float distance = Vector3.Distance (transform.position, playerControls.enemy.position);

		if (distance < changeStateTolerance) 
		{
			if (aiState != AIState.resetAI) 
				aiState = AIState.closeState;

			closeCombat = true;
		} 
		else 
		{
			if(aiState != AIState.resetAI)
            {
                aiState = AIState.normalState;
            }
            if (closeCombat)
			{
                if (!gotRandom)
                {
                    storeRandom = ReturnRandom();
                    gotRandom = true;
                }

                if(storeRandom < 60)
                {
                    Movement();
                }
			}
			closeCombat = false;
		}
	}

    void Blocking()
    {
        if (playerControls.damage)
        {
            if(!gotRandom)
            {
                storeRandom = ReturnRandom();
                gotRandom = true;
            }

            if(storeRandom < 50)
            {
                blocking = true;
                playerControls.damage = false;
                playerControls.blocking = true;
            }
        }

        if (blocking)
        {
            blockTimer += Time.deltaTime;

            if(blockTimer > blockingRate)
            {
                playerControls.blocking = false;
                blockTimer = 0;
            }
        }
    }

	void NormalState()
	{
		normalTimer += Time.deltaTime;

		if (normalTimer > normalRate)
		{
			initiateAI = true;
			normalTimer = 0;
		}
	}

	void CloseState()
	{
		closeTimer += Time.deltaTime;

		if (closeTimer > closeRate)
		{
			closeTimer = 0;
			initiateAI = true;
		}
	}

    void Jumping()
    {
        if(enemyControls.jumpKey || jump)
        {
            playerControls.vertical = 1;
            jump = false;
        }
        else
        {
            playerControls.vertical = 0;
        }

        jumpTimer += Time.deltaTime;

        if(jumpTimer > jumpRate*10)
        {
            jumpRate = ReturnRandom();

            if(jumpRate < 50)
            {
                jump = true;
            }
            else
            {
                jump = false;
            }
            jumpTimer = 0;
        }
    }

    float ReturnRandom()
    {
        float returnValue = Random.Range(0, 101);
        return returnValue;
    }
}
