using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability1; // reference to first ability
    public Ability ability2; // reference to second ability
    public Ability ability3; // reference to third ability
    float cooldownTime; // time for cooldown after using ability
    float activeTime; // time for active duration of the ability

    enum AbilityState // state of the ability
    {
        ready,
        active,
        cooldown
    }

    AbilityState state = AbilityState.ready; // initial state

    public KeyCode keyAbility1; // key for first ability
    public KeyCode keyAbility2; // key for second ability
    public KeyCode keyAbility3; // key for third ability

    void Update()
    {
        // check the state of first ability
        switch (state)
        {
            case AbilityState.ready: // ready to use
                if (Input.GetKeyDown(keyAbility1)) // if key is pressed
                {
                    ability1.UseAbility(gameObject); // use ability
                    state = AbilityState.active; // change state to active
                    activeTime = ability1.activeTime; // set active time
                }
                break;
            case AbilityState.active: // ability is active
                if (activeTime > 0) // active time remaining
                {
                    activeTime -= Time.deltaTime; // decrement active time
                }
                else // active time is over
                {
                    state = AbilityState.cooldown; // change state to cooldown
                    cooldownTime = ability1.cooldownTime; // set cooldown time
                }
                break;
            case AbilityState.cooldown: // ability is in cooldown
                if (cooldownTime > 0) // cooldown time remaining
                {
                    cooldownTime -= Time.deltaTime; // decrement cooldown time
                }
                else // cooldown time is over
                {
                    state = AbilityState.ready; // change state to ready
                }
                break;
        }

        // Check the state of the second ability
        switch (state)
        {
            // If the second ability is ready
            case AbilityState.ready:
                // Check if the second ability key is pressed
                if (Input.GetKeyDown(keyAbility2))
                {
                    // Use the second ability
                    ability2.UseAbility(gameObject);
                    // Change the state to active
                    state = AbilityState.active;
                    // Set the active time to the active duration of the second ability
                    activeTime = ability2.activeTime;
                }
                break;
            // If the second ability is active
            case AbilityState.active:
                // Check if the active time is greater than zero
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.cooldown;
                    cooldownTime = ability2.cooldownTime;
                }
                break;
            case AbilityState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;
                }
                break;
        }

        // Check the state of the third ability
        switch (state)
        {
            // If the third ability is ready
            case AbilityState.ready:
                // Check if the third ability key is pressed
                if (Input.GetKeyDown(keyAbility3))
                {
                    // Use the third ability
                    ability3.UseAbility(gameObject);
                    // Change the state to active
                    state = AbilityState.active;
                    // Set the active time to the active duration of the third ability
                    activeTime = ability3.activeTime;
                }
                break;
            // If the third ability is active
            case AbilityState.active:
                // Check if the active time is greater than zero
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.cooldown;
                    cooldownTime = ability3.cooldownTime;
                }
                break;
            case AbilityState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;
                }
                break;
        }
    }
}