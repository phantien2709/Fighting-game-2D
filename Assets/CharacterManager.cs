using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public bool solo;
    public int numberOfUsers;
    public List<PlayerBase> players = new List<PlayerBase>();
    public List<CharacterBase> characterList = new List<CharacterBase>();
    public CharacterBase returnCharacterWithID(string id)
    {
        CharacterBase reval = null;
        for(int i = 0; i < characterList.Count; i++)
        {
            if(string.Equals(characterList[i].charId,id))
            {
                reval = characterList[i];
                break;
            }
        }
        return reval;
    }
    public PlayerBase returnPlayerFromState(StateManager state)
    {
        PlayerBase reval = null;
        for(int i = 0; i < players.Count; i++)
        {
            if(players[i].playerStates == state)
            {
                reval = players[i];
                break;
            }
        }
        return reval;
    }
    public PlayerBase returnOppositePlater(PlayerBase pl)
    {
        PlayerBase reval = null;
        for(int i = 0; i < players.Count; i++)
        {
            if(players[i] != pl)
            {
                reval = players[i];
                break;    
            }
        }
        return reval;
    }
    public int ReturnCharacterInt(GameObject prefab)
    {
        int reval = 0;
        for(int i = 0; i < characterList.Count; i++)
        {
            if(characterList[i].prefab == prefab)
            {
                reval = i;
                break;
            }
        }
        return reval;
    }
    public static CharacterManager instance;
    public static CharacterManager GetsIntance()
    {
        return instance;
    }
    [System.Serializable]
    public class CharacterBase
    {
        public string charId;
        public GameObject prefab;
        public Sprite icon;
    }
    [System.Serializable]
    public class PlayerBase
    {
        public string playerId;
        public string inputId;
        public PlayerType playerType;
        public bool hasCharacter;
        public GameObject playerPrefab;
        public StateManager playerStates;
        public int score;

    }
    
    public enum PlayerType
    {
        user, //it's a real human
        ai,//skynet basically
        simulation //for multiplayer over network, no, that's not a promise..
    }
}
