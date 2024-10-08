## 🔴About
Warp'er is a 2D puzzle platformer game. In this game, players take on the role of Mel, a dedicated delivery courier. Mel, a little girl walking in the suburb of EverMail, trips and falls into a pile of rubbish. After trying to get out of the pile of rubbish, sunlight reflected into his eyes. A small blue object was seen shining among the piles of rubbish around it. Trying to reach the object, Mel fell into a sewer, now she has to find a way out. After learning about the abilities of the blue pendant, Mel saw a job poster as a package courier. With his pendant abilities, Mel wants to try to become the best package courier to help the people around him.

You, control Mel as a package courier whose job is to deliver packages to several places. Of course, there is not only a straight road in front of you. There are many obstacles that must be solved to open the way to the destination, it's your job to do it. Let's help Mel become the best of the best in her city.

<br>

## 🕹️Download Game
Download game here : [Download Here!](https://felixde-cat.itch.io/warper)

<br>

## 🔥Development Process
- **Environment** <br> The game was built in built-in render pipeline. We create the level design using unity tilemap system to ensure that every tile is placed in the correct grids. Then we create a parallax background effect to add an illusion depth in 2D scene. The parallax works by seperating background image to several different layers then move it following the current player position. The movement between layers are delayed by a short time for this to works.
- **Grab Mechanic** <br> One of the main game mechanic in the game is player is able to grab 2 object simultaneously. It works by setting the object in hold into a specific position.
![image](https://github.com/Felixwijaya04/Warp-er/blob/main/images/Screenshot%202024-10-08%20223641.png)
- **Throw Mechanic** <br> Player also has an ability to throw objects by pointing the cursor somewhere in the screen. The image below shows how player throw a pendant, a pendant is a unique item that is given to the player.
![image](https://github.com/Felixwijaya04/Warp-er/blob/main/images/Screenshot%202024-10-08%20225257.png)
- **Swap Mechanic** <br> This ability allows player to swap postion with the pendant instantly. It works by this single line of code: <br> <code>PlayerPosition.transform.position = SwapWith.transform.position;</code>
