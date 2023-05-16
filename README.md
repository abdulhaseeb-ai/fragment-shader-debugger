# fragment-shader-debugger

In shader's - for debugging you can not print values to debug your shader.

with this tool you can do that, you just have to write your fragment shader code in c# style, like for 
i.uv in fragment shader you can use vector2 uv.

you can write your own math fucntion to perform the actions.

Each grid is representing a pixel. you can increase and decrease the number of pixels, by changing the grid size.

![A!](https://github.com/abdulhaseeb-ai/fragment-shader-debugger/assets/74037241/5fb0d6c4-34d2-4b59-bd49-8caea3ebc76e)

In ShaderDebbuger class you can change the grid size(how many pixels you want to add). (Use low grid size)
no need to change the "Pixel Scale" and "DistanceBetweenPixels".

![A2](https://github.com/abdulhaseeb-ai/fragment-shader-debugger/assets/74037241/611ef55b-1211-4d43-87b2-b0c847c28b0b)

ApplyChangesToPixels()
 is a function in ShaderDebugger.cs class, and the area in red, in which you will write you fragment shader code in c# style to debug values.
 
 

https://github.com/abdulhaseeb-ai/fragment-shader-debugger/assets/74037241/ca8ba008-a8cf-4b20-a39c-cd28c8f302f9

