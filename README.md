# Motion-Detection-Inteface-Using-Yolo

Requirements :

  1. Python3.7 
  2. Torch 
  3. Torch vision 
  4. OpenCV
  5. Requests
  6. Cuda ( For Faster computations ) 
  7. Unity 
  8. Nuget - Unity .net client (or similar web interface) 
  

## Motion Tracking 

###The motion tracking in this project is done through YOLOv7 ML model that creates a skeletal layer over images. The original model was used to predict the joint and skeletal positions of people in front of the camera at 20 fps ( GPU limitations ). The local joint coordinates also with the names and id is stored in a json file. 

Current limitations : 
  1. Bug in the code causes an offset in the x+ axis. This issue can be resolved by using relation motion and positioning in the unity code. 

## Unity - Python Interface 

###Normal Local server has been used to send data across the python motion tracking script and unity game. The current port in the python code is set to 8080 to match with .net client framework used in unity. The json joint coordinate data is sent through python socket library. 


## Unity Client:

### This motion tracking interface was built to be work with any unity game, but due to current GPU limitations caused by the YOLOv7 model, it struggles to work with high res and dynamic physics based games. The model works best with the character skeletal rig and IK constraint of the character is suitable to control the characters using relative motion data. 
<img width="494" alt="image" src="https://user-images.githubusercontent.com/60317553/223290837-2786584f-bd7c-42da-aae5-8dca7aaae7a1.png">


Sources : 

Wang, Y., Liu, C., Chen, M., & Liu, L. (2021). YOLOv7: An Improved Version of YOLO Series. arXiv preprint arXiv:2107.08430.

