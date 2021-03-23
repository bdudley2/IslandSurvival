using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stores all the dialogue sentences for the game
public class SentenceScripts
{
    // convos is short for conversations (as in our array of conversations)
    public string[,,] FillSentences() {
        string[,,] convos = new string[10, 100, 100]; // array of conversations, each with an array of sentences


        // ========================================================================
        //                      --- Character 1 (Thoughts) ---

        // Conversation 1
        convos[0, 0, 0] = "You wake up on the beach";
        convos[0, 0, 1] = "It's cold, you wish you had a blanket";
        convos[0, 0, 2] = "You get up... carrying your passed out Dad. He's hurt and needs help";
        convos[0, 0, 3] = "+";

        // Conversation 2
        convos[0, 1, 0] = "Maybe I should look around a bit...";
        convos[0, 1, 1] = "+";

        // Conversation 3
        convos[0, 3, 0] = "Awesome, you talked to all the characters. Feeling proud of your effort, you rest happily for the night.";
        // convos[0, 3, 1] = "The village welcomes you and your father, and tend to your wounds.";
        // convos[0, 3, 2] = "Over the days, you wait anxiously for your dad to recover, but he never does.";
        // convos[0, 3, 3] = "Worried, you decide you need to stop waiting and start acting, or else he may never get better.";
        // convos[0, 3, 4] = "You decide to go talk to each of the leaders in the village to see if any of them can help.";
        // Here you would add an objective to go around the village looking for information (I think of it as botw quest added)
        convos[0, 3, 1] = "+";

        // Conversation 4
        convos[0, 5, 0] = "I already talked with all the characters. I guess I'm already done for today. Time to relax for a bit";
        // convos[0, 3, 1] = "The village welcomes you and your father, and tend to your wounds.";
        // convos[0, 3, 2] = "Over the days, you wait anxiously for your dad to recover, but he never does.";
        // convos[0, 3, 3] = "Worried, you decide you need to stop waiting and start acting, or else he may never get better.";
        // convos[0, 3, 4] = "You decide to go talk to each of the leaders in the village to see if any of them can help.";
        // Here you would add an objective to go around the village looking for information (I think of it as botw quest added)
        convos[0, 5, 1] = "+";





        // ========================================================================
        //                      --- Character 2 (Bob) ---

        // Conversation 1
        convos[1, 0, 0] = "Greetings, I'm Bob. I run things around here.";
        convos[1, 0, 1] = "Don't listen to what that rebel Ross has to say. He's always stirring up trouble on this island.";
        convos[1, 0, 2] = "Anyways, help me out and I'll return the favor for you and your father.";
        convos[1, 0, 3] = "+";





        // ========================================================================
        //                      --- Character 3 (Russ) ---

        // Conversation 1
        convos[2, 0, 0] = "Hello, I'm Russ. You wanna help me out.";
        convos[2, 0, 1] = "You see, our buddy Bob over there is roping a lot of people up to fall in line with his proposed rules.";
        convos[2, 0, 2] = "But I think the power is going to his head. His rules are overly strict and ruins a lot of fun that we have on this island.";
        convos[2, 0, 3] = "Listen to me and my group, and we'll help keep this island free for us to do what we want.";
        convos[2, 0, 4] = "+";





        // ========================================================================
        //                      --- Character 4 (Sarah) ---

        // Conversation 1
        convos[3, 0, 0] = "Heya, I'm Sarah. Nice to meet You.";
        convos[3, 0, 1] = "Blue and Red over there are at each others' throats, but I'm not going to get caught up in that mess.";
        convos[3, 0, 2] = "To be honest, I could care less with who we follow. Just as long as I can get some peace and quiet in the end";
        convos[3, 0, 3] = "+";





        return convos;

    }
}
