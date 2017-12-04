using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Manager
{
    #region Variables

    #region Instructions Dictionary

    public Dictionary<int, string> InstructionsText = new Dictionary<int, string>
    {
        {1,
            "Hello! You must be the new farmer in town. My name is Linus, and I'm a bit of an expert farmer around here. " +
            "It looks like you may need some help getting started with farming. We have a bit of a bug problem, so I'd " +
            "get started soon or they might overwhelm you."
        },
        {2,
            "The first step is to plant seeds in the ground. Do this by <Color=Yellow>Left Clicking</Color> the type of " +
            "plant you want on the right, and then <Color=Yellow>Left Clicking</Color> on a farm tile to plant it. You " +
            "will need money to buy seeds, though. Here take $25 to get a basic plant."
        },
        {3,
            "Nice! Now, plants won't grow or attack unless they're watered so press <Color=Yellow>1</Color> or " +
            "<Color=Yellow>Left Click</Color> the watering can in the bottom left, then <Color=Yellow>Right Click</Color> " +
            "the farm tile to water it. You can water it more than once so it lasts longer."
        },
        {4,
            "Perfect! Now plants only grow during the day so make sure you keep them watered. You can refil your watering " +
            "can by <Color=Yellow>Left Clicking</Color> on your water source at the bottom of your farm. Be sure to protect " +
            "this because it's what the bugs will be going for first. If they pollute it too much then you'll have to abandon " +
            "your farm."
        },
        {5,
            "While you're starting your farm be mindful of where you place plants to protect it, because some farm tiles will " +
            "allow your plants to attack bugs more than once along your path. Lucky for us theses bugs never vere from the path. " +
            "Here take $50 to get a fire plant, and place it in a more strategic spot like here."
        },
        {6,
            "Looks great! Just in time too, because it's getting dark. Make sure your plants have plenty of water so they can defend " +
            "against the bugs. Here comes one now!"
        },
        {7,
            "Looks like you're getting the hang of it! There's one other thing you should know and it's that us farmers help each " +
            "other out when needed. If we need an extra plant to defend out farm we will send you a letter asking for plants we need, " +
            "and if you can grow them for us we will pay you well!"
        },
        {8,
            "Lets practice this once. <Color=Yellow>Left Click</Color> the mail icon in the upper left of the screen, then " +
            "<Color=Yellow>Left Click</Color> the green check mark to accept the quest from me. Press <Color=Yellow>2</Color> or " +
            "<Color=Yellow>Left Click</Color> on the sicle tool to harvest the fully grown fire plant that I was asking for."
        },
        {9,
            "Good job. Now open up the <Color=Yellow>Quest Log</Color> by pressing <Color=Yellow>Escape</Color> then " +
            "<Color=Yellow>Quest Log</Color>. Then <Color=Yellow>Left Click</Color> on  <Color=Yellow>Complete</Color> and " +
            "you'll get your reward!"
        },
        {10,
            ""
        },
    };

    #endregion

    public int InstructionsIndex = 1;
    public bool tutorialStartred = false;

    #endregion

    #region Singleton

    // create variable for storing singleton that any script can access
    private static Tutorial_Manager instance;

    // create GameManager
    private Tutorial_Manager()
    {

    }

    // Property for Singleton
    public static Tutorial_Manager Instance
    {
        get
        {
            // If the singleton does not exist
            if (instance == null)
            {
                // create and return it
                instance = new Tutorial_Manager();
            }

            // otherwise, just return it
            return instance;
        }
    }

    #endregion

    #region Public Methods

        #region Start Tutorial

        public void StartTutorial()
        {
            tutorialStartred = true;
        }

        #endregion

    #endregion
}
