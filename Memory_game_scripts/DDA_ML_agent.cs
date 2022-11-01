using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine.UI;

public class DDA_ML_agent : Agent
{
    public static int change_timer;
    public static int change_number_of_slots;
    public static int change_number_to_spawn;
    public override void OnEpisodeBegin()
    {
        //base.OnEpisodeBegin();
        //Button Respawn_button = GameObject.Find("Respawn_button").GetComponent<Button>();
        //Respawn_button.onClick.Invoke();
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        //sensor.AddObservation(player_imitator.delayTime);
        sensor.AddObservation(Spawner.reaction_time - Timer.timer_history);
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        //Debug.Log("discrete actions of slot changer: "+ actions.DiscreteActions[0]);
        change_number_of_slots = actions.DiscreteActions[0];
        change_number_to_spawn = actions.DiscreteActions[1];
        change_timer = actions.DiscreteActions[2];
    }
    private void Update()
    {
        /*if ((player_imitator.delayTime > 4) && (player_imitator.delayTime < 9))
        {
            Rewards();
        }*/
    }

    public void Rewards()
    {
        
            SetReward(1f);
            EndEpisode();
        /*if (player_imitator.delayTime > 10)
        {
            SetReward(-1f);
        }*/
    }
    
}
