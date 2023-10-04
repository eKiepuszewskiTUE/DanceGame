using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    //Song beats per minute
    //This is determined by song it is synced too
    public float SongBpm;
    //Number of seconds for each beat
    public float SecPerBeat;
    //Current Position (sec)
    public float SongPosition;
    //Current Position (beats)
    public float SongPositionInBeats;
    //How many seconds have passed since song started
    public float dspSongTime;
    //AudioSource attached to this Gameobject that plays music;
    public AudioSource MusicSource;
    //Notes shown in advance
    public float BeatsShownInAdvance;

    //keep all position-in-beats of notes is song
    public float[] notes;
    //Index of next note to be spawned
    public int NextIndex = 0;

    //link script arrowmovement
    public ArrowMovement arrowMovement;


    public bool startMusic;

    //Create easy link for editting
    public static Conductor instance;

    private void Start()
    {
        instance = this;
        //Link Arrowmovement Scripts
        arrowMovement = GameObject.FindGameObjectWithTag("ArrowHolder").GetComponent<ArrowMovement>();
        //Load music
        MusicSource = GetComponent<AudioSource>();
        //Calculate number of seconds in each beat
        SecPerBeat = 60f / SongBpm;
        //Record the time when music starts
        dspSongTime = (float)AudioSettings.dspTime;
        
    }

    private void Update()
    {
        if (!startMusic)
        {
            if (Input.anyKeyDown)
            { 
                startMusic = true;
                arrowMovement.hasStarted = true;

                MusicSource.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit");
    }

    public void NoteMissed()
    {
        Debug.Log("Miss");
    
    }
}
