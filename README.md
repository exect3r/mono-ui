# mono-ui
_Monogame_ is one of the best frameworks for game development in _C#_. It makes it easier for Indie Devs to pour their ideas directly into code without the need to worry about tedious tasks like managing content, fps and ups...

#### However,
it has a small _limitation_ that lets down amateurs: lack of an implementation of a GUI.
I, as an amateur coder, am attempting to create a basic GUI that is flexible enough to suit a decent range of needs. This task should be a great learning experience for me while also benefiting the community.
___

## How to use it?
Simple:
1. Make sure to make the game field in _Program.cs_, an _internally-accessible static field_ instead. This is to ensure access to crucial fields like `GraphicsDevice`, `Content`, `IsMouseVisible`... (check the included _Program.cs_)
2. Add the included _Mouse.cs_, _Keyboard.cs_ and _EventHandler.cs_ to your solution because GUI events depend on them. (otherwise, change the GUI implementations to suit your needs)
3. Make sure static classes _Mouse_, _Keyboard_ and _Gui_ are initialized and loaded properly and don't forget to __*hook*__ them in the main loops.
4. You can use `Gui.Add(elements, ...)` to add elements. (duh)
5. Make sure `Gui.Show()` is called since the Gui is _hidden_ by default.
P.S: Check the included _Game.cs_ for a detailed example.
___

## Todo list:
* Handle _Keyboard_ events.
* Add _Label_ element: a simple drawable text.
* Add _Button_ element: a child of _Pressable_ with a preset look and behaviour.
* Add _TextBox_ element: a text input field.
* Add _DropList_ element: selection from a multiple-choice list.
___

## Final words:
I am a self-taught amateur coder and wish to put my knowledge to the test. I will publish my work here in Github to be criticized and corrected by the experts in hopes of expanding my programming capabilities while also providing service to the community.
If you wish to financially support me, I can only accept donations as Bitcoins. You can find me on Discord: `exect3r#8676` for more details.
