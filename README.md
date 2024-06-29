# PhoenixHeadTracker
The Phoenix Head Tracker is a program that interfaces with Xreal Air glasses to capture and analyze sensor data using [AirAPI_Windows.dll](https://github.com/MSmithDev/AirAPI_Windows). By detecting changes in the user's head yaw and pitch, this program can send this data to opentrack over UDP or you can even control the movement of the computer mouse on screen which can be used to play video games that use mouse look feature. You can also use this feature with Nreal Air 3D SBS mode

[Buy Me a Coffee](https://www.buymeacoffee.com/ivideogameboss) Hey, I created PhoenixHeadTracker for Xreal Air and would really appreciate your support. I work on this software on my own time for you guys. Thank You!

https://user-images.githubusercontent.com/129109589/229800261-125fdc69-845c-4815-9231-f5b6f53a43fa.mp4

I worked all day and night on this thing and it was worth it for you all. You will love your Xreal Air glasses with this new tool. It even works with 3D SBS mode. Play your games, Skyrim, DCS, Microsoft Flight Simulator, Cyberpunk 2077.

https://user-images.githubusercontent.com/129109589/230780822-298d8527-4deb-4d49-a18e-28d2e3c5ec9b.mp4

# How to use PhoenixHeadTracker
To connect your Xreal Air glasses to your PC, there are two options available. Firstly, you can use the USB-Type C connector. Alternatively, a goFanco adapter can also be used, which can be obtained from the following Amazon link: [goFanco adapter](https://www.amazon.com/gp/product/B08Y5PBWLQ/ref=ppx_yo_dt_b_asin_title_o03_s00?ie=UTF8&psc=1)

It is important to ensure that your glasses have a direct connection to the PC. Once connected, launch the PhoenixHeadTracker software and click on the 'Connect Xreal Air' option. Please allow a few seconds for the sensors to adjust.


You now have two options for utilizing the head tracking data. Firstly, you can use opentrack, or alternatively, you can click on 'Start Mouse Track'. This will allow you to control the mouse on your screen, enabling you to look around in video games. Here is an example of playing Cyberpunk 2077 with mouse look feature and using a controller at same time. On PC you can play games using a controller, mouse, keyboard. PhoenixHeadTracker and Xreal Air are the perfect match.

https://user-images.githubusercontent.com/129109589/231939591-a10d483a-73e6-49ed-bf91-9a9bea4aa893.mp4

Should you choose to use opentrack, you can do so by clicking on the 'start opentrack UDP' option. Within opentrack, you will need to select UDP over network in order to receive the data.

![Screenshot 2023-04-14 211257](https://user-images.githubusercontent.com/129109589/232178275-0cf625e5-ec33-4693-a267-54263bb61514.png)

Opentrack settings for UDP

![Screenshot 2023-04-08 210432](https://user-images.githubusercontent.com/129109589/230751023-7cad672a-8384-430a-80d7-90aa4ea986ce.png)

You can also adjust how to use the Yaw and Pitch values. So if you want the in game camera to turn 90 degrees like in real life you can adjust it in mappings.

![Screenshot 2023-04-12 073500](https://user-images.githubusercontent.com/129109589/231459880-3880c7c7-425a-4139-8880-e4882242ed39.png)

Here you can see I wanted the in game camera to turn faster on Yaw so I don't have to turn 90 degrees is real life. It makes it eaiser on the neck when playing games. So now when I turn my head it will turn faster to left and right using the data from PhoenixHeadTracker.

![yaw](https://user-images.githubusercontent.com/129109589/231812388-13638e1f-8a0d-4ab1-92d3-9df32284643e.png)

I did the same think for Pitch so it just feels right.

![pitch](https://user-images.githubusercontent.com/129109589/231812662-f7456c5b-ff64-4778-b579-c5f7ca037648.png)

I reccomend you also flat line roll data as this data is not used by PhoenixHeadTracker

![roll](https://user-images.githubusercontent.com/129109589/231813295-ab9837f9-dc39-4a1f-945f-84421c0ccfd6.png)

# Setup your Center Key in Opentrack

Due to how gyro data works and drifts, it is a good idea to have a center camera key setup. Just click on bind and pick a key. In this example you can see I picked the '-' key on my numpad.

![Screenshot 2023-04-13 103644](https://user-images.githubusercontent.com/129109589/231813488-767b9d61-0373-4315-b4c1-ae6a2a4d24f9.png)

# Microsoft Flight Simulator working with opentrack

https://user-images.githubusercontent.com/129109589/230751056-9ac0df97-939f-4e08-b3d2-690d606b58e5.mp4


# Download Latest Release

Phoenixheadtracker https://github.com/iVideoGameBoss/PhoenixHeadTracker/releases

Opentrack https://github.com/opentrack/opentrack/releases

# How to build using Visual Studio 22
PhoenixHeadTracker is based on the AirAPI_Windows.dll :https://github.com/MSmithDev/AirAPI_Windows: You will find the AirAPI_Windows.dll and hidapi.dll in the PhoenixHeadTracker/bin/x64/Debug/ folder. These two files are required in order to connect to Nreal Air glasses.


Once you clone the project, open in Visual Studio 22 by clicking on PhoenixHeadTracker.sln. Make sure you set to build on x64 and debug.Then simply click on start.

![visualstudio22](https://user-images.githubusercontent.com/129109589/228050319-965458a1-af36-466a-8aa7-c45364bc91dd.png)


Make sure that both AirAPI_Windows.dll and hidapi.dll are in the debug folder. I have included them with project.

![Screenshot 2023-03-27 145335](https://user-images.githubusercontent.com/129109589/228051761-b6afc531-5881-4ea3-b935-c2c07860951e.png)

# You Can Use Phoenix Head Tracker with Gyro Data from Other Devices 

PhoenixHeadTracker can be made to work with other devices that can supply gyro data using a dll. You can also add code if you want to work with 6dof data. Its already setup to work with 3dof data in degrees. Create your own dll and import it like I did here with AirAPI_Windows.dll. Add two functions to get started. 

![Screenshot 2023-04-13 105555](https://user-images.githubusercontent.com/129109589/231817088-a0858efd-4658-409c-86d4-4a896ee8b6a9.png)

The GetEuler function returns an array for Yaw, Pitch and Roll. 

![Screenshot 2023-04-13 104815](https://user-images.githubusercontent.com/129109589/231816062-8c449833-fc7f-4a5b-9395-3fad939c88ea.png)



# DCS (Digital Combat Simulator)


https://user-images.githubusercontent.com/129109589/230140740-2248b626-169c-4f85-bb17-baec839264f3.mp4
