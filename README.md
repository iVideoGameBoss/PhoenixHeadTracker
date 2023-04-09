# PhoenixHeadTracker
The Phoenix Head Tracker is a program that interfaces with Nreal Air glasses to capture and analyze sensor data using [AirAPI_Windows.dll](https://github.com/MSmithDev/AirAPI_Windows). By detecting changes in the user's head yaw and pitch, this program can send this data to opentrack over UDP or can control the movement of the computer mouse on screen which can be used to play video games that use mouse look feature. You can also use this feature with Nreal Air 3D SBS mode

https://user-images.githubusercontent.com/129109589/229800261-125fdc69-845c-4815-9231-f5b6f53a43fa.mp4

I worked all day and night on this thing and it was worth it for you all. You will love your Nreal Air glasses with this new tool. It even works with 3D SBS mode. Play your games, Skyrim, DCS, Flight Simulator, Cyberpunk 2077.

[Steam Deck Fund](https://www.paypal.com/paypalme/ivideogameboss?country.x=US&locale.x=en_US)


https://user-images.githubusercontent.com/129109589/230802230-56d4b4d8-45cb-4d59-8653-de35eb603621.mp4


# How to use PhoenixHeadTracker
To connect your Nreal Air glasses to your PC, there are two options available. Firstly, you can use the USB-Type C connector. Alternatively, a goFunco adapter can also be used, which can be obtained from the following Amazon link: [goFanco adapter](https://www.amazon.com/gp/product/B08Y5PBWLQ/ref=ppx_yo_dt_b_asin_title_o03_s00?ie=UTF8&psc=1).

It is important to ensure that your glasses have a direct connection to the PC. Once connected, launch the PhoenixHeadTracker software and click on the 'Connect Nreal Air' option. Please allow a few seconds for the sensors to adjust.

You now have two options for utilizing the head tracking data. Firstly, you can use opentrack, or alternatively, you can click on 'Start Mouse Track'. This will allow you to control the mouse on your screen, enabling you to look around in video games.

Should you choose to use opentrack, you can do so by clicking on the 'start opentrack UDP' option. Within opentrack, you will need to select UDP over network in order to receive the data.

![phoenixheadtracker](https://user-images.githubusercontent.com/129109589/230802488-5203d2f3-403e-49b3-add3-fdfeb43947ca.png)


# Download Latest Release

Phoenixheadtracker 2.0.0.1 https://github.com/iVideoGameBoss/PhoenixHeadTracker/releases

# How to build using Visual Studio 22
PhoenixHeadTracker is based on the AirAPI_Windows.dll :https://github.com/MSmithDev/AirAPI_Windows: You will find the AirAPI_Windows.dll and hidapi.dll in the PhoenixHeadTracker/bin/x64/Debug/ folder. These two files are required in order to connect to Nreal Air glasses.


Once you clone the project, open in Visual Studio 22 by clicking on PhoenixHeadTracker.sln. Make sure you set to build on x64 and debug.Then simply click on start.

![visualstudio22](https://user-images.githubusercontent.com/129109589/228050319-965458a1-af36-466a-8aa7-c45364bc91dd.png)


Make sure that both AirAPI_Windows.dll and hidapi.dll are in the debug folder. I have included them with project.

![Screenshot 2023-03-27 145335](https://user-images.githubusercontent.com/129109589/228051761-b6afc531-5881-4ea3-b935-c2c07860951e.png)


# DCS (Digital Combat Simulator)


https://user-images.githubusercontent.com/129109589/230140740-2248b626-169c-4f85-bb17-baec839264f3.mp4

