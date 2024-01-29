Battleship project by Samppa Alatalo, 2207843
For the course User Interface Programming at the University of Turku.
https://github.com/Suamppa/Battleship

This unfinished project is the start of a Battleship game. Currently it only features setup stages, which I focused on getting done first due to the nature of the course. I picked Unity for the project because it is what I'm currently most familiar with when it comes to the frontend.

Goals:
- Implement a simple Battleship game in Unity
- Utilize free assets
- Learn to implement UI logic and flow
- Learn UI development in Unity

Requirements:
- Based largely on the example provided in the instructions, adjusted for solo work
	- Focus on UI elements first, gameplay second

Most notable missing pieces:
- No proper gameplay, only board setup and battle initiation
- Can't quit without alt-F4 after starting battle
- No main menu

Pitfalls:
- Unfamiliarity with Unity's UI systems
	- I've done basic things, this involved a lot of UI interaction
- First time utilizing grids in Unity
	- This cost a lot of time in the end
- Many aspects that seemed simple on the surface turned out to be rabbit holes, sometimes because of Unity

What was learned:
- A ton about the ins and outs of UI in Unity and working with Unity in general
	- Very notably, I got significantly more familiar with how to do many different things with scripts as opposed to the editor
	- Also had to face the issue of Unity's script execution order and had to manage that through trial-and-error
- A lot more familiarity with Unity's event system
- Adapting UI to different screen sizes
	- Not thoroughly tested for later additions, but I always used principles that should enable scaling to all but extreme cases
- State management through game options and UI flow
- Dabbled with scene management near the end, but didn't have the time left to get into it properly

This project has been a huge learning resource for me, and I intend to finish it on my own time later on. It also reflects a big fault of mine: the inability to just prototype. I end up focusing on details and polish too early on, which leads to these unfinished, but polished (rather bug-free, in this case) results.
The returned project may still contain some obscure or deprecated things, but I tried to clean them up.

AI tools:
The most notable tool utilized in this project was GitHub Copilot. While considerably more clumsy with Unity projects than most other kinds, it still provided a lot of convenience and guidance on a lot of topics. Nothing was solved solely through it, its main use came in the form of autocompletion to save time, but it was also very helpful for asking questions about my specific circumstances because it is able to gather the context from the workspace (except for things related to Unity's inspector).
